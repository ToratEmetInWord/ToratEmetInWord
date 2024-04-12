//using System;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;
//using System.Windows.Input;
//using Microsoft.Office.Interop.Word;

//namespace Hooking
//{
//    public static class InterceptKeys
//    {
//        public delegate int LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

//        private static LowLevelKeyboardProc _proc = HookCallback;
//        private static IntPtr _hookID = IntPtr.Zero;

//        public static void SetHook()
//        {
//            _hookID = SetWindowsHookEx(WH_KEYBOARD, _proc, IntPtr.Zero, 0);
//        }

//        public static void ReleaseHook()
//        {
//            UnhookWindowsHookEx(_hookID);
//        }

//        private static int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
//        {
//            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
//            {
//                int vkCode = Marshal.ReadInt32(lParam);
//                if (IsKeyDown(Keys.Alt) && (Keys)vkCode == Keys.A)
//                {
//                    MessageBox.Show("hook hit");
//                    // Perform actions when Ctrl + D1 is pressed
//                    // For example:
//                    // Word.Application wordApp = new Word.Application();
//                    // wordApp.Visible = true;
//                }
//            }
//            return (int)CallNextHookEx(_hookID, nCode, wParam, lParam);
//        }

//        private const int WH_KEYBOARD = 2;
//        private const int WM_KEYDOWN = 0x0100;

//        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

//        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

//        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

//        [DllImport("user32.dll")]
//        private static extern short GetKeyState(int nVirtKey);

//        public static bool IsKeyDown(Keys keys)
//        {
//            return (GetKeyState((int)keys) & 0x8000) == 0x8000;
//        }
//    }
//}
