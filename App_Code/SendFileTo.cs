using System;
using System.Runtime.InteropServices;
using System.IO;

namespace SendFileTo
{
    class MAPI
    {
        private const int MAPI_LOGON_UI = 0x00000001;
        private const int MAPI_DIALOG = 0x00000008;

        public static int SendMail(string strAttachmentFileName, string strSubject)
        {
            IntPtr session = new IntPtr(0);
            IntPtr winhandle = new IntPtr(0);

            MapiMessage msg = new MapiMessage();
            msg.subject = strSubject;

            int sizeofMapiDesc = Marshal.SizeOf(typeof(MapiFileDesc));
            IntPtr pMapiDesc = Marshal.AllocHGlobal(sizeofMapiDesc);

            MapiFileDesc fileDesc = new MapiFileDesc();
            fileDesc.position = -1;
            int ptr = (int)pMapiDesc;

            string path = strAttachmentFileName;
            fileDesc.name = Path.GetFileName(path);
            fileDesc.path = path;
            Marshal.StructureToPtr(fileDesc, (IntPtr)ptr, false);

            msg.files = pMapiDesc;
            msg.fileCount = 1;

            return MAPISendMail(session, winhandle, msg, MAPI_LOGON_UI | MAPI_DIALOG, 0);
        }

        [DllImport("MAPI32.DLL")]
        private static extern int MAPISendMail(IntPtr sess, IntPtr hwnd, MapiMessage message, int flg, int rsv);

    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiMessage
    {
        public int reserved;
        public string subject;
        public string noteText;
        public string messageType;
        public string dateReceived;
        public string conversationID;
        public int flags;
        public IntPtr originator;
        public int recipCount;
        public IntPtr recips;
        public int fileCount;
        public IntPtr files;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiFileDesc
    {
        public int reserved;
        public int flags;
        public int position;
        public string path;
        public string name;
        public IntPtr type;
    }
}

