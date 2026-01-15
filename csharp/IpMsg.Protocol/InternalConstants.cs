namespace IpMsg.Protocol;

public static class InternalConstants
{
    public const int WM_APP = 0x8000;

    public const int IPMSG_REVERSEICON = 0x0100;
    public const int IPMSG_RECVICONTICK = 500;
    public const int IPMSG_RECVICONTICK2 = 200;
    public const int IPMSG_ENTRYMINSEC = 5;
    public const int IPMSG_GETLIST_FINISH = 0;
    public const int IPMSG_DELAYMSG_OFFSETTIME = 2000;
    public const int IPMSG_DELAYFOCUS_TIME = 10;
    public const int IPMSG_UPLOG_MINSPAN = 60 * 1000;
    public const int IPMSG_UPLOG_MAXSPAN = 3600 * 1000;
    public const int IPMSG_DELAYENTRY_SPAN = 20 * 1000;
    public const int IPMSG_MASTERACTIVE_LIMIT = 600;

    public const int IPMSG_BROADCAST_TIMER = 0x0101;
    public const int IPMSG_SEND_TIMER = 0x0102;
    public const int IPMSG_DELAYENTRY_TIMER = 0x0103;
    public const int IPMSG_LISTGET_TIMER = 0x0104;
    public const int IPMSG_LISTGETRETRY_TIMER = 0x0105;
    public const int IPMSG_ENTRY_TIMER = 0x0110;
    public const int IPMSG_DUMMY_TIMER = 0x0111;
    public const int IPMSG_RECV_TIMER = 0x0112;
    public const int IPMSG_ANS_TIMER = 0x0113;
    public const int IPMSG_CLEANUP_TIMER = 0x0120;
    public const int IPMSG_CLEANUPDIRTCP_TIMER = 0x0121;
    public const int IPMSG_BALLOON_RECV_TIMER = 0x0130;
    public const int IPMSG_BALLOON_OPEN_TIMER = 0x0131;
    public const int IPMSG_BALLOON_DELAY_TIMER = 0x0132;
    public const int IPMSG_BALLOON_RESET_TIMER = 0x0133;
    public const int IPMSG_BALLOON_INST_TIMER = 0x0134;
    public const int IPMSG_IMAGERECT_TIMER = 0x0140;
    public const int IPMSG_KEYCHECK_TIMER = 0x0141;
    public const int IPMSG_DELAYFOCUS_TIMER = 0x0142;
    public const int IPMSG_FOREDURATION_TIMER = 0x0143;
    public const int IPMSG_AUTOSAVE_TIMER = 0x0150;
    public const int IPMSG_FIRSTRUN_TIMER = 0x0160;
    public const int IPMSG_FWCHECK_TIMER = 0x0162;
    public const int IPMSG_POLL_TIMER = 0x0170;
    public const int IPMSG_DUMMY_TIMER2 = 0x0171;
    public const int IPMSG_BRDIR_TIMER = 0x0172;
    public const int IPMSG_DIR_TIMER = 0x0173;
    public const int IPMSG_CMD_TIMER = 0x0174;

    public const int IPMSG_DUMMY_TIMER1 = 0x0180;

    public const int IPMSG_NAMESORT = 0x00000000;
    public const int IPMSG_IPADDRSORT = 0x00000001;
    public const int IPMSG_HOSTSORT = 0x00000002;
    public const int IPMSG_NOGROUPSORTOPT = 0x00000100;
    public const int IPMSG_ICMPSORTOPT = 0x00000200;
    public const int IPMSG_NOKANJISORTOPT = 0x00000400;
    public const int IPMSG_ALLREVSORTOPT = 0x00000800;
    public const int IPMSG_GROUPREVSORTOPT = 0x00001000;
    public const int IPMSG_SUBREVSORTOPT = 0x00002000;

    public const int WM_NOTIFY_TRAY = WM_APP + 101;
    public const int WM_NOTIFY_RECV = WM_APP + 102;
    public const int WM_NOTIFY_OPENCHECK = WM_APP + 103;
    public const int WM_IPMSG_INITICON = WM_APP + 104;
    public const int WM_IPMSG_CHANGE_MCAST = WM_APP + 105;
    public const int WM_IPMSG_DELAY_FWDLG = WM_APP + 106;
    public const int WM_IPMSG_SETFWRES = WM_APP + 107;
    public const int WM_IPMSG_DIRMODE_SHEET = WM_APP + 108;
    public const int WM_RECVDLG_OPEN = WM_APP + 110;
    public const int WM_RECVDLG_EXIT = WM_APP + 111;
    public const int WM_RECVDLG_FILEBUTTON = WM_APP + 112;
    public const int WM_RECVDLG_READCHECK = WM_APP + 113;
    public const int WM_RECVDLG_BYVIEWER = WM_APP + 114;
    public const int WM_SENDDLG_OPEN = WM_APP + 121;
    public const int WM_SENDDLG_CREATE = WM_APP + 122;
    public const int WM_SENDDLG_EXIT = WM_APP + 123;
    public const int WM_SENDDLG_EXITEX = WM_APP + 124;
    public const int WM_SENDDLG_RESIZE = WM_APP + 125;
    public const int WM_SENDDLG_FONTCHANGED = WM_APP + 126;
    public const int WM_UDPEVENT = WM_APP + 130;
    public const int WM_TCPEVENT = WM_APP + 131;
    public const int WM_TCPDIREVENT = WM_APP + 132;
    public const int WM_STOPTRANS = WM_APP + 133;
    public const int WM_REFRESH_HOST = WM_APP + 140;
    public const int WM_MSGDLG_EXIT = WM_APP + 150;
    public const int WM_DELMISCDLG = WM_APP + 151;
    public const int WM_HIDE_CHILDWIN = WM_APP + 160;
    public const int WM_EDIT_DBLCLK = WM_APP + 170;
    public const int WM_DELAYSETTEXT = WM_APP + 180;
    public const int WM_DELAY_BITMAP = WM_APP + 182;
    public const int WM_DELAY_PASTE = WM_APP + 183;
    public const int WM_PASTE_REV = WM_APP + 184;
    public const int WM_PASTE_IMAGE = WM_APP + 185;
    public const int WM_PASTE_TEXT = WM_APP + 186;
    public const int WM_SAVE_IMAGE = WM_APP + 187;
    public const int WM_EDIT_IMAGE = WM_APP + 188;
    public const int WM_INSERT_IMAGE = WM_APP + 189;
    public const int WM_HISTDLG_OPEN = WM_APP + 190;
    public const int WM_HISTDLG_HIDE = WM_APP + 191;
    public const int WM_HISTDLG_NOTIFY = WM_APP + 192;
    public const int WM_FORCE_TERMINATE = WM_APP + 193;
    public const int WM_FINDDLG_DELAY = WM_APP + 194;
    public const int WM_IPMSG_IMECTRL = WM_APP + 200;
    public const int WM_IPMSG_BRNOTIFY = WM_APP + 201;
    public const int WM_IPMSG_REMOTE = WM_APP + 202;
    public const int WM_LOGVIEW_UPDATE = WM_APP + 220;
    public const int WM_LOGVIEW_RESETCACHE = WM_APP + 221;
    public const int WM_LOGVIEW_RESETFIND = WM_APP + 222;
    public const int WM_LOGVIEW_OPEN = WM_APP + 223;
    public const int WM_LOGVIEW_CLOSE = WM_APP + 225;
    public const int WM_LOGVIEW_MOUSE_EMU = WM_APP + 226;
    public const int WM_LOGFETCH_DONE = WM_APP + 230;
    public const int WM_IPMSG_SETUPDLG = WM_APP + 240;
    public const int WM_IPMSG_SVRDETECTED = WM_APP + 242;
    public const int WM_IPMSG_HELP = WM_APP + 243;
    public const int WM_IPMSG_FOCUS = WM_APP + 250;
    public const int WM_IPMSG_PLAYFIN = WM_APP + 251;
    public const int WM_IPMSG_SLACKRES = WM_APP + 260;
    public const int WM_IPMSG_UPDATERES = WM_APP + 270;
    public const int WM_IPMSG_UPDATEDLRES = WM_APP + 271;
    public const int WM_IPMSG_UPDINFORESULT = WM_APP + 272;
    public const int WM_IPMSG_UPDDATARESULT = WM_APP + 273;
    public const int WM_IPMSG_UPDATEDLG = WM_APP + 274;
    public const int WM_DELAYMSG_BALLOON = WM_APP + 280;
    public const int WM_DELAYSEND_DEL = WM_APP + 281;
    public const int WM_CROPMENU = WM_APP + 300;
    public const int WM_CROPMENU_MAX = WM_APP + 399;
    public const int WM_FILEMENU = WM_APP + 400;
    public const int WM_FILEMENU_MAX = WM_APP + 499;
    public const int WM_DUMMY_MSG1 = WM_APP + 500;
    public const int WM_DUMMY_MSG2 = WM_APP + 600;
    public const int WM_DUMMY_MSG3 = WM_APP + 601;
    public const int WM_DUMMY_MSG = WM_APP + 699;
    public const int WM_IPMSG_CMDVER = WM_APP + 700;
    public const int WM_IPMSG_CMDVERRES = WM_APP + 701;
    public const int WM_IPMSG_CMD = WM_APP + 702;
    public const int WM_IPMSG_CMDRES = WM_APP + 703;
    public const int WM_IPMSG_POSTCMD = WM_APP + 704;
    public const int WM_CMDWIN_MAIN = WM_APP + 800;

    public const int IPMSG_CMD_VER1 = 100;
    public const int IPMSG_CMD_GETABSENCE = 1;
    public const int IPMSG_CMD_SETABSENCE = 2;
    public const int IPMSG_CMD_GETHOSTLIST = 3;
    public const int IPMSG_CMD_REFRESH = 4;
    public const int IPMSG_CMD_SENDMSG = 5;
    public const int IPMSG_CMD_RECVMSG = 6;
    public const int IPMSG_CMD_GETSTATE = 7;
    public const int IPMSG_CMD_TERMINATE = 999;

    public const int IPMSG_REMOVE_FLAG = 0x000000001;
    public const int IPMSG_SEAL_FLAG = 0x000000001;
    public const int IPMSG_RECVPROC_FLAG = 0x000000001;

    public const int DIRMODE_NONE = 0;
    public const int DIRMODE_USER = 1;
    public const int DIRMODE_MASTER = 2;

    public const int SKEY_HEADER_SIZE = 12;

    public const int MAX_SOCKBUF = 256 * 1024;
    public const int MAX_UDPBUF = 32 * 1024;
    public const int MAX_ULISTBUF = 3072;
    public const int MAX_ULIST = 30;
    public const int MAX_VERBUF = 40;
    public const int MAX_BUF = 1024;
    public const int MAX_BUF_EX = MAX_BUF * 3;
    public const int MAX_MULTI_PATH = MAX_BUF * 32;
    public const int MAX_NAMEBUF = 80;
    public const int MAX_LISTBUF = MAX_NAMEBUF * 4;
    public const int MAX_ANSLIST = 100;
    public const int MAX_DOSHOST = 5;
    public const int MAX_FILENAME_U8 = 255 * 3;
    public const int MAX_MSGBODY = 65536;
    public const int MAX_FQDN = 256;

    public const int ADAY_MSEC = 24 * 60 * 60 * 1000;
    public const int ERR_MSEC = 20 * 1000;
    public const int MONTH_SEC = 30 * 24 * 60 * 60;

    public const string HS_TOOLS = "HSTools";
    public const string IP_MSG = "IPMsg";
    public const string IP_MSG_W = "IPMsg";
    public const string NO_NAME = "no_name";
    public const string URL_STR = "://";
    public const string MAILTO_STR = "mailto:";
    public const string MSG_STR = "msg";

    public const string IPMSG_CLASS = "ipmsg_class";
    public const string IPMSG_FULLNAME = "IP Messenger for Win";
    public const string IPMSG_APPID = "IPMSG for Win";
    public const string IPMSG_APPID_W = "IPMSG for Win";
    public const string IPMSG_SITE = "ipmsg.org";

    public const string IPMSG_UPDATEINFO = "ipmsg-update.dat";
    public const string UPDATE32_FILENAME = "ipmsgupd32.exe";
    public const string UPDATE64_FILENAME = "ipmsgupd64.exe";

    public static string UpdateFilename => Environment.Is64BitProcess ? UPDATE64_FILENAME : UPDATE32_FILENAME;

    public const string IPMSG_LOGNAME = "ipmsg.log";
    public const string IPMSG_LOGDBNAME = "ipmsg.db";

    public const string REMOTE_CMD = "ipmsg-cmd:";
    public const string REMOTE_FMT = REMOTE_CMD + "%s";
    public const int REMOTE_HEADERLEN = 10;
    public const int REMOTE_KEYLEN = 32;
    public const int REMOTE_KEYSTRLEN = 43;

    public const int DEFAULT_PRIORITY = 10;
    public const int PRIORITY_OFFSET = 10;
    public const int DEFAULT_PRIORITYMAX = 6;

    public const int RDLG_FREE_MI = 1;
    public const int RDLG_FILESAVE = 2;

    public const string FWCHECKMODE_STR = "FwCheckMode";

    public const long ENABLE_HOOK = 0x0d762de84d9f01a4L;
}
