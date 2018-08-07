using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace GTR
{
    public class Gdi32API
    {
        public const int SRCCOPY = 0x00CC0020;
        /// <summary>
        /// 该函数对指定的源设备环境区域中的像素进行位块（bit_block）转换，以传送到目标设备环境
        /// </summary>
        /// <param name="hdcDest">目标设备的句柄</param>
        /// <param name="nXDest">目标对象的左上角的X坐标</param>
        /// <param name="nYDest">目标对象的左上角的Y坐标</param>
        /// <param name="nWidth">目标对象的矩形的宽度</param>
        /// <param name="nHeight">目标对象的矩形的长度</param>
        /// <param name="hdcSrc">源设备的句柄</param>
        /// <param name="nXSrc">源对象的左上角的X坐标</param>
        /// <param name="nYSrc">源对象的左上角的Y坐标</param>
        /// <param name="dwRop">光栅的操作值</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);

        [DllImportAttribute("gdi32.dll", EntryPoint = "CreateDC")]
        public static extern IntPtr CreateDC(string pwszDriver, string pwszDevice, string pszPort, IntPtr pdm);

        [DllImportAttribute("gdi32.dll", EntryPoint = "CreateDIBSection")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref tagBITMAPINFO lpbmi, uint usage, ref IntPtr ppvBits, IntPtr hSection, uint offset);
        /// <summary>
        /// 该函数创建与指定的设备环境相关的设备兼容的位图。
        /// </summary>
        /// <param name="hDC">设备环境句柄</param>
        /// <param name="nWidth">指定位图的宽度，单位为像素</param>
        /// <param name="nHeight">指定位图的高度，单位为像素</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        /// <summary>
        /// 创建一个与指定设备兼容的内存设备上下文环境（DC）
        /// </summary>
        /// <param name="hDC">现有设备上下文环境的句柄，如果该句柄为NULL，该函数创建一个与应用程序的当前显示器兼容的内存设备上下文环境。</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, uint crColor);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);
        /// <summary>
        /// 删除一个逻辑笔、画笔、字体、位图、区域或者调色板，释放所有与该对象有关的系统资源，在对象被删除之后，指定的句柄也就失效了。
        /// </summary>
        /// <param name="hObject">逻辑笔、画笔、字体、位图、区域或者调色板的句柄。</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        /// <summary>
        /// 得到一个从特定类型中选定目标的设备对象句柄。
        /// </summary>
        /// <param name="hdc">设备上下文环境句柄</param>
        /// <param name="type">指定要查询的对象类型</param>
        /// <returns></returns>
        [DllImportAttribute("gdi32.dll", EntryPoint = "GetCurrentObject")]
        public static extern IntPtr GetCurrentObject(IntPtr hdc, OBJ type);
        /// <summary>
        /// 该函数得到指定图形对象的信息，根据图形对象，函数把填满的或结构，或表项（用于逻辑调色板）数目放入一个指定的缓冲区。
        /// </summary>
        /// <param name="h">指向感兴趣的图形对象的句柄，它可以是这样的一个句柄：一个逻辑位图、一个刷子、一种字体、一个调色板、笔或通过调用CreateDIBsection函数创建的与设备无关位图</param>
        /// <param name="c">指定将要写到缓冲区的信息的字节数目。</param>
        /// <param name="pv">指向一个缓冲区的指针，该缓冲区将要检索指定图形对象的信息。</param>
        /// <returns></returns>
        [DllImportAttribute("gdi32.dll", EntryPoint = "GetObject")]
        public static extern int GetObject(IntPtr h, int c, IntPtr pv);

        [DllImport("gdi32.dll")]
        public static extern IntPtr GetStockObject(int fnObject);

        [DllImport("gdi32.dll")]
        public static extern uint Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        /// <summary>
        /// 选择一对象到指定的设备上下文环境中，该新对象替换先前的相同类型的对象。
        /// </summary>
        /// <param name="hdc">设备上下文环境的句柄</param>
        /// <param name="hgdiobj">被选择的对象的句柄</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        public static extern int SetROP2(IntPtr hdc, int fnDrawMode);


    }

}
