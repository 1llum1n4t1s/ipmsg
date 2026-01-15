namespace IpMsg.Protocol;

public static class ProtocolConstants
{
    public const uint Version = 0x0001;
    public const uint NewVersion = 0x0003;
    public const int DefaultPort = 0x0979;

    public static uint GetMode(uint command) => command & 0x000000ffUL;
    public static uint GetOption(uint command) => command & 0xffffff00UL;

    public const uint NoOperation = 0x00000000UL;

    public const uint BrEntry = 0x00000001UL;
    public const uint BrExit = 0x00000002UL;
    public const uint AnsEntry = 0x00000003UL;
    public const uint BrAbsence = 0x00000004UL;
    public const uint BrNotify = BrAbsence;

    public const uint BrIsGetList = 0x00000010UL;
    public const uint OkGetList = 0x00000011UL;
    public const uint GetList = 0x00000012UL;
    public const uint AnsList = 0x00000013UL;
    public const uint AnsListDict = 0x00000014UL;
    public const uint BrIsGetList2 = 0x00000018UL;

    public const uint SendMsg = 0x00000020UL;
    public const uint RecvMsg = 0x00000021UL;
    public const uint ReadMsg = 0x00000030UL;
    public const uint DelMsg = 0x00000031UL;
    public const uint AnsReadMsg = 0x00000032UL;

    public const uint GetInfo = 0x00000040UL;
    public const uint SendInfo = 0x00000041UL;

    public const uint GetAbsenceInfo = 0x00000050UL;
    public const uint SendAbsenceInfo = 0x00000051UL;

    public const uint GetFileData = 0x00000060UL;
    public const uint ReleaseFiles = 0x00000061UL;
    public const uint GetDirFiles = 0x00000062UL;
    public const uint DirFilesAuth = 0x00000063UL;
    public const uint DirFilesAuthRet = 0x00000064UL;

    public const uint GetPubKey = 0x00000072UL;
    public const uint AnsPubKey = 0x00000073UL;

    public const uint AgentReq = 0x000000a0UL;
    public const uint AgentAnsReq = 0x000000a1UL;
    public const uint AgentPacket = 0x000000a2UL;
    public const uint AgentProxyReq = 0x000000a3UL;

    public const uint DirPoll = 0x000000b0UL;
    public const uint DirPollAgent = 0x000000b1UL;
    public const uint DirBroadcast = 0x000000b2UL;
    public const uint DirAnsBroad = 0x000000b3UL;
    public const uint DirPacket = 0x000000b4UL;
    public const uint DirRequest = 0x000000b5UL;
    public const uint DirAgentPacket = 0x000000b6UL;
    public const uint DirEvBroad = 0x000000b7UL;
    public const uint DirAgentReject = 0x000000b8UL;

    public const uint AbsenceOpt = 0x00000100UL;
    public const uint ServerOpt = 0x00000200UL;
    public const uint DialupOpt = 0x00010000UL;
    public const uint FileAttachOpt = 0x00200000UL;
    public const uint EncryptOpt = 0x00400000UL;
    public const uint Utf8Opt = 0x00800000UL;
    public const uint CapUtf8Opt = 0x01000000UL;
    public const uint EncExtMsgOpt = 0x04000000UL;
    public const uint ClipboardOpt = 0x08000000UL;
    public const uint CapFileEncObsolete = 0x00001000UL;
    public const uint CapFileEncOpt = 0x00040000UL;
    public const uint CapIpDictOpt = 0x02000000UL;
    public const uint DirMaster = 0x10000000UL;
    public const uint FlagResv1 = 0x20000000UL;
    public const uint FlagResv2 = 0x40000000UL;

    public const uint AllStat = AbsenceOpt | ServerOpt | DialupOpt | FileAttachOpt | ClipboardOpt | EncryptOpt |
                                CapUtf8Opt | EncExtMsgOpt | CapFileEncOpt | CapIpDictOpt | DirMaster;

    public const uint FullStat = AllStat & ~(AbsenceOpt | ServerOpt | DialupOpt);

    public const uint SendCheckOpt = 0x00000100UL;
    public const uint SecretOpt = 0x00000200UL;
    public const uint BroadcastOpt = 0x00000400UL;
    public const uint MulticastOpt = 0x00000800UL;
    public const uint AutoRetOpt = 0x00002000UL;
    public const uint RetryOpt = 0x00004000UL;
    public const uint PasswordOpt = 0x00008000UL;
    public const uint NoLogOpt = 0x00020000UL;
    public const uint NoAddListOpt = 0x00080000UL;
    public const uint ReadCheckOpt = 0x00100000UL;
    public const uint SecretExOpt = ReadCheckOpt | SecretOpt;

    public const uint EncFileObsolete = 0x00000400UL;
    public const uint EncFileOpt = 0x00000800UL;

    public const uint NewMultiObsolete = 0x00040000UL;

    public const uint Rsa1024 = 0x00000002UL;
    public const uint Rsa2048 = 0x00000004UL;
    public const uint Rsa4096 = 0x00000008UL;
    public const uint Blowfish128 = 0x00020000UL;
    public const uint Aes256 = 0x00100000UL;
    public const uint CommonKeys = Blowfish128 | Aes256;
    public const uint PacketNoIv = 0x00800000UL;
    public const uint IpDictCtr = 0x00400000UL;
    public const uint EncodeBase64 = 0x01000000UL;
    public const uint NoEncFileBody = 0x04000000UL;
    public const uint SignSha1 = 0x20000000UL;
    public const uint SignSha256 = 0x40000000UL;

    public const uint Rsa512Obsolete = 0x00000001UL;
    public const uint Rc240Old = 0x00000010UL;
    public const uint Rc2128Old = 0x00000040UL;
    public const uint Blowfish128Old = 0x00000400UL;
    public const uint Rc240Obsolete = 0x00001000UL;
    public const uint Rc2128Obsolete = 0x00004000UL;
    public const uint Rc2256Obsolete = 0x00008000UL;
    public const uint Blowfish256Obsolete = 0x00040000UL;
    public const uint Aes128Obsolete = 0x00080000UL;
    public const uint SignMd5Obsolete = 0x10000000UL;
    public const uint UNameExtOptObsolete = 0x02000000UL;

    public const uint FileRegular = 0x00000001UL;
    public const uint FileDir = 0x00000002UL;
    public const uint FileRetParent = 0x00000003UL;
    public const uint FileSymlink = 0x00000004UL;
    public const uint FileCDev = 0x00000005UL;
    public const uint FileBDev = 0x00000006UL;
    public const uint FileFifo = 0x00000007UL;
    public const uint FileResFork = 0x00000010UL;
    public const uint FileClipboard = 0x00000020UL;

    public const uint FileROnlyOpt = 0x00000100UL;
    public const uint FileHiddenOpt = 0x00001000UL;
    public const uint FileExHiddenOpt = 0x00002000UL;
    public const uint FileArchiveOpt = 0x00004000UL;
    public const uint FileSystemOpt = 0x00008000UL;

    public const uint FileUid = 0x00000001UL;
    public const uint FileUserName = 0x00000002UL;
    public const uint FileGid = 0x00000003UL;
    public const uint FileGroupName = 0x00000004UL;
    public const uint FileClipboardPos = 0x00000008UL;
    public const uint FilePerm = 0x00000010UL;
    public const uint FileMajorNo = 0x00000011UL;
    public const uint FileMinorNo = 0x00000012UL;
    public const uint FileCTime = 0x00000013UL;
    public const uint FileMTime = 0x00000014UL;
    public const uint FileATime = 0x00000015UL;
    public const uint FileCreateTime = 0x00000016UL;
    public const uint FileCreator = 0x00000020UL;
    public const uint FileFileType = 0x00000021UL;
    public const uint FileFinderInfo = 0x00000022UL;
    public const uint FileAcl = 0x00000030UL;
    public const uint FileAliasFName = 0x00000040UL;

    public const char FileListSeparator = '\a';
    public const char HostListSeparator = '\a';
    public const string HostListSeparators = "\a";
    public const char HostListNewSeparator = '\f';
    public const string HostListDummy = "\b";

    public const string DefaultMulticastAddr6 = "ff15::979";
    public const string LinkMulticastAddr6 = "ff02::1";
    public const string LimitedBroadcast = "255.255.255.255";

    public const uint VerWin32Type = 0x00010001;
    public const uint VerWin64Type = 0x00010002;
    public const uint VerMacType = 0x00020000;
    public const uint VerIosType = 0x00030000;
    public const uint VerAndroidType = 0x00040000;

    public const string VerKey = "VER";
    public const string PktNoKey = "PKT";
    public const string DateKey = "DATE";
    public const string UidKey = "UID";
    public const string HostKey = "HID";
    public const string NickKey = "NCK";
    public const string NickOrgKey = "NCKO";
    public const string GroupKey = "GRP";
    public const string StatKey = "STAT";
    public const string ExStatKey = "EXST";
    public const string CmdKey = "CMD";
    public const string FlagsKey = "FLG";
    public const string CliVerKey = "CVER";
    public const string BodyKey = "BODY";
    public const string ReplyPktKey = "RPN";
    public const string ToListKey = "TLST";
    public const string FromKey = "FROM";
    public const string HostListKey = "HLST";
    public const string IpAddrKey = "IPAD";
    public const string PortKey = "PORT";
    public const string PollKey = "POLL";
    public const string MasterKey = "MST";
    public const string EncFlagKey = "EF";
    public const string EncIvKey = "EI";
    public const string EncKeyKey = "EK";
    public const string EncBodyKey = "EB";
    public const string PubEKey = "PUBE";
    public const string PubNKey = "PUBN";
    public const string EncCapaKey = "EC";
    public const string SignKey = "SIGN";

    public const string FileKey = "FILE";
    public const string FidKey = "FI";
    public const string FNameKey = "FN";
    public const string FSizeKey = "FS";
    public const string MTimeKey = "MT";
    public const string FAttrKey = "FA";
    public const string ClipPosKey = "CP";

    public const string StartKey = "START";
    public const string TotalKey = "TOTAL";
    public const string NumKey = "NUM";
    public const string DirBroadKey = "DRB";
    public const string TargAddrKey = "TADR";
    public const string NAddrKey = "NADR";
    public const string NAddrsKey = "NADRS";
    public const string AddrKey = "ADR";
    public const string MaskKey = "MASK";
    public const string WrappedKey = "WAPD";
    public const string UptimeKey = "UPT";
    public const string AgentSecKey = "AGS";
    public const string ActiveKey = "ACT";
    public const string SvrAddrKey = "SVADR";
    public const string AgentKey = "AGNT";
    public const string DirectKey = "DRCT";

    public const string AbsTitleKey = "ABST";
    public const string AbsModeKey = "ABSMD";
    public const string FileListKey = "FLS";
    public const string ErrInfoKey = "EINF";
}
