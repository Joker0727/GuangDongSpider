using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
//using WinAPI.Struct;
//using WinAPI.Enums;

namespace GTR
{
    public class Shell32API
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pszPath">指定的文件全路径</param>
        /// <param name="dwFileAttributes">文件属性,一般是0</param>
        /// <param name="psfi">这个结构总是用于返回数据到调用程序， 并且从不需要初始化</param>
        /// <param name="cbFileInfo">sizeof(psfi)</param>
        /// <param name="uFlags">指明需要返回的文件信息标识符<see cref="WinAPI.Shell32API"/></param>
        /// <returns></returns>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    }

    

    
}
