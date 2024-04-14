using System;
using System.Runtime.InteropServices;
using System.Text;

public enum EShellLinkResolveFlags : uint
{
    SLR_NO_UI = 0x0001,
    SLR_ANY_MATCH = 0x0002,
    SLR_UPDATE = 0x0004,
    SLR_NOUPDATE = 0x0008,
    SLR_NOSEARCH = 0x0010,
    SLR_NOTRACK = 0x0020,
    SLR_NOLINKINFO = 0x0040,
    SLR_INVOKE_MSI = 0x0080,
    SLR_NO_UI_WITH_MSG_PUMP = 0x101,
    SLR_OFFER_DELETE_WITHOUT_FILE = 0x200,
    SLR_KNOWNFOLDER = 0x400,
    SLR_MACHINE_IN_LOCAL_TARGET = 0x800,
    SLR_UPDATE_MACHINE_AND_SID = 0x1000
}

public class ShellLink
{
    private IShellLinkW link = null;

    public ShellLink()
    {
        link = (IShellLinkW)new CShellLink();
    }

    public void Open(
        string linkFile,
        IntPtr hWnd,
        EShellLinkResolveFlags resolveFlags,
        ushort timeOut
    )
    {
        uint flags;

        if ((resolveFlags & EShellLinkResolveFlags.SLR_NO_UI) == EShellLinkResolveFlags.SLR_NO_UI)
        {
            flags = (uint)((int)resolveFlags | (timeOut << 16));
        }
        else
        {
            flags = (uint)resolveFlags;
        }

        // Get the IPersistFile interface and call Load:
        ((IPersistFile)link).Load(linkFile, 0);
        // Resolve the link:
        link.Resolve(hWnd, flags);
    }

    public string Arguments
    {
        get
        {
            StringBuilder arguments = new StringBuilder(260, 260);
            link.GetArguments(arguments, arguments.Capacity);
            return arguments.ToString();
        }
        set
        {
            link.SetArguments(value);
        }
    }

    public void CreateShortcut(string shortcutPath, string targetPath, string arguments, string description)
    {
        link.SetPath(targetPath);
        link.SetArguments(arguments);
        link.SetDescription(description);

        IPersistFile persistFile = (IPersistFile)link;
        persistFile.Save(shortcutPath, true);
    }

    public string ReadShortcutPath(string shortcutPath)
    {
        if (System.IO.File.Exists(shortcutPath))
        {
            link = (IShellLinkW)new CShellLink();
            IPersistFile persistFile = (IPersistFile)link;
            persistFile.Load(shortcutPath, 0);
            StringBuilder pathBuilder = new StringBuilder(260, 260);
            link.GetPath(pathBuilder, pathBuilder.Capacity, default, 0);
            return pathBuilder.ToString();
        }
        else
        {
            throw new System.IO.FileNotFoundException("Shortcut file not found.", shortcutPath);
        }
    }

    [ComImport]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IShellLinkW
    {
        void GetPath(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
            int cchMaxPath,
            ref _WIN32_FIND_DATAW pfd,
            uint fFlags);

        void GetIDList(out IntPtr ppidl);

        void SetIDList(IntPtr pidl);

        void GetDescription(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
            int cchMaxName);

        void SetDescription(
            [MarshalAs(UnmanagedType.LPWStr)] string pszName);

        void GetWorkingDirectory(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir,
            int cchMaxPath);

        void SetWorkingDirectory(
            [MarshalAs(UnmanagedType.LPWStr)] string pszDir);

        void GetArguments(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs,
            int cchMaxPath);

        void SetArguments(
            [MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

        void GetHotkey(out short pwHotkey);

        void SetHotkey(short pwHotkey);

        void GetShowCmd(out uint piShowCmd);

        void SetShowCmd(uint piShowCmd);

        void GetIconLocation(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
            int cchIconPath,
            out int piIcon);

        void SetIconLocation(
            [MarshalAs(UnmanagedType.LPWStr)] string pszIconPath,
            int iIcon);

        void SetRelativePath(
            [MarshalAs(UnmanagedType.LPWStr)] string pszPathRel,
            uint dwReserved);

        void Resolve(
            IntPtr hWnd,
            uint fFlags);

        void SetPath(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    [ClassInterface(ClassInterfaceType.None)]
    private class CShellLink { }

    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0, CharSet = CharSet.Unicode)]
    private struct _WIN32_FIND_DATAW
    {
        public uint dwFileAttributes;
        public _FILETIME ftCreationTime;
        public _FILETIME ftLastAccessTime;
        public _FILETIME ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint dwReserved0;
        public uint dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0)]
    private struct _FILETIME
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }

    [ComImport]
    [Guid("0000010B-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IPersistFile
    {
        [PreserveSig]
        int GetClassID(out Guid pClassID);

        [PreserveSig]
        int IsDirty();

        void Load(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            uint dwMode);

        void Save(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [MarshalAs(UnmanagedType.Bool)] bool fRemember);

        void SaveCompleted(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

        void GetCurFile(
            [MarshalAs(UnmanagedType.LPWStr)] out string ppszFileName);
    }
}
