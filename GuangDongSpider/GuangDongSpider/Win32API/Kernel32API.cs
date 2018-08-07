using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using WinAPI.Enums;
//using WinAPI.Struct;
using System.Runtime.InteropServices;

namespace GTR
{
    public class Kernel32API
    {
        /// <summary>
        /// 获取当前线程一个唯一的线程标识符
        /// </summary>
        /// <returns>线程pid</returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwErrCode"></param>
        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(uint dwErrCode);
        [DllImport("kernel32.dll", EntryPoint = "GetLastError")]
        public static extern uint GetLastError();
        /// <summary>
        /// 获取模块句柄 
        /// </summary>
        /// <param name="lpModuleName">如果是空值返回自身应用程序句柄</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        /// <summary>
        /// 通过获取进程信息为指定的进程、进程使用的堆[HEAP]、模块[MODULE]、线程建立一个快照.
        /// </summary>
        /// <param name="dwFlags">用来指定“快照”中需要返回的对象，可以是TH32CS_SNAPPROCESS等</param>
        /// <param name="processid">一个进程ID号，用来指定要获取哪一个进程的快照，当获取系统进程列表或获取当前进程快照时可以设为0</param>
        /// <returns></returns>
        [DllImport("KERNEL32.DLL ")]
        public static extern IntPtr CreateToolhelp32Snapshot(UInt32 dwFlags, uint processid);
        /// <summary>
        /// 关闭句柄
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("KERNEL32.DLL ")]
        public static extern bool CloseHandle(IntPtr handle);
        /// <summary>
        /// 进程获取函数,当我们利用函数CreateToolhelp32Snapshot()获得当前运行进程的快照后,
        /// 我们可以利用process32First函数来获得第一个进程的句柄
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="pe"></param>
        /// <returns></returns>
        [DllImport("KERNEL32.DLL ")]
        public static extern bool Process32First(IntPtr handle, ref   ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL ")]
        public static extern bool Process32Next(IntPtr handle, ref   ProcessEntry32 pe);

        [DllImport("KERNEL32.DLL ")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("KERNEL32.DLL ")]
        public static extern uint GetPrivateProfileString(string lpAppName,
                                                            string lpKeyName,
                                                            string lpDefault,
                                                            System.Text.StringBuilder lpReturnedString,
                                                            int nSize,
                                                            string lpFileName);
        [DllImport("kernel32")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, Byte[] retVal, int nSize, string lpFileName);

    }

}
