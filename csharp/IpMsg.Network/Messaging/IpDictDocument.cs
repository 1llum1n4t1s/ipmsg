using System.Globalization;

namespace IpMsg.Network.Messaging;

public sealed class IpDictDocument
{
    private const string Header = "IP2:";
    private const string Footer = ":Z";

    private readonly List<IpDictEntry> _entries = new();

    public IReadOnlyList<IpDictEntry> Entries => _entries;

    public void SetString(string key, string value) => AddOrReplace(key, new IpDictValue(IpDictValueType.String, value));

    public void SetBytes(string key, byte[] value)
    {
        AddOrReplace(key, new IpDictValue(IpDictValueType.Bytes, Convert.ToHexString(value).ToLowerInvariant()));
    }

    public void SetInt(string key, long value)
    {
        var hex = value < 0
            ? $"-{Math.Abs(value).ToString("x", CultureInfo.InvariantCulture)}"
            : value.ToString("x", CultureInfo.InvariantCulture);
        AddOrReplace(key, new IpDictValue(IpDictValueType.Int, hex));
    }

    public void SetFloat(string key, double value)
    {
        var bytes = BitConverter.GetBytes(value);
        var trimmed = TrimTrailingZeros(bytes);
        AddOrReplace(key, new IpDictValue(IpDictValueType.Float, Convert.ToHexString(trimmed).ToLowerInvariant()));
    }

    public void SetIpDict(string key, IpDictDocument dict)
    {
        AddOrReplace(key, new IpDictValue(IpDictValueType.IpDict, dict.Serialize()));
    }

    public void SetDict(string key, IpDictDocument dict)
    {
        AddOrReplace(key, new IpDictValue(IpDictValueType.Dictionary, SerializeDictionary(dict._entries)));
    }

    public void SetList(string key, IReadOnlyList<IpDictValue> values)
    {
        AddOrReplace(key, new IpDictValue(IpDictValueType.List, SerializeList(values)));
    }

    public IpDictValue? GetValue(string key) => _entries.FirstOrDefault(entry => entry.Key == key)?.Value;

    public string? GetString(string key)
    {
        return GetValue(key)?.Raw;
    }

    public long? GetInt(string key)
    {
        var value = GetString(key);
        if (value is null)
        {
            return null;
        }

        var negative = value.StartsWith('-');
        var hex = negative ? value[1..] : value;
        if (!long.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var parsed))
        {
            return null;
        }

        return negative ? -parsed : parsed;
    }

    public IpDictDocument? GetDict(string key)
    {
        var value = GetValue(key);
        if (value is null)
        {
            return null;
        }

        return ParseDictionary(value.Raw);
    }

    public IReadOnlyList<IpDictValue>? GetList(string key)
    {
        var value = GetValue(key);
        if (value is null)
        {
            return null;
        }

        return ParseList(value.Raw);
    }

    public byte[]? GetBytes(string key)
    {
        var value = GetValue(key);
        if (value is null)
        {
            return null;
        }

        return Convert.FromHexString(value.Raw);
    }

    public double? GetFloat(string key)
    {
        var value = GetValue(key);
        if (value is null)
        {
            return null;
        }

        var bytes = Convert.FromHexString(value.Raw);
        if (bytes.Length < sizeof(double))
        {
            Array.Resize(ref bytes, sizeof(double));
        }

        return BitConverter.ToDouble(bytes, 0);
    }

    public IpDictDocument? GetIpDict(string key)
    {
        var value = GetValue(key);
        if (value is null)
        {
            return null;
        }

        return Parse(value.Raw);
    }

    public string Serialize()
    {
        var content = string.Join("", _entries.Select(entry => $"{entry.Key}:{entry.Value.Raw.Length:x}:{entry.Value.Raw}"));
        return $"{Header}{content.Length:x}:{content}{Footer}";
    }

    public static IpDictDocument Parse(string payload)
    {
        if (!payload.StartsWith(Header, StringComparison.Ordinal) || !payload.EndsWith(Footer, StringComparison.Ordinal))
        {
            throw new FormatException("IPDict形式のヘッダー/フッターが見つかりません。");
        }

        var cursor = Header.Length;
        var lengthEnd = payload.IndexOf(':', cursor);
        if (lengthEnd < 0)
        {
            throw new FormatException("IPDict形式の長さフィールドが不正です。");
        }

        var lengthHex = payload.Substring(cursor, lengthEnd - cursor);
        if (!int.TryParse(lengthHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var contentLength))
        {
            throw new FormatException("IPDict形式の長さが解析できません。");
        }

        cursor = lengthEnd + 1;
        var content = payload.Substring(cursor, contentLength);
        var document = new IpDictDocument();

        var contentCursor = 0;
        while (contentCursor < content.Length)
        {
            var keyEnd = content.IndexOf(':', contentCursor);
            if (keyEnd < 0)
            {
                throw new FormatException("IPDict形式のキー区切りが不正です。");
            }

            var key = content.Substring(contentCursor, keyEnd - contentCursor);
            contentCursor = keyEnd + 1;

            var valueLengthEnd = content.IndexOf(':', contentCursor);
            if (valueLengthEnd < 0)
            {
                throw new FormatException("IPDict形式の値長が不正です。");
            }

            var valueLengthHex = content.Substring(contentCursor, valueLengthEnd - contentCursor);
            if (!int.TryParse(valueLengthHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var valueLength))
            {
                throw new FormatException("IPDict形式の値長が解析できません。");
            }

            contentCursor = valueLengthEnd + 1;
            if (contentCursor + valueLength > content.Length)
            {
                throw new FormatException("IPDict形式の値長が範囲外です。");
            }

            var value = content.Substring(contentCursor, valueLength);
            contentCursor += valueLength;

            document._entries.Add(new IpDictEntry(key, new IpDictValue(IpDictValueType.Unknown, value)));
        }

        return document;
    }

    private void AddOrReplace(string key, IpDictValue value)
    {
        var index = _entries.FindIndex(entry => entry.Key == key);
        if (index >= 0)
        {
            _entries[index] = new IpDictEntry(key, value);
            return;
        }

        _entries.Add(new IpDictEntry(key, value));
    }

    private static string SerializeDictionary(IEnumerable<IpDictEntry> entries)
    {
        return string.Join("", entries.Select(entry => $"{entry.Key}:{entry.Value.Raw.Length:x}:{entry.Value.Raw}"));
    }

    private static string SerializeList(IReadOnlyList<IpDictValue> values)
    {
        return string.Join("", values.Select(value => $"{value.Raw.Length:x}:{value.Raw}"));
    }

    private static IpDictDocument ParseDictionary(string payload)
    {
        var document = new IpDictDocument();
        var cursor = 0;
        while (cursor < payload.Length)
        {
            var keyEnd = payload.IndexOf(':', cursor);
            if (keyEnd < 0)
            {
                break;
            }

            var key = payload.Substring(cursor, keyEnd - cursor);
            cursor = keyEnd + 1;

            var valueLengthEnd = payload.IndexOf(':', cursor);
            if (valueLengthEnd < 0)
            {
                break;
            }

            var valueLengthHex = payload.Substring(cursor, valueLengthEnd - cursor);
            if (!int.TryParse(valueLengthHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var valueLength))
            {
                break;
            }

            cursor = valueLengthEnd + 1;
            if (cursor + valueLength > payload.Length)
            {
                break;
            }

            var value = payload.Substring(cursor, valueLength);
            cursor += valueLength;

            document._entries.Add(new IpDictEntry(key, new IpDictValue(IpDictValueType.Unknown, value)));
        }

        return document;
    }

    private static IReadOnlyList<IpDictValue> ParseList(string payload)
    {
        var values = new List<IpDictValue>();
        var cursor = 0;
        while (cursor < payload.Length)
        {
            var lengthEnd = payload.IndexOf(':', cursor);
            if (lengthEnd < 0)
            {
                break;
            }

            var lengthHex = payload.Substring(cursor, lengthEnd - cursor);
            if (!int.TryParse(lengthHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var valueLength))
            {
                break;
            }

            cursor = lengthEnd + 1;
            if (cursor + valueLength > payload.Length)
            {
                break;
            }

            var value = payload.Substring(cursor, valueLength);
            cursor += valueLength;
            values.Add(new IpDictValue(IpDictValueType.Unknown, value));
        }

        return values;
    }

    private static byte[] TrimTrailingZeros(byte[] data)
    {
        var length = data.Length;
        while (length > 1 && data[length - 1] == 0)
        {
            length--;
        }

        if (length == data.Length)
        {
            return data;
        }

        return data[..length];
    }
}

public enum IpDictValueType
{
    Unknown,
    String,
    Int,
    Float,
    Bytes,
    List,
    Dictionary,
    IpDict
}

public sealed record IpDictEntry(string Key, IpDictValue Value);

public sealed record IpDictValue(IpDictValueType Type, string Raw);
