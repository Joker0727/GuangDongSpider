using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

//using System.Drawing;
//using WinAPI.Enums;
//using WinAPI.Struct;
//using WinAPI.Input;

namespace GTR
{
    public class User32API
    {

        #region User32.dll 常量
        public const int HWND_TOPMOST = -1;
        public const int SWP_SHOWWINDOW = 40;
        #endregion

        #region 委托
        [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
        public delegate int HOOKPROC(int code, IntPtr wParam, IntPtr lParam);
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        #endregion

        #region User32.dll 函数
        /// <summary>
        /// 通常，系统内的每个线程都有自己的输入队列。本函数（既“连接线程输入函数”）允许线程和进程共享输入队列。
        /// 连接了线程后，输入焦点、窗口激活、鼠标捕获、键盘状态以及输入队列状态都会进入共享状态。
        /// 调用这个函数时，会重设键盘状态。
        /// </summary>
        /// <param name="idAttach">指定一个将要连接到其他线程的标识符（ID）</param>
        /// <param name="idAttachTo">与idAttach线程连接的另一个线程的标识符</param>
        /// <param name="fAttach">true连接，false撤消连接</param>
        /// <returns>布尔值</returns>
        /// 
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        public static extern uint GetCurrentProcessId();
        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);
        [DllImport("kernel32", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetProcessWorkingSetSize(int hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);
        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, bool fAttach);
        /// <summary>
        /// 该函数将指定的窗口设置到Z序的顶部。
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(IntPtr hWnd);
        /// <summary>
        /// 使用LowLevelKeyboardProc重载（键盘钩子）
        /// </summary>
        /// <param name="hhk">当前钩子的句柄</param>
        /// <param name="nCode">钩子代码; 就是给下一个钩子要交待的</param>
        /// <param name="wParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <param name="lParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <returns>返回这个值链中的下一个钩子程序</returns>
        //[DllImport("user32.dll")]
        //static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, WM wParam, [In]KBDLLHOOKSTRUCT lParam);
        //// 使用LowLevelMouseProc重载（鼠标钩子）
        //[DllImport("user32.dll")]
        //static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, WM wParam, [In]MSLLHOOKSTRUCT lParam);

        /// <summary>
        /// 通过WM_CHANGECBCHAIN消息给剪贴板链中的窗口，因为在链中的一个窗口返回false.
        /// 当它处理WM_CHANGECBCHAIN,返回值是由ChangeClipboardChain被置为false。如果只有一个窗口在链中，返回值为true。
        /// </summary>
        /// <param name="hWndRemove">从剪贴板链中移出的窗口句柄</param>
        /// <param name="hWndNewNext">hWndRemove的下一个在剪贴板链中的窗口句柄</param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        /// <summary>
        /// 该函数将指定点的用户坐标转换成屏幕坐标。
        /// </summary>
        /// <param name="hWnd">用户区域用于转换的窗口句柄。</param>
        /// <param name="pt">用户坐标，输出参数</param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref tagPoint pt);
        /// <summary>
        /// 关闭剪贴板
        /// </summary>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        static public extern bool CloseClipboard();
        /// <summary>
        /// 打开并清空剪贴板
        /// </summary>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        static public extern bool EmptyClipboard();
        /// <summary>
        /// 该函数可以激活一个或两个滚动条箭头或是使其失效。
        /// </summary>
        /// <param name="hWnd">窗体句柄或滚动条句柄</param>
        /// <param name="wSBflags">指定滚动条的类型:SB_BOTH,SB_CTL,SB_HORZ,SB_VERT</param>
        /// <param name="wArrows"></param>
        /// <returns></returns>
        ///  /// <summary>
        /// 显示或隐藏窗体的标准的水平滚动条。
        /// </summary>
        //SB_HORZ = 0,
        /// <summary>
        /// 显示或隐藏窗体的标准的垂直滚动条。
        /// </summary>
        // SB_VERT = 1,
        /// <summary>
        /// 显示或隐藏滚动条控制。参数hWnd必须是指向滚动条控制的句柄。
        /// </summary>
        // SB_CTL = 2,
        /// <summary>
        /// 显示或隐藏窗体的标准的水平或垂直滚动条。
        /// </summary>
        // SB_BOTH = 3
        [DllImport("user32.dll")]
        public static extern bool EnableScrollBar(IntPtr hWnd, int wSBflags, uint wArrows);
        /// <summary>
        /// 该函数枚举所有屏幕上的顶层窗口，并将窗口句柄传送给应用程序定义的回调函数。
        /// 回调函数返回FALSE将停止枚举，否则EnumWindows函数继续到所有顶层窗口枚举完为止。
        /// EnumWindows函数不列举子窗口。
        /// </summary>
        /// <param name="lpEnumFunc">指向一个应用程序定义的回调函数指针</param>
        /// <param name="lParam">指定一个传递给回调函数的应用程序定义值</param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, uint lParam);

        /// <summary>
        /// 该函数用指定的画刷填充矩形，此函数包括矩形的左上边界，但不包括矩形的右下边界.
        /// </summary>
        /// <param name="hDC">设备环境句柄</param>
        /// <param name="rect">指向含有将填充矩形的逻辑坐标的RECT结构的指针</param>
        /// <param name="hBrush">用来填充矩形的画刷的句柄</param>
        /// <returns>如果函数调用成功，返回值非零；如果函数调用失败，返回值是0</returns>
        [DllImport("user32.dll")]
        public static extern int FillRect(IntPtr hDC, ref RECT rect, IntPtr hBrush);
        /// <summary>
        /// 获得窗口句柄
        /// </summary>
        /// <param name="className">窗体类名</param>
        /// <param name="windowName">窗口标题</param>
        /// <returns>句柄</returns>
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(string className, string windowName);
        /// <summary>
        /// 在窗口列表中寻找与指定条件相符的第一个子窗口.
        /// </summary>
        /// <param name="hwndParent">要查找的子窗口所在的父窗口的句柄.如果设置了hwndParent则表示从这个hwndParent指向的父窗口中搜索子窗口.</param>
        /// <param name="hwndChildAfter">子窗口句柄.查找从在Z序中的下一个子窗口开始.子窗口必须为hwndParent窗口的直接子窗口而非后代窗口.如果HwndChildAfter为NULL,查找从hwndParent的第一个子窗口开始.如果hwndParent 和 hwndChildAfter同时为NULL,则函数查找所有的顶层窗口及消息窗口.</param>
        /// <param name="lpszClass">指向一个指定了类名的空结束字符串,或一个标识类名字符串的成员的指针.如果该参数为一个成员,则它必须为前次调用theGlobaIAddAtom函数产生的全局成员.该成员为16位,必须位于lpClassName的低16位,高位必须为0.</param>
        /// <param name="lpszWindow">指向一个指定了窗口名(窗口标题)的空结束字符串.如果该参数为null,则为所有窗口全匹配.</param>
        /// <returns>窗口的句柄</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        /// <summary>
        /// 获得与调用线程的消息队列相关的活动窗口的窗口句柄
        /// </summary>
        /// <returns>窗口句柄，如果没有活动的窗口返回IntPtr.Zero</returns>
        [DllImport("user32.dll")]
        public extern static IntPtr GetActiveWindow();
        /// <summary>
        /// 获得指定窗口所属的类的类名.
        /// </summary>
        /// <param name="hWnd">窗口的句柄及间接给出的窗口所属的类.</param>
        /// <param name="lpClassName">输出类名.</param>
        /// <param name="nMaxCount">缓冲区长度,如果类名字符串大于缓冲区的长度,则多出的部分被截断.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        /// <summary>
        /// 获取窗口客户区的坐标.
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="rect">客户区坐标</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public extern static int GetClientRect(IntPtr hWnd, out RECT rect);
        /// <summary>
        /// 检索一指定窗口的客户区域或整个屏幕的显示设备上下文环境的句柄，以后可以在GDI函数中使用该句柄来在设备上下文环境中绘图.
        /// </summary>
        /// <param name="hWnd">设备上下文环境被检索的窗口的句柄</param>
        /// <returns>窗口句柄</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        /// <summary>
        /// 指定窗口客户区域或整个屏幕的显示设备上下文环境的句柄，在随后的GDI函数中可以使用该句柄在设备上下文环境中绘图.
        /// </summary>
        /// <param name="hWnd">窗口句柄.</param>
        /// <param name="hRegion">指定一剪切区域，它可以与设备上下文环境的可见区域相结合.</param>
        /// <param name="flags">指定如何创建设备上下文环境<see cref="WinAPI.Enums.GetDCEx"/></param>
        /// <returns>窗口句柄</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);
        /// <summary>
        /// 该函数返回桌面窗口的句柄.桌面窗口覆盖整个屏幕.
        /// </summary>
        /// <returns>窗口句柄</returns>
        [DllImport("user32.dll")]
        static public extern IntPtr GetDesktopWindow();
        /// <summary>
        /// 返回窗口中指定参数ID的子元素的句柄，可以通过返回的句柄对窗口内的子元素进行操作.
        /// </summary>
        /// <param name="hDlg">对话窗口句柄</param>
        /// <param name="nControlID">子类窗口的标识符</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);
        /// <summary>
        /// 确定当前焦点位于哪个控件上.
        /// </summary>
        /// <returns>窗口句柄</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();
        /// <summary>
        /// 获取一个前台窗口的句柄
        /// </summary>
        /// <returns>返回值是一个前台窗口的句柄。在某些情况下，如一个窗口失去激活时，前台窗口可以是null</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        /// <summary>
        /// 该函数将256个虚拟键的状态拷贝到指定的缓冲区中.
        /// </summary>
        /// <param name="pbKeyState">指向一个256字节的数组，数组用于接收每个虚拟键的状态</param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool GetKeyboardState(byte[] pbKeyState);
        /// <summary>
        /// 判断按键按下或者弹起(实时状态).
        /// </summary>
        /// <param name="virtualKey"><see cref="WinAPI.Enums.VirtualKey"/></param>
        /// <returns>1按下,0弹起.</returns>
        [DllImport("user32.dll")]
        internal static extern Int16 GetAsyncKeyState(UInt16 virtualKey);

        /// <summary>
        /// 检取指定虚拟键的状态
        /// </summary>
        /// <param name="virtualKeyCode"><see cref="WinAPI.Enums.VirtualKey"/></param>
        /// <returns>1按下,0弹起.</returns>
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int virtualKeyCode);
        /// <summary>
        /// 在一个矩形中装载指定菜单条目的屏幕坐标信息
        /// </summary>
        /// <param name="hWnd">包含指定菜单或弹出式菜单的一个窗口的句柄</param>
        /// <param name="hMenu">菜单的句柄</param>
        /// <param name="Item">欲检查的菜单条目的位置或菜单ID</param>
        /// <param name="rc">装载菜单条目的位置及大小(采用屏幕坐标表示)</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static public extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint Item, ref RECT rc);
        /// <summary>
        /// 为当前线程取得额外的消息信息,额外的消息信息应用程序或驱动定义的与当前线程消息队列相关的值
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr GetMessageExtraInfo();
        /// <summary>
        /// 取得整个桌面任意位置的鼠标句柄
        /// </summary>
        /// <param name="pci"></param>
        /// <returns></returns>
        //tagCURSORINFO hCur ;
        //ZeroMemory(&hCur,sizeof(hCur));
        //hCur.cbSize=sizeof(hCur);
        //GetCursorInfo(&hCur);
        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(ref tagCURSORINFO pci);

        /// <summary>
        /// 获得一个指定子窗口的父窗口句柄.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        /// <summary>
        /// 用于得到被定义的系统数据或者系统配置信息.
        /// </summary>
        /// <param name="nIndex"><see cref="WinAPI.Enums.SystemMetrics"/></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static public extern int GetSystemMetrics(int nIndex);
        /*
   	        HWND wnd=FindWindow(NULL,"11.txt - 记事本");
	        HDC dc=GetWindowDC(wnd);
	
	        while(1)
	        {
		        SetTextColor(dc,RGB(255,0,0));//文本颜色设置为红色
	        ::SetBkColor(dc,RGB(0,0,255));//文本背景颜色设置为蓝色
	            TextOut(dc,0,0,"love you",8);
	            Sleep(1000);
	            SetTextColor(dc,RGB(0,255,0));//文本颜色设置为黄色
	        ::SetBkColor(dc,RGB(255,0,0));//文本背景颜色设置为红色
	        TextOut(dc,0,0,"love",4);
	        Sleep(1000);
	        }
	        return FALSE;
        */
        /// <summary>
        /// 获取整个窗口(包括边框、滚动条、标题栏、菜单等)的设备场景,用完后一定要用ReleaseDC函数释放场景
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        /// <summary>
        /// 函数释放设备上下文环境（DC）供其他应用程序使用.
        /// 函数的效果与设备上下文环境类型有关.它只释放公用的和设备上下文环境，对于类或私有的则无效.
        /// </summary>
        /// <param name="hWnd">指向要释放的设备上下文环境所在的窗口的句柄</param>
        /// <param name="hDC">指向要释放的设备上下文环境的句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        /// <summary>
        /// 返回与指定窗口有特定关系(如Z序或所有者)的窗口句柄.
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="uCmd">说明指定窗口与要获得句柄的窗口之间的关系<see cref="WinAPI.Enums.GetWindowEnums"/></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowEnums uCmd);

        /// <summary>
        /// 返回指定窗口的显示状态以及被恢复的、最大化的和最小化的窗口位置
        /// 在调用GetWindowPlacement函数之前，将WINDOWPLACEMENT结构的长度设为Marshal.SizeOf(WINDOWPLACEMENT)
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpwndpl">该结构存贮显示状态和位置信息</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        /// <summary>
        /// 返回指定窗口的边框矩形的尺寸.该尺寸以相对于屏幕坐标左上角的屏幕坐标给出.
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="rect">rect结构<see cref="WinAPI.Struct.RECT"/></param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);
        /// <summary>
        /// 将指定窗口的标题条文本(如果存在)拷贝到一个缓存区内.
        /// 如果指定的窗口是一个控件，则拷贝控件的文本.
        /// </summary>
        /// <param name="hWnd">窗口或控件的句柄</param>
        /// <param name="lpString">指向接收文本的缓冲区的指针</param>
        /// <param name="nMaxCount">指定要保存在缓冲区内的字符的最大个数,其中包含NULL字符.如果文本超过界限,它就被截断.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);


        public static string GetWindowText(IntPtr hWnd)
        {
            Debug.Assert(hWnd != IntPtr.Zero);
            StringBuilder WindowText = new StringBuilder(GetWindowTextLength(hWnd) + 1);
            GetWindowText(hWnd, WindowText, WindowText.Capacity);
            return WindowText.ToString();
        }
        /// <summary>
        /// 窗口的标题条文本长度或者控件文本长度.
        /// </summary>
        /// <param name="hWnd">窗口或控件的句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        /// <summary>
        /// 获得指定窗口句柄的进程ID
        /// </summary>
        /// <param name="handle">窗口句柄</param>
        /// <param name="processId">存放进程ID的变量</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr handle, ref IntPtr processId);
        /// <summary>
        /// 向指定的窗体添加一个矩形,然后窗口客户区域的这一部分将被重新绘制.
        /// </summary>
        /// <param name="hWnd">要更新的客户区所在的窗体的句柄.如果为NULL,则系统将在函数返回前重新绘制所有的窗口, 然后发送 WM_ERASEBKGND 和 WM_NCPAINT 给窗口过程处理函数.</param>
        /// <param name="rect">如果为null，全部的窗口客户区域将被增加到更新区域中</param>
        /// <param name="bErase">是否重画该区域，重画时用预先定义好的画刷。当指定true时需要重画</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public extern static int InvalidateRect(IntPtr hWnd, IntPtr rect, bool bErase);
        /// <summary>
        /// 测试一个窗口是否是指定父窗口的子窗口或后代窗口.
        /// </summary>
        /// <param name="hWndParent">父窗口句柄</param>
        /// <param name="hWnd">将被测试的窗口句柄</param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);
        /// <summary>
        /// 确定给定的窗口句柄是否识别一个已存在的窗口.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowEnabled(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        /// <summary>
        /// 该函数合成一次击键事件.
        /// </summary>
        /// <param name="bVk">定义一个虚拟键码。键码值必须在1～254之间.<see cref="WinAPI.Enums.VirtualKey"/></param>
        /// <param name="bScan">按键的硬件扫描码,一般是0.</param>
        /// <param name="dwFlags">定义函数操作的各个方面的一个标志位集.<see cref="WinAPI.Enums.KeyEvent"/></param>
        /// <param name="dwExtraInfo">定义与击键相关的附加的32位值,一般是0.</param>
        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void Keybd_event(VirtualKey bVk, byte bScan, KeyEvent dwFlags, uint dwExtraInfo);
        /// <summary>
        /// 从一个与应用事例相关的可执行文件（EXE文件）中载入指定的光标资源.  
        /// </summary>
        /// <param name="hInstance">标识一个模块事例，它的可执行文件包含要载入的光标.</param>
        /// <param name="cursor">鼠标名字</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
        /// <summary>
        /// 模拟鼠标移动,鼠标点击.
        /// </summary>
        /// <param name="dwFlags">鼠标事件</param>
        /// <param name="dx">指定x轴绝对坐标或相对坐标</param>
        /// <param name="dy">指定y轴绝对坐标或相对坐标</param>
        /// <param name="dwData">0</param>
        /// <param name="dwExtraInfo">0</param>
        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        public static extern void MouseEvent(MouseEventType dwFlags, int dx, int dy, uint dwData, uint dwExtraInfo);
        /// <summary>
        /// 改变指定窗口的位置和尺寸.
        /// 对于顶层窗口,位置和尺寸是相对于屏幕的左上角的.
        /// 对于子窗口,位置和尺寸是相对于父窗口客户区的左上角坐标的.
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="repaint"></param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
        /// <summary>
        /// 打开剪贴板.
        /// </summary>
        /// <param name="hWndNewOwner">窗口句柄.</param>
        /// <returns>布尔值.</returns>
        [DllImport("user32.dll")]
        static public extern bool OpenClipboard(IntPtr hWndNewOwner);
        /// <summary>
        /// 该函数将一个消息放入到与指定窗口创建的线程相联系消息队列里.
        /// </summary>
        /// <param name="hWnd">窗口句柄.</param>
        /// <param name="wMsg">指定被寄送的消息.<see cref="WinAPI.Enums.WindowMessage"/></param>
        /// <param name="wParam">指定附加的消息特定的信息.</param>
        /// <param name="lParam">指定附加的消息特定的信息.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// 一个消息放入(寄送)到指定线程的消息队列里,不等待线程处理消息就返回.
        /// </summary>
        /// <param name="threadId">其消息将被寄送的线程的线程标识符.</param>
        /// <param name="msg">指定将被寄送的消息的类型</param>
        /// <param name="wParam">指定附加的消息特定信息.</param>
        /// <param name="lParam">指定附加的消息特定信息.</param>
        /// <returns>布尔值.</returns>
        [DllImport("user32.dll")]
        public static extern bool PostThreadMessage(uint threadId, int msg, UIntPtr wParam, IntPtr lParam);
        /// <summary>
        /// 根据fuRedraw旗标的设置，重画全部或部分窗口
        /// </summary>
        /// <param name="hwnd">要重画的窗口的句柄。零表示更新桌面窗口</param>
        /// <param name="rcUpdate">窗口中需要重画的一个矩形区域</param>
        /// <param name="hrgnUpdate">一个“区”的句柄，这个区描述了要重画的窗口区域</param>
        /// <param name="flags">规定具体重画操作的旗标。</param>
        /// <returns>非零表示成功，零表示失败。会设置GetLastError</returns>
        [DllImportAttribute("user32.dll", EntryPoint = "RedrawWindow")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, FuRedraw flags);
        /// <summary>
        /// 定义一个系统范围的热键.
        /// </summary>
        /// <param name="hWnd">接收热键产生WM_HOTKEY消息的窗口句柄.</param>
        /// <param name="id">定义热键的标识符.</param>
        /// <param name="fsModifiers">定义为了产生WM_HOTKEY消息而必须与由nVirtKey参数定义的键一起按下的键.<see cref="WinAPI.Enums.WMHotKeys"/></param>
        /// <param name="vk">定义热键的虚拟键码.</param>
        /// <returns>布尔值.</returns>
        [DllImport("user32.dll", EntryPoint = "RegisterHotKey")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, WMHotKeys fsModifiers, VirtualKey vk);
        /// <summary>
        /// 释放调用线程先前登记的热键.
        /// </summary>
        /// <param name="hWnd">注册热键的窗口句柄.</param>
        /// <param name="id">热键编号上面注册热键的编号.</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "UnregisterHotKey")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        /// <summary>
        /// 从当前线程中的窗口释放鼠标捕获,并恢复通常的鼠标输入处理.捕获鼠标的窗口接收所有的鼠标输入(无论光标的位置在哪里),
        /// 除非点击鼠标键时,光标热点在另一个线程的窗口中.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        /// <summary>
        /// 把屏幕上指定点的屏幕坐标转换成用户坐标.
        /// </summary>
        /// <param name="handle">指向窗口的句柄，此窗口的用户空间将被用来转换.</param>
        /// <param name="point">该结构含有要转换的屏幕坐标.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr handle, ref tagPoint point);
        /// <summary>
        /// 该函数滚动指定窗体客户区域的目录.
        /// </summary>
        /// <param name="hWnd">客户区域将被滚动的窗体句柄.</param>
        /// <param name="dx">在设备单元中,指定水平滚动数量.在向左滚动时此参数必须为负.</param>
        /// <param name="dy">在设备单元中,指定垂直滚动数量.在向上滚动时此参数必须为负.</param>
        /// <param name="rcScroll">指向RECT结构，它指定了将被滚动的客户区域部分.</param>
        /// <param name="rcClip">指向包含了类似于被剪下矩形的RECT结构.只有在剪下内部的小块图形才受影响.从矩形外向内部的滚动部分将被着色.而从内向外的滚动部分将不再被着色.</param>
        /// <param name="UpdateRegion">处理已被修改的区域,保存这些由于滚动而无效的区域.此参数可以为空.</param>
        /// <param name="rcInvalidated">指向RECT结构,它接收由于滚动使得矩形无效部分的边界.此参数值可以为空.</param>
        /// <param name="flags">指定控制滚动的标志.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, ref RECT rcScroll, ref RECT rcClip, IntPtr UpdateRegion, ref RECT rcInvalidated, uint flags);
        /// <summary>
        /// 模拟键盘按键,鼠标移动,鼠标点击.
        /// 并不重置键盘当前的按键状态,这意味着如果当用户正在按着某个键的时候模拟输入事件此函数将受到影响.
        /// </summary>
        /// <param name="numberOfInputs">模拟事件的数量</param>
        /// <param name="inputs">INPUT结构数组,每一个结构描述一个事件</param>
        /// <param name="sizeOfInputStructure">INPUT结构的字节大小,如果设置错误将导致函数失败</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern UInt32 SendInput(UInt32 numberOfInputs, INPUT[] inputs, Int32 sizeOfInputStructure);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="wMsg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessageA(IntPtr hwnd, int wMsg, int wParam, int lParam);
        /// <summary>
        /// 将存放有数据的内存块放入剪切板的资源管理中
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardData(uint Format, IntPtr hData);
        /// <summary>
        /// 加此窗口到通知窗口链(通过 WM_DRAWCLIPBOARD 消息)，发生更改时剪贴板的内容.
        /// </summary>
        /// <param name="hWndNewViewer">窗口句柄.</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        /// <summary>
        /// 该函数确定光标的形状.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr hCursor);
        /// <summary>
        /// 设定鼠标位置相对于桌面.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);
        /// <summary>
        /// 对指定的窗口设置键盘焦点.
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetFocus(IntPtr hwnd);
        /// <summary>
        /// 创建指定窗口的线程设置到前台,并且激活该窗口.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static public extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        /// <summary>
        /// 该函数改变指定子窗口的父窗口.
        /// </summary>
        /// <param name="hChild">子窗口句柄.</param>
        /// <param name="hParent">父窗口句柄.</param>
        /// <returns></returns>
        [DllImport("User32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        /// Return Type: HWND->HWND__*
        ///hWnd: HWND->HWND__*
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetActiveWindow")]
        public static extern System.IntPtr SetActiveWindow([System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd);
        /// <summary>
        /// 该函数改变指定窗口的属性,也将指定的一个32位值设置在窗口的额外存储空间的指定偏移位置.
        /// </summary>
        /// <param name="hWnd">窗口句柄.</param>
        /// <param name="nIndex">指定将设定的大于等于0的偏移值.</param>
        /// <param name="dwNewLong">指定的替换值.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        /// <summary>
        /// 设置指定窗口的显示状态和恢复，最大化，最小化位置
        /// </summary>
        /// <param name="hWnd">窗口句柄.</param>
        /// <param name="lpwndpl"><see cref="WinAPI.Struct.WINDOWPLACEMENT"/></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        /// <summary>
        /// 改变一个子窗口,弹出式窗口式顶层窗口的尺寸,位置和Z序.
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="hWndInsertAfter">在z序中的位于被置位的窗口前的窗口句柄<see cref="WinAPI.Enums.HWND"/></param>
        /// <param name="x">以客户坐标指定窗口新位置的左边界</param>
        /// <param name="y">以客户坐标指定窗口新位置的顶边界</param>
        /// <param name="Width">以像素指定窗口的新的宽度</param>
        /// <param name="Height">以像素指定窗口的新的高度</param>
        /// <param name="flags">窗口尺寸和定位的标志<see cref="WinAPI.Enums.HWND"/></param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, SetWindowPosFlags flags);
        /// <summary>
        /// 设置了一个窗口的区域.只有被包含在这个区域内的地方才会被重绘,而不包含在区域内的其他区域系统将不会显示
        /// </summary>
        /// <param name="hWnd">窗口的句柄</param>
        /// <param name="hRgn">指向的区域.函数起作用后将把窗体变成这个区域的形状.如果这个参数是空值,窗体区域也会被设置成空值,也就是什么也看不到</param>
        /// <param name="redraw">是否重绘</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
        /// <summary>
        /// 设置钩子,第二个参数为回调函数指针
        /// </summary>
        /// <param name="idHook">钩子的类型，即它处理的消息类型</param>
        /// <param name="lpfn">钩子函数的入口地址.当钩子钩到任何消息后便调用这个函数。如果dwThreadId参数为0,lpfn必须指向DLL中的钩子子程,除此以外，lpfn可以指向当前进程的一段钩子子程代码</param>
        /// <param name="hmod">应用程序实例的句柄</param>
        /// <param name="dwThreadId">与安装的钩子子程相关联的线程的标识符,如果为0，钩子子程与所有的线程关联，即为全局(系统)钩子</param>
        /// <returns>若此函数执行成功,则返回值就是该挂钩处理过程的句柄;若此函数执行失败,则返回值为NULL(0).若想获得更多错误信息,请调用GetLastError函数.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(IdHook idHook, HOOKPROC lpfn, IntPtr hmod, uint dwThreadId);
        /// <summary>
        /// 调用下一个钩子，一个钩子程序可以调用这个函数之前或之后处理钩子信息
        /// </summary>
        /// <param name="hhk">当前钩子的句柄</param>
        /// <param name="nCode">钩子代码; 就是给下一个钩子要交待的</param>
        /// <param name="wParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <param name="lParam">要传递的参数; 由钩子类型决定是什么参数</param>
        /// <returns> 返回这个值链中的下一个钩子程序</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <param name="hHook">当前钩子的句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);
        /// <summary>
        /// 改变指定窗口的标题栏的文本内容
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="text">标题栏的文本内容</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, string text);
        /// <summary>
        /// 显示或隐藏所指定的滚动条
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="bar">指定滚动条是被显示还是隐藏</param>
        /// <param name="bShow">指定滚动条是被显示还是隐藏。</param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool ShowScrollBar(IntPtr hWnd, ScrollBar bar, bool bShow);
        /// <summary>
        /// 设置指定窗口的显示状态
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="nCmdShow">指定窗口如何显示<see cref="WinAPI.Enums.GetDCEx"/></param>
        /// <returns>布尔值</returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCmd nCmdShow);
        /// <summary>
        /// 该函数将指定的虚拟键码和键盘状态翻译为相应的字符或字符串。
        /// 该函数使用由给定的键盘布局句柄标识的物理键盘布局和输入语言来翻译代码。
        /// </summary>
        /// <param name="uVirtKey">指定要翻译的虚拟键码</param>
        /// <param name="uScanCode">定义被翻译键的硬件扫描码</param>
        /// <param name="lpKeyState">指向包含当前键盘状态的一个256字节数组</param>
        /// <param name="lpChar">指向接受翻译所得字符或字符串的缓冲区</param>
        /// <param name="uFlags">定义一个菜单是否处于激活状态1或0</param>
        /// <returns>0没有翻译,1一个字符被拷贝到缓冲区,2两个字符被拷贝到缓冲区</returns>
        [DllImport("user32.dll", EntryPoint = "ToAscii")]
        public static extern int ToAscii(VirtualKey uVirtKey, uint uScanCode, IntPtr lpKeyState, out ushort lpChar, uint uFlags);
        /// <summary>
        /// 该函数将指定的虚拟键码和键盘状态翻译为相应的字符或字符串。该函数使用由给定的键盘布局句柄标识的物理键盘布局和输入语言来翻译代码。
        /// </summary>
        /// <param name="uVirtKey">指定要翻译的虚拟键码</param>
        /// <param name="uScanCode">定义被翻译键的硬件扫描码</param>
        /// <param name="lpKeyState">指向包含当前键盘状态的一个256字节数组</param>
        /// <param name="lpChar">指向接受翻译所得字符或字符串的缓冲区</param>
        /// <param name="uFlags">定义一个菜单是否处于激活状态</param>
        /// <param name="dwhkl">翻译给定代码所使用的键盘布局的句柄。该参数可以是先前LoadKeyboardLayout函数返回的键盘布局句柄。</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ToAsciiEx")]
        public static extern int ToAsciiEx(VirtualKey uVirtKey, uint uScanCode, IntPtr lpKeyState, out ushort lpChar, uint uFlags, IntPtr dwhkl);
        /// <summary>
        /// 该函数给系统中装入一种新的键盘布局，可以同时装入几种不同的键盘布局，
        /// 任一时刻仅有一个进程是活动的，装入多个键盘布局使得在多种布局间快速切换。    
        /// </summary>
        /// <param name="pwszKLID">缓冲区中的存放装入的键盘布局名称</param>
        /// <param name="Flags">指定如何装入键盘布局</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "LoadKeyboardLayout")]
        public static extern IntPtr LoadKeyboardLayout([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPWStr)] string pwszKLID, uint Flags);
        /// <summary>
        /// 通过发送重绘消息 WM_PAINT 给目标窗体来更新目标窗体客户区的无效区域
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);
        /// <summary>
        /// 该函数产生对其他线程的控制，如果一个线程没有其他消息在其消息队列里。
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool WaitMessage();
        /// <summary>
        /// 该函数获得包含指定点的窗口的句柄。
        /// </summary>
        /// <param name="point"></param>
        /// <returns>包含该点的窗口的句柄</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(tagPoint point);
        /// <summary>
        /// 该函数确定属于父窗口的哪一个子窗口（如果存在的话）包含着指定的点。
        /// 该函数可以忽略不可见的、禁止的和透明的子窗口。
        /// 系统有一个与某一父窗口有联系的所有子窗口的内部列表。列表中的句柄顺序依据这些子窗口的Z序。
        /// 如果有多于一个的子窗口包含该点，那么系统返回在列表中包含该点并且满足由uFlags定义的规则的第一个窗口的句柄。
        /// </summary>
        /// <param name="hWndParent">父窗口句柄</param>
        /// <param name="pt">指定一个POINT结构，该结构定义了被检查的点的坐标。</param>
        /// <param name="uFlags">指明忽略的子窗口的类型。可以是下列参数组合.CWP_ALL,CWP_SKIPINVISIBLE,CWP_SKIPDISABLE,CWP_SKIPTRABSPARENT。</param>
        /// <returns>返回值为包含该点并且满足由uFlags定义的规则的第一个子窗口的句柄。如果该点在父窗口内，但在任一满足条件的子窗口外，则返回值为父窗口句柄。如果该点在父窗口之外或函数失败，则返回值为NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr hWndParent, tagPoint pt, CWP uFlags);
        [DllImport("user32.dll", EntryPoint = "RealChildWindowFromPoint")]
        public static extern IntPtr RealChildWindowFromPoint(IntPtr hwndParent, tagPoint ptParentClientCoords);
        /// <summary>
        /// 枚举与指定桌面相关联的所有顶级窗口。它把每个窗口的句柄，依次传递到应用程序定义回调函数
        /// </summary>
        /// <param name="hDesktop">要枚举其顶级窗口的桌面句柄，此句柄由CreateDesktop、 GetThreadDesktop、 OpenDesktop或OpenInputDesktop函数返回。并且必须拥有 DESKTOP_READOBJECTS 的访问权</param>
        /// <param name="lpfn">应用程序定义的EnumWindowsProc的回调函数的指针</param>
        /// <param name="lParam">要传递给回调函数应用程序定义的值</param>
        /// <returns>布尔值</returns>
        [DllImportAttribute("user32.dll", EntryPoint = "EnumDesktopWindows")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows([InAttribute()] IntPtr hDesktop, EnumWindowsProc lpfn, [MarshalAsAttribute(UnmanagedType.SysInt)] IntPtr lParam);
        /// Return Type: void
        ///dwMilliseconds: DWORD->unsigned int
        [DllImportAttribute("kernel32.dll", EntryPoint = "Sleep")]
        public static extern void Sleep(int dwMilliseconds);
        /// Return Type: BOOL->int
        ///lpPoint: LPPOINT->tagPOINT*
        [DllImportAttribute("user32.dll", EntryPoint = "GetCursorPos")]
        public static extern bool GetCursorPos(out System.Drawing.Point pt);
        /// <summary>
        /// 取得某窗口的DC图片
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hdcBlt">DC句柄</param>
        /// <param name="nFlags">0</param>
        /// <returns></returns>
        [DllImportAttribute("user32.dll", EntryPoint = "PrintWindow")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);
        [DllImportAttribute("user32.dll", EntryPoint = "VkKeyScanW")]
        public static extern short VkKeyScan(char ch);
        #endregion
        [DllImportAttribute("Dbghelp.dll", EntryPoint = "MakeSureDirectoryPathExists")]
        public static extern bool MakeSureDirectoryPathExists(string DirPath);
        [DllImport("sensapi.dll")]
        public static extern bool IsNetworkAlive(out int connectionDescription);
        [DllImport("ws2_32.dll")]
        public static extern bool GetSockName(string rSocketAddress, int rSocketPort);
        [DllImport("ws2_32.dll")]
        public static extern bool Create(int nSocketPort, int nSocketType, string lpszSocketAddress);
        [DllImport("ws2_32.dll")]
        public static extern bool Close();
        [DllImport("ws2_32.dll")]
        public static extern int Receive(StringBuilder lpBuf, int nBufLen, int nFlags);
        [DllImport("ws2_32.dll")]
        public static extern int SendTo(StringBuilder lpBuf, int nBufLen, int nHostPort, string lpszHostAddress, int nFlags);

    }

}
