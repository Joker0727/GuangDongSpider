using System;
using System.Collections.Generic;
using System.Text;

namespace GTR
{
    public enum CWP : uint
    {
        /// <summary>
        /// 不忽略任一子窗口
        /// </summary>
        CWP_ALL = 0x0000,
        /// <summary>
        /// 忽略不可见的子窗口
        /// </summary>
        CWP_SKIPINVISIBLE = 0x0001,
        /// <summary>
        /// 忽略禁止的子窗口
        /// </summary>
        CWP_SKIPDISABLED = 0x0002,
        /// <summary>
        /// 忽略透明子窗口
        /// </summary>
        CWP_SKIPTRANSPARENT = 0x0004
    }

    public enum FileInfoFlags : int
    {
        /// <summary>
        /// 获得图标
        /// </summary>
        SHGFI_ICON = 0x000000100,
        /// <summary>
        /// 显示名
        /// </summary>
        SHGFI_DISPLAYNAME = 0x000000200,     // get display name
        /// <summary>
        /// 类型名
        /// </summary>
        SHGFI_TYPENAME = 0x000000400,     // get type name
        /// <summary>
        /// 属性
        /// </summary>
        SHGFI_ATTRIBUTES = 0x000000800,     // get attributes
        /// <summary>
        /// 本地图标
        /// </summary>
        SHGFI_ICONLOCATION = 0x000001000,     // get icon location
        SHGFI_EXETYPE = 0x000002000,     // return exe type
        /// <summary>
        /// 系统图标列表
        /// </summary>
        SHGFI_SYSICONINDEX = 0x000004000,     // get system icon index
        SHGFI_LINKOVERLAY = 0x000008000,     // put a link overlay on icon
        SHGFI_SELECTED = 0x000010000,     // show icon in selected state
        SHGFI_ATTR_SPECIFIED = 0x000020000,     // get only specified attributes
        /// <summary>
        /// 大图标
        /// </summary>
        SHGFI_LARGEICON = 0x000000000,     // get large icon
        /// <summary>
        /// 小图标
        /// </summary>
        SHGFI_SMALLICON = 0x000000001,     // get small icon

        SHGFI_OPENICON = 0x000000002,     // get open icon
        SHGFI_SHELLICONSIZE = 0x000000004,     // get shell size icon
        /// <summary>
        /// pszPath是一个标识符
        /// </summary>
        SHGFI_PIDL = 0x000000008,     // pszPath is a pidl
        /// <summary>
        /// 不会访问第一个参数所指定的文件，使函数认为在pszPath参数中传递的文件是存在的，此时，它可以获得扩展名，并且搜索注册表来得到图标和类型名信息。
        /// </summary>
        SHGFI_USEFILEATTRIBUTES = 0x000000010,     // use passed dwFileAttribute

        SHGFI_ADDOVERLAYS = 0x000000020,     // apply the appropriate overlays
        SHGFI_OVERLAYINDEX = 0x000000040,     // Get the index of the overlay
    }

    public enum GetDCEx : uint
    {
        DCX_WINDOW = 0x00000001,
        DCX_CACHE = 0x00000002,
        DCX_NORESETATTRS = 0x00000004,
        DCX_CLIPCHILDREN = 0x00000008,
        DCX_CLIPSIBLINGS = 0x00000010,
        DCX_PARENTCLIP = 0x00000020,
        DCX_EXCLUDERGN = 0x00000040,
        DCX_INTERSECTRGN = 0x00000080,
        DCX_EXCLUDEUPDATE = 0x00000100,
        DCX_INTERSECTUPDATE = 0x00000200,
        DCX_LOCKWINDOWUPDATE = 0x00000400,
        DCX_VALIDATE = 0x00200000
    }

    public enum GetWindowEnums : uint
    {
        /// <summary>
        /// 给定窗口的第一个同属窗口
        /// </summary>
        GW_HWNDFIRST = 0,
        /// <summary>
        /// 给定窗口的最后一个同属窗口
        /// </summary>
        GW_HWNDLAST = 1,
        /// <summary>
        /// 给定窗口的下面窗口的句柄.
        /// </summary>
        GW_HWNDNEXT = 2,
        /// <summary>
        /// 给定窗口的上面窗口的句柄.
        /// </summary>
        GW_HWNDPREV = 3,
        /// <summary>
        /// 给定窗口的所有者窗口句柄.
        /// </summary>
        GW_OWNER = 4,
        /// <summary>
        /// 给定窗口的第一个子窗口句柄.
        /// </summary>
        GW_CHILD = 5,
        /// <summary>
        /// （WindowsNT 5.0）返回的句柄标识了属于指定窗口的处于Enable状态弹出式窗口。
        /// （检索使用第一个由GW_HWNDNEXT 查找到的满足前述条件的窗口）.
        /// 如果无Enable窗口，则获得的句柄与指定窗口相同。
        /// </summary>
        GW_ENABLEDPOPUP = 6
    }

    public class HWndlnsertAfter
    {
        /// <summary>
        /// 将窗口置于所有非顶层窗口之上（即在所有顶层窗口之后）。如果窗口已经是非顶层窗口则该标志不起作用。
        /// </summary>
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        /// <summary>
        /// 将窗口置于所有非顶层窗口之上。即使窗口未被激活窗口也将保持顶级位置。
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        /// <summary>
        /// 将窗口置于Z序的顶部。
        /// </summary>
        public static readonly IntPtr HWND_TOP = new IntPtr(0);
        /// <summary>
        /// 将窗口置于Z序的底部。如果参数hWnd标识了一个顶层窗口，则窗口失去顶级位置，并且被置在其他窗口的底部。
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
    }

    public enum SetWindowPosFlags : uint
    {
        /// <summary>
        /// 维持当前尺寸（忽略cx和Cy参数）。
        /// </summary>
        SWP_NOSIZE = 0x0001,
        /// <summary>
        /// 维持当前位置（忽略X和Y参数）。
        /// </summary>
        SWP_NOMOVE = 0x0002,
        /// <summary>
        /// 维持当前Z序（忽略hWndlnsertAfter参数）。
        /// </summary>
        SWP_NOZORDER = 0x0004,
        /// <summary>
        /// 不重画改变的内容。如果设置了这个标志，则不发生任何重画动作。
        /// 适用于客户区和非客户区（包括标题栏和滚动条）和任何由于窗回移动而露出的父窗口的所有部分。
        /// 如果设置了这个标志，应用程序必须明确地使窗口无效并区重画窗口的任何部分和父窗口需要重画的部分。
        /// </summary>
        SWP_NOREDRAW = 0x0008,
        /// <summary>
        /// 不激活窗口。如果未设置标志，则窗口被激活，并被设置到其他最高级窗口或非最高级组的顶部（根据参数hWndlnsertAfter设置）。
        /// </summary>
        SWP_NOACTIVATE = 0x0010,
        /// <summary>
        /// 给窗口发送WM_NCCALCSIZE消息，即使窗口尺寸没有改变也会发送该消息。如果未指定这个标志，只有在改变了窗口尺寸时才发送WM_NCCALCSIZE。
        /// </summary>
        SWP_FRAMECHANGED = 0x0020,  /* The frame changed: send WM_NCCALCSIZE */
        /// <summary>
        /// 显示窗口。
        /// </summary>
        SWP_SHOWWINDOW = 0x0040,
        /// <summary>
        /// 隐藏窗口。
        /// </summary>
        SWP_HIDEWINDOW = 0x0080,
        /// <summary>
        /// 清除客户区的所有内容。如果未设置该标志，客户区的有效内容被保存并且在窗口尺寸更新和重定位后拷贝回客户区。
        /// </summary>
        SWP_NOCOPYBITS = 0x0100,
        /// <summary>
        /// 不改变z序中的所有者窗口的位置。
        /// </summary>
        SWP_NOOWNERZORDER = 0x0200,  /* Don't do owner Z ordering */
        /// <summary>
        /// 防止窗口接收WM_WINDOWPOSCHANGING消息。
        /// </summary>
        SWP_NOSENDCHANGING = 0x0400,  /* Don't send WM_WINDOWPOSCHANGING */
        /// <summary>
        /// 在窗口周围画一个边框（定义在窗口类描述中）。
        /// </summary>
        SWP_DRAWFRAME = SWP_FRAMECHANGED,
        /// <summary>
        /// 与SWP_NOOWNERZORDER标志相同。
        /// </summary>
        SWP_NOREPOSITION = SWP_NOOWNERZORDER,
        /// <summary>
        /// 防止产生WM_SYNCPAINT消息。
        /// </summary>
        SWP_DEFERERASE = 0x2000,
        /// <summary>
        /// 如果调用进程不拥有窗口，系统会向拥有窗口的线程发出需求。这就防止调用线程在其他线程处理需求的时候发生死锁。
        /// </summary>
        SWP_ASYNCWINDOWPOS = 0x4000
    }
    /// <summary>
    /// RedrawWindow() flags
    /// 如针对桌面窗口应用这个函数，则应用程序必须用RDW_ERASE旗标重画桌面
    /// </summary>
    public enum FuRedraw : uint
    {
        /// <summary>
        ///  禁用（屏蔽）重画区域
        /// </summary>
        RDW_INVALIDATE         = 0x0001,
        /// <summary>
        /// 即使窗口并非无效，也向其投递一条WM_PAINT消息
        /// </summary>
        RDW_INTERNALPAINT      = 0x0002,
        /// <summary>
        /// 重画前，先清除重画区域的背景。也必须指定RDW_INVALIDATE
        /// </summary>
        RDW_ERASE              = 0x0004,
        /// <summary>
        /// 检验重画区域
        /// </summary>
        RDW_VALIDATE           = 0x0008,
        /// <summary>
        /// 禁止内部生成或由这个函数生成的任何待决WM_PAINT消息。针对无效区域，仍会生成WM_PAINT消息
        /// </summary>
        RDW_NOINTERNALPAINT    = 0x0010,
        /// <summary>
        /// 禁止删除重画区域的背景
        /// </summary>
        RDW_NOERASE            = 0x0020,
        /// <summary>
        /// 重画操作排除子窗口（前提是它们存在于重画区域）
        /// </summary>
        RDW_NOCHILDREN         = 0x0040,
        /// <summary>
        /// 重画操作包括子窗口（前提是它们存在于重画区域）
        /// </summary>
        RDW_ALLCHILDREN        = 0x0080,
        /// <summary>
        /// 立即更新指定的重画区域
        /// </summary>
        RDW_UPDATENOW          = 0x0100,
        /// <summary>
        /// 立即删除指定的重画区域
        /// </summary>
        RDW_ERASENOW           = 0x0200,
        /// <summary>
        /// 如非客户区包含在重画区域中，则对非客户区进行更新。也必须指定RDW_INVALIDATE
        /// </summary>
        RDW_FRAME              = 0x0400,
        /// <summary>
        /// 禁止非客户区域重画（如果它是重画区域的一部分）。也必须指定RDW_VALIDATE
        /// </summary>
        RDW_NOFRAME            = 0x0800
    }

    public enum IdHook : int
    {
        WH_MIN = -1,
        /// <summary>
        /// 只能监视传递到菜单，滚动条，消息框的消息，以及传递到通过安装了Hook子程的应用程序建立的对话框的消息。
        /// </summary>
        WH_MSGFILTER = -1,
        /// <summary>
        /// 用来监视和记录输入事件。典型的，可以使用这个Hook记录连续的鼠标和键盘事件，然后通过使用WH_JOURNALPLAYBACK Hook来回放。
        /// </summary>
        WH_JOURNALRECORD = 0,
        /// <summary>
        /// 使应用程序可以插入消息到系统消息队列。
        /// 可以使用这个Hook回放通过使用WH_JOURNALRECORD Hook记录下来的连续的鼠标和键盘事件。
        /// 只要WH_JOURNALPLAYBACK Hook已经安装，正常的鼠标和键盘事件就是无效的。
        /// WH_JOURNALPLAYBACK Hook是全局Hook，它不能象线程特定Hook一样使用。
        /// </summary>
        WH_JOURNALPLAYBACK = 1,
        /// <summary>
        /// WH_KEYBOARD Hook用来监视WM_KEYDOWN and WM_KEYUP消息，这些消息通过GetMessage or PeekMessage function返回。
        /// 可以使用这个Hook来监视输入到消息队列中的键盘消息。
        /// </summary>
        WH_KEYBOARD = 2,
        /// <summary>
        /// 当调用GetMessage 或 PeekMessage时
        /// 你可以使用WH_GETMESSAGE Hook去监视鼠标和键盘输入，以及其他发送到消息队列中的消息。
        /// </summary>
        WH_GETMESSAGE = 3,
        /// <summary>
        /// 监视发送到窗口过程的消息,消息发送到接收窗口过程之前调用
        /// 当调用SendMessage时
        /// </summary>
        WH_CALLWNDPROC = 4,
        /// <summary>
        /// 激活，建立，销毁，最小化，最大化，移动，改变尺寸等窗口事件之前
        /// 完成系统指令之前
        /// 来自系统消息队列中的移动鼠标，键盘事件之前
        /// 设置输入焦点事件之前
        /// 同步系统消息队列事件之前
        /// </summary>
        WH_CBT = 5,
        /// <summary>
        /// 监视所有应用程序消息。
        /// </summary>
        WH_SYSMSGFILTER = 6,
        /// <summary>
        /// 监视从GetMessage 或者 PeekMessage 函数返回的鼠标消息。
        /// 使用这个Hook监视输入到消息队列中的鼠标消息。
        /// </summary>
        WH_MOUSE = 7,
        /// <summary>
        /// 当调用GetMessage 或 PeekMessage 来从消息队列种查询非鼠标、键盘消息时
        /// </summary>
        WH_HARDWARE = 8,
        /// <summary>
        /// 在系统调用系统中与其他Hook关联的Hook子程之前
        /// </summary>
        WH_DEBUG = 9,
        /// <summary>
        /// 外壳应用程序可以使用WH_SHELL Hook去接收重要的通知。
        /// 当外壳应用程序是激活的并且当顶层窗口建立或者销毁时，系统调用WH_SHELL Hook子程。
        /// 只要有个top-level、unowned 窗口被产生、起作用、或是被摧毁;
        /// 当Taskbar需要重画某个按钮;
        /// 当系统需要显示关于Taskbar的一个程序的最小化形式;
        /// 当如今的键盘布局状态改变;
        /// 当使用者按Ctrl+Esc去执行Task Manager（或相同级别的程序）。
        /// </summary>
        WH_SHELL = 10,
        /// <summary>
        /// 当应用程序的前台线程处于空闲状态时，可以使用WH_FOREGROUNDIDLE Hook执行低优先级的任务。
        /// 当应用程序的前台线程大概要变成空闲状态时，系统就会调用WH_FOREGROUNDIDLE Hook子程
        /// </summary>
        WH_FOREGROUNDIDLE = 11,
        /// <summary>
        /// 当SendMessage的调用返回时
        /// </summary>
        WH_CALLWNDPROCRET = 12,
        /// <summary>
        /// 监视输入到线程消息队列中的键盘消息。
        /// </summary>
        WH_KEYBOARD_LL = 13,
        /// <summary>
        /// 监视输入到线程消息队列中的鼠标消息。
        /// </summary>
        WH_MOUSE_LL = 14,
        WH_MAX = 14,
    }

    /// <summary>
    /// Specifies the type of the input event. This member can be one of the following values. 
    /// </summary>
    public enum InputType : uint // UInt32
    {
        /// <summary>
        /// 鼠标事件.使用mi.
        /// The event is a mouse event. Use the mi structure of the union.
        /// </summary>
        INPUT_MOUSE = 0,

        /// <summary>
        /// 键盘事件.使用ki.
        /// The event is a keyboard event. Use the ki structure of the union.
        /// </summary>
        INPUT_KEYBOARD = 1,

        /// <summary>
        /// 除了键盘鼠标之外的硬件事件.使用ki
        /// Windows 95/98/Me: The event is from input hardware other than a keyboard or mouse. Use the hi structure of the union.
        /// </summary>
        INPUT_HARDWARE = 2,
    }

    public enum KeyboardLayoutFlags : uint
    {
        /// <summary>
        /// 若指定布局尚未装入，该函数为当前线程装入并激活它
        /// </summary>
        KLF_ACTIVATE = 0x00000001,
        KLF_SUBSTITUTE_OK = 0x00000002,
        /// <summary>
        /// 将指定的活动布局移至内部键盘布局列表的起始处 KLF_REPLACELANG 如指定语言的键盘布局已经存在,则用这个将其替换。
        /// </summary>
        KLF_REORDER = 0x00000008,
        /// <summary>
        /// 若新布局与当前布局有同样的语言标识符，那么新布局替代当前布局作为那种语言的键盘布局，
        /// 若未提供该值，而键盘布局又有同样的标识符，则当前布局不被替换，函数返回NULL值。
        /// </summary>
        KLF_REPLACELANG = 0x00000010,
        /// <summary>
        /// 当装入新的键盘布局时，禁止一个ShellProe过程接收一个HSHELL_LANGUAGE代码。
        /// </summary>
        KLF_NOTELLSHELL = 0x00000080,
        /// <summary>
        /// 与KLF_ACTIVATE一起使用时才有效，为整个进程激活指定键盘布局，
        /// 且发送WM_INPUTLANGCHANGE消息以当前进程的所有线程。典型的LoadKeyboardLayWut仅为当前线程激活一个键盘布局。
        /// </summary>
        KLF_SETFORPROCESS = 0x00000100,
        KLF_SHIFTLOCK = 0x00010000,
        KLF_RESET = 0x40000000
    }

    [Flags]
    public enum KeyEvent : uint
    {
        Zero = 0,

        /// <summary>
        /// 如果指定了,将在扫描码加上前缀0xE0(224).
        /// If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
        /// </summary>
        KEYEVENTF_EXTENDEDKEY = 0x0001,

        /// <summary>
        /// 如果指定了,说明键正在被释放,如果没有指定说明键被按下.
        /// If specified, the key is being released. If not specified, the key is being pressed.
        /// </summary>
        KEYEVENTF_KEYUP = 0x0002,

        /// <summary>
        /// 如果指定了此标志,系统将合成一个VK_PACKET按键,wVK必须为0,此标志只能与KEYEVENTF_KEYUP标志组合.
        /// If specified, wScan identifies the key and wVk is ignored.
        /// </summary>
        KEYEVENTF_UNICODE = 0x0004,

        /// <summary>
        /// :如果指定了此标志,由wScan指定键,忽略wVK.
        /// Windows 2000/XP: If specified, the system synthesizes a VK_PACKET keystroke. The wVk parameter must be zero. This flag can only be combined with the KEYEVENTF_KEYUP flag. For more information, see the Remarks section.
        /// </summary>
        KEYEVENTF_SCANCODE = 0x0008,
    }

    public enum MouseButton
    {
        /// <summary>
        /// 空
        /// </summary>
        None,
        /// <summary>
        /// 左键
        /// </summary>
        Left,
        /// <summary>
        /// 中键
        /// </summary>
        Middle,
        /// <summary>
        /// 右键
        /// </summary>
        Right
    }

    /// <summary>
    /// 可以组合参数
    /// </summary>
    [Flags]
    public enum MouseEventType : uint
    {
        /// <summary>
        /// mouse move
        /// </summary>
        MOUSEEVENTF_MOVE = 0x0001,
        /// <summary>
        /// left button down
        /// </summary>
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        /// <summary>
        /// left button up
        /// </summary>
        MOUSEEVENTF_LEFTUP = 0x0004,
        /// <summary>
        /// right button down
        /// </summary>
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        /// <summary>
        /// right button up
        /// </summary>
        MOUSEEVENTF_RIGHTUP = 0x0010,
        /// <summary>
        /// middle button down
        /// </summary>
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        /// <summary>
        /// right button up
        /// </summary>
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        /// <summary>
        /// x button down
        /// </summary>
        MOUSEEVENTF_XDOWN = 0x0080,
        /// <summary>
        /// x button up
        /// </summary>
        MOUSEEVENTF_XUP = 0x0100,
        /// <summary>
        /// Windows NT/2000/XP:wheel button rolled
        /// </summary>
        MOUSEEVENTF_VERTICALWHEEL = 0x0800,
        /// <summary>
        /// Specifies that the wheel was moved horizontally, if the mouse has a wheel.
        /// The amount of movement is specified in mouseData. 
        /// Windows 2000/XP:  Not supported.
        /// </summary>
        MOUSEEVENTF_HORIZONTALWHEEL = 0x1000,
        /// <summary>
        ///  Windows 2000/XP:map to entire virtual desktop
        /// 坐标与桌面的映射,必须与MOUSEEVENTF_ABSOLUTE组合使用    
        /// </summary>
        MOUSEEVENTF_VIRTUALDESK = 0x4000,
        /// <summary>
        /// absolute move
        /// 如果指定了MOUSEEVENTF_ABSOLUTE,dx,dy将包含0-65535的绝对坐标,它将被映射为显示器的坐标(0,0)表示左上角坐标,(65535,65535)表示右下角坐标
        /// 如果没有指定MOUSEEVENTF_ABSOLUTE,dx,dy将包含相对坐标,正数表示鼠标向右或向下移动,负数表示鼠标向上或向左移动
        /// </summary>
        MOUSEEVENTF_ABSOLUTE = 0x8000

    }

    public enum OBJ : uint
    {
        OBJ_PEN = 1,
        OBJ_BRUSH = 2,
        OBJ_DC = 3,
        OBJ_METADC = 4,
        OBJ_PAL = 5,
        OBJ_FONT = 6,
        OBJ_BITMAP = 7,
        OBJ_REGION = 8,
        OBJ_METAFILE = 9,
        OBJ_MEMDC = 10,
        OBJ_EXTPEN = 11,
        OBJ_ENHMETADC = 12,
        OBJ_ENHMETAFILE = 13,
        OBJ_COLORSPACE = 14
    }

    public enum PenStyles : int
    {
        /// <summary>
        /// 实线
        /// </summary>
        PS_SOLID = 0,
        /// <summary>
        /// 虚线（nWidth必须不大于1）
        /// </summary>
        PS_DASH = 1,
        /// <summary>
        /// 点线（nWidth必须不大于1）
        /// </summary>
        PS_DOT = 2,
        /// <summary>
        /// 划线（nWidth必须不大于1）
        /// </summary>
        PS_DASHDOT = 3,
        /// <summary>
        /// 点-点-划线（nWidth必须不大于1）
        /// </summary>
        PS_DASHDOTDOT = 4,
        /// <summary>
        /// 画笔不能画图
        /// </summary>
        PS_NULL = 5,
        /// <summary>
        /// 由椭圆、矩形、圆角矩形、饼图以及弦等生成的封闭对象框时，画线宽度向内扩展。如指定的准确RGB颜色不存在，就进行抖动处理
        /// </summary>
        PS_INSIDEFRAME = 6,
        /// <summary>
        /// 使用自定义画笔
        /// </summary>
        PS_USERSTYLE = 7,
        /// <summary>
        /// 创建一个设置其他像素的画笔
        /// </summary>
        PS_ALTERNATE = 8
    }

    public enum RopMode : int
    {
        R2_NOT = 6
    }

    public enum ScrollBar : int
    {
        /// <summary>
        /// 显示或隐藏窗体的标准的水平滚动条。
        /// </summary>
        SB_HORZ = 0,
        /// <summary>
        /// 显示或隐藏窗体的标准的垂直滚动条。
        /// </summary>
        SB_VERT = 1,
        /// <summary>
        /// 显示或隐藏滚动条控制。参数hWnd必须是指向滚动条控制的句柄。
        /// </summary>
        SB_CTL = 2,
        /// <summary>
        /// 显示或隐藏窗体的标准的水平或垂直滚动条。
        /// </summary>
        SB_BOTH = 3
    }

    public enum ShowWindowCmd : uint
    {
        /// <summary>
        /// 隐藏窗口并激活其他窗口。
        /// </summary>
        SW_HIDE = 0,
        /// <summary>
        /// 激活并显示一个窗口。如果窗口被最小化或最大化，系统将其恢复到原来的尺寸和大小。应用程序在第一次显示窗口的时候应该指定此标志。
        /// </summary>
        SW_SHOWNORMAL = 1,
        /// <summary>
        /// 正常展现一个窗口。
        /// </summary>
        SW_NORMAL = 1,
        /// <summary>
        /// 激活窗口并将其最小化。
        /// </summary>
        SW_SHOWMINIMIZED = 2,
        /// <summary>
        /// 激活窗口并将其最大化
        /// </summary>
        SW_SHOWMAXIMIZED = 3,
        /// <summary>
        /// 最大化指定的窗口。
        /// </summary>
        SW_MAXIMIZE = 3,
        /// <summary>
        /// 以窗口最近一次的大小和状态显示窗口。激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWNOACTIVATE = 4,
        /// <summary>
        /// 在窗口原来的位置以原来的尺寸激活和显示窗口。
        /// </summary>
        SW_SHOW = 5,
        /// <summary>
        /// 最小化指定的窗口。
        /// </summary>
        SW_MINIMIZE = 6,
        /// <summary>
        /// 窗口最小化，激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,
        /// <summary>
        /// 以窗口原来的状态显示窗口。激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWNA = 8,
        /// <summary>
        /// 激活并显示窗口。如果窗口最小化或最大化，则系统将窗口恢复到原来的尺寸和位置。在恢复最小化窗口时，应用程序应该指定这个标志。
        /// </summary>
        SW_RESTORE = 9,
        /// <summary>
        /// 依据在STARTUPINFO结构中指定的SW_FLAG标志设定显示状态，STARTUPINFO 结构是由启动应用程序的程序传递给CreateProcess函数的。
        /// </summary>
        SW_SHOWDEFAULT = 10,
        /// <summary>
        /// 在WindowNT5.0中最小化窗口，即使拥有窗口的线程被挂起也会最小化。在从其他线程最小化窗口时才使用这个参数。
        /// </summary>
        SW_FORCEMINIMIZE = 11
    }

    public enum StockObjects : int
    {
        NULL_BRUSH = 5
    }

    /// <summary>
    /// 用于得到被定义的系统数据或者系统配置信息
    /// </summary>
    public enum SystemMetrics : int
    {
        /// <summary>
        /// 以像素为单位计算的屏幕尺寸X
        /// X Size of screen
        /// </summary>
        SM_CXSCREEN = 0,
        /// <summary>
        /// 以像素为单位计算的屏幕尺寸Y
        /// Y Size of Screen
        /// </summary>
        SM_CYSCREEN = 1,
        /// <summary>
        /// X Size of arrow in vertical scroll bar
        /// </summary>
        SM_CXVSCROLL = 2,
        /// <summary>
        /// Y Size of arrow in horizontal scroll bar
        /// </summary>
        SM_CYHSCROLL = 3,
        /// <summary>
        /// 以像素计算的普通窗口标题的高度
        /// </summary>
        SM_CYCAPTION = 4,
        /// <summary>
        /// Width of no-sizable borders
        /// </summary>
        SM_CXBORDER = 5,
        /// <summary>
        /// Height of non-sizable borders
        /// </summary>
        SM_CYBORDER = 6,
        /// <summary>
        /// Width of dialog box borders
        /// </summary>
        SM_CXDLGFRAME = 7,
        /// <summary>
        /// Height of dialog box borders
        /// </summary>
        SM_CYDLGFRAME = 8,
        /// <summary>
        /// Height of scroll box on horizontal scroll bar
        /// </summary>
        SM_CYVTHUMB = 9,
        /// <summary>
        /// Width of scroll box on horizontal scroll bar
        /// </summary>
        SM_CXHTHUMB = 10,
        /// <summary>
        /// Width of standard icon
        /// </summary>
        SM_CXICON = 11,
        /// <summary>
        /// Height of standard icon
        /// </summary>
        SM_CYICON = 12,
        /// <summary>
        /// Width of standard cursor
        /// </summary>
        SM_CXCURSOR = 13,
        /// <summary>
        /// Height of standard cursor
        /// </summary>
        SM_CYCURSOR = 14,
        /// <summary>
        /// Height of menu
        /// </summary>
        SM_CYMENU = 15,
        /// <summary>
        /// Width of client area of maximized window
        /// </summary>
        SM_CXFULLSCREEN = 16,
        /// <summary>
        /// Height of client area of maximized window
        /// </summary>
        SM_CYFULLSCREEN = 17,

    }

    /// <summary>
    /// The list of VirtualKeyCodes (see: http://msdn.microsoft.com/en-us/library/ms645540(VS.85).aspx)
    /// </summary>
    public enum VirtualKey : ushort // UInt16
    {
        NONE = 0,
        /// <summary>
        /// Left mouse button
        /// </summary>
        LBUTTON = 0x01,

        /// <summary>
        /// Right mouse button
        /// </summary>
        RBUTTON = 0x02,

        /// <summary>
        /// Control-break processing
        /// </summary>
        CANCEL = 0x03,

        /// <summary>
        /// Middle mouse button (three-button mouse) - NOT contiguous with LBUTTON and RBUTTON
        /// </summary>
        MBUTTON = 0x04,

        /// <summary>
        /// Windows 2000/XP: X1 mouse button - NOT contiguous with LBUTTON and RBUTTON
        /// </summary>
        XBUTTON1 = 0x05,

        /// <summary>
        /// Windows 2000/XP: X2 mouse button - NOT contiguous with LBUTTON and RBUTTON
        /// </summary>
        XBUTTON2 = 0x06,

        // 0x07 : Undefined

        /// <summary>
        /// BACKSPACE key
        /// </summary>
        BACK = 0x08,

        /// <summary>
        /// TAB key
        /// </summary>
        TAB = 0x09,

        // 0x0A - 0x0B : Reserved

        /// <summary>
        /// CLEAR key
        /// </summary>
        CLEAR = 0x0C,

        /// <summary>
        /// ENTER key
        /// </summary>
        RETURN = 0x0D,
        ENTER = RETURN,

        // 0x0E - 0x0F : Undefined

        /// <summary>
        /// SHIFT key
        /// </summary>
        SHIFT = 0x10,

        /// <summary>
        /// CTRL key
        /// </summary>
        CONTROL = 0x11,

        /// <summary>
        /// ALT key
        /// </summary>
        MENU = 0x12,

        /// <summary>
        /// PAUSE key
        /// </summary>
        PAUSE = 0x13,

        /// <summary>
        /// CAPS LOCK key
        /// </summary>
        CAPITAL = 0x14,

        /// <summary>
        /// Input Method Editor (IME) Kana mode
        /// </summary>
        KANA = 0x15,

        /// <summary>
        /// IME Hanguel mode (maintained for compatibility; use HANGUL)
        /// </summary>
        HANGEUL = 0x15,

        /// <summary>
        /// IME Hangul mode
        /// </summary>
        HANGUL = 0x15,

        // 0x16 : Undefined

        /// <summary>
        /// IME Junja mode
        /// </summary>
        JUNJA = 0x17,

        /// <summary>
        /// IME final mode
        /// </summary>
        FINAL = 0x18,

        /// <summary>
        /// IME Hanja mode
        /// </summary>
        HANJA = 0x19,

        /// <summary>
        /// IME Kanji mode
        /// </summary>
        KANJI = 0x19,

        // 0x1A : Undefined

        /// <summary>
        /// ESC key
        /// </summary>
        ESCAPE = 0x1B,

        /// <summary>
        /// IME convert
        /// </summary>
        CONVERT = 0x1C,

        /// <summary>
        /// IME nonconvert
        /// </summary>
        NONCONVERT = 0x1D,

        /// <summary>
        /// IME accept
        /// </summary>
        ACCEPT = 0x1E,

        /// <summary>
        /// IME mode change request
        /// </summary>
        MODECHANGE = 0x1F,

        /// <summary>
        /// SPACEBAR
        /// </summary>
        SPACE = 0x20,

        /// <summary>
        /// PAGE UP key
        /// </summary>
        PRIOR = 0x21,
        PAGE_UP = PRIOR,

        /// <summary>
        /// PAGE DOWN key
        /// </summary>
        NEXT = 0x22,
        PAGE_DOWN = NEXT,

        /// <summary>
        /// END key
        /// </summary>
        END = 0x23,

        /// <summary>
        /// HOME key
        /// </summary>
        HOME = 0x24,

        /// <summary>
        /// LEFT ARROW key
        /// </summary>
        LEFT = 0x25,

        /// <summary>
        /// UP ARROW key
        /// </summary>
        UP = 0x26,

        /// <summary>
        /// RIGHT ARROW key
        /// </summary>
        RIGHT = 0x27,

        /// <summary>
        /// DOWN ARROW key
        /// </summary>
        DOWN = 0x28,

        /// <summary>
        /// SELECT key
        /// </summary>
        SELECT = 0x29,

        /// <summary>
        /// PRINT key
        /// </summary>
        PRINT = 0x2A,

        /// <summary>
        /// EXECUTE key
        /// </summary>
        EXECUTE = 0x2B,

        /// <summary>
        /// PRINT SCREEN key
        /// </summary>
        SNAPSHOT = 0x2C,

        /// <summary>
        /// INS key
        /// </summary>
        INSERT = 0x2D,

        /// <summary>
        /// DEL key
        /// </summary>
        DELETE = 0x2E,

        /// <summary>
        /// HELP key
        /// </summary>
        HELP = 0x2F,

        /// <summary>
        /// 0 key
        /// </summary>
        VK_0 = 0x30,

        /// <summary>
        /// 1 key
        /// </summary>
        VK_1 = 0x31,

        /// <summary>
        /// 2 key
        /// </summary>
        VK_2 = 0x32,

        /// <summary>
        /// 3 key
        /// </summary>
        VK_3 = 0x33,

        /// <summary>
        /// 4 key
        /// </summary>
        VK_4 = 0x34,

        /// <summary>
        /// 5 key
        /// </summary>
        VK_5 = 0x35,

        /// <summary>
        /// 6 key
        /// </summary>
        VK_6 = 0x36,

        /// <summary>
        /// 7 key
        /// </summary>
        VK_7 = 0x37,

        /// <summary>
        /// 8 key
        /// </summary>
        VK_8 = 0x38,

        /// <summary>
        /// 9 key
        /// </summary>
        VK_9 = 0x39,

        //
        // 0x3A - 0x40 : Udefined
        //

        /// <summary>
        /// A key
        /// </summary>
        VK_A = 0x41,

        /// <summary>
        /// B key
        /// </summary>
        VK_B = 0x42,

        /// <summary>
        /// C key
        /// </summary>
        VK_C = 0x43,

        /// <summary>
        /// D key
        /// </summary>
        VK_D = 0x44,

        /// <summary>
        /// E key
        /// </summary>
        VK_E = 0x45,

        /// <summary>
        /// F key
        /// </summary>
        VK_F = 0x46,

        /// <summary>
        /// G key
        /// </summary>
        VK_G = 0x47,

        /// <summary>
        /// H key
        /// </summary>
        VK_H = 0x48,

        /// <summary>
        /// I key
        /// </summary>
        VK_I = 0x49,

        /// <summary>
        /// J key
        /// </summary>
        VK_J = 0x4A,

        /// <summary>
        /// K key
        /// </summary>
        VK_K = 0x4B,

        /// <summary>
        /// L key
        /// </summary>
        VK_L = 0x4C,

        /// <summary>
        /// M key
        /// </summary>
        VK_M = 0x4D,

        /// <summary>
        /// N key
        /// </summary>
        VK_N = 0x4E,

        /// <summary>
        /// O key
        /// </summary>
        VK_O = 0x4F,

        /// <summary>
        /// P key
        /// </summary>
        VK_P = 0x50,

        /// <summary>
        /// Q key
        /// </summary>
        VK_Q = 0x51,

        /// <summary>
        /// R key
        /// </summary>
        VK_R = 0x52,

        /// <summary>
        /// S key
        /// </summary>
        VK_S = 0x53,

        /// <summary>
        /// T key
        /// </summary>
        VK_T = 0x54,

        /// <summary>
        /// U key
        /// </summary>
        VK_U = 0x55,

        /// <summary>
        /// V key
        /// </summary>
        VK_V = 0x56,

        /// <summary>
        /// W key
        /// </summary>
        VK_W = 0x57,

        /// <summary>
        /// X key
        /// </summary>
        VK_X = 0x58,

        /// <summary>
        /// Y key
        /// </summary>
        VK_Y = 0x59,

        /// <summary>
        /// Z key
        /// </summary>
        VK_Z = 0x5A,

        /// <summary>
        /// Left Windows key (Microsoft Natural keyboard)
        /// </summary>
        LWIN = 0x5B,

        /// <summary>
        /// Right Windows key (Natural keyboard)
        /// </summary>
        RWIN = 0x5C,

        /// <summary>
        /// Applications key (Natural keyboard)
        /// </summary>
        APPS = 0x5D,

        // 0x5E : reserved

        /// <summary>
        /// Computer Sleep key
        /// </summary>
        SLEEP = 0x5F,

        /// <summary>
        /// Numeric keypad 0 key
        /// </summary>
        NUMPAD0 = 0x60,

        /// <summary>
        /// Numeric keypad 1 key
        /// </summary>
        NUMPAD1 = 0x61,

        /// <summary>
        /// Numeric keypad 2 key
        /// </summary>
        NUMPAD2 = 0x62,

        /// <summary>
        /// Numeric keypad 3 key
        /// </summary>
        NUMPAD3 = 0x63,

        /// <summary>
        /// Numeric keypad 4 key
        /// </summary>
        NUMPAD4 = 0x64,

        /// <summary>
        /// Numeric keypad 5 key
        /// </summary>
        NUMPAD5 = 0x65,

        /// <summary>
        /// Numeric keypad 6 key
        /// </summary>
        NUMPAD6 = 0x66,

        /// <summary>
        /// Numeric keypad 7 key
        /// </summary>
        NUMPAD7 = 0x67,

        /// <summary>
        /// Numeric keypad 8 key
        /// </summary>
        NUMPAD8 = 0x68,

        /// <summary>
        /// Numeric keypad 9 key
        /// </summary>
        NUMPAD9 = 0x69,

        /// <summary>
        /// Multiply key
        /// </summary>
        MULTIPLY = 0x6A,

        /// <summary>
        /// Add key
        /// </summary>
        ADD = 0x6B,

        /// <summary>
        /// Separator key
        /// </summary>
        SEPARATOR = 0x6C,

        /// <summary>
        /// Subtract key
        /// </summary>
        SUBTRACT = 0x6D,

        /// <summary>
        /// Decimal key
        /// </summary>
        DECIMAL = 0x6E,

        /// <summary>
        /// Divide key
        /// </summary>
        DIVIDE = 0x6F,

        /// <summary>
        /// F1 key
        /// </summary>
        F1 = 0x70,

        /// <summary>
        /// F2 key
        /// </summary>
        F2 = 0x71,

        /// <summary>
        /// F3 key
        /// </summary>
        F3 = 0x72,

        /// <summary>
        /// F4 key
        /// </summary>
        F4 = 0x73,

        /// <summary>
        /// F5 key
        /// </summary>
        F5 = 0x74,

        /// <summary>
        /// F6 key
        /// </summary>
        F6 = 0x75,

        /// <summary>
        /// F7 key
        /// </summary>
        F7 = 0x76,

        /// <summary>
        /// F8 key
        /// </summary>
        F8 = 0x77,

        /// <summary>
        /// F9 key
        /// </summary>
        F9 = 0x78,

        /// <summary>
        /// F10 key
        /// </summary>
        F10 = 0x79,

        /// <summary>
        /// F11 key
        /// </summary>
        F11 = 0x7A,

        /// <summary>
        /// F12 key
        /// </summary>
        F12 = 0x7B,

        /// <summary>
        /// F13 key
        /// </summary>
        F13 = 0x7C,

        /// <summary>
        /// F14 key
        /// </summary>
        F14 = 0x7D,

        /// <summary>
        /// F15 key
        /// </summary>
        F15 = 0x7E,

        /// <summary>
        /// F16 key
        /// </summary>
        F16 = 0x7F,

        /// <summary>
        /// F17 key
        /// </summary>
        F17 = 0x80,

        /// <summary>
        /// F18 key
        /// </summary>
        F18 = 0x81,

        /// <summary>
        /// F19 key
        /// </summary>
        F19 = 0x82,

        /// <summary>
        /// F20 key
        /// </summary>
        F20 = 0x83,

        /// <summary>
        /// F21 key
        /// </summary>
        F21 = 0x84,

        /// <summary>
        /// F22 key
        /// </summary>
        F22 = 0x85,

        /// <summary>
        /// F23 key
        /// </summary>
        F23 = 0x86,

        /// <summary>
        /// F24 key
        /// </summary>
        F24 = 0x87,

        //
        // 0x88 - 0x8F : Unassigned
        //

        /// <summary>
        /// NUM LOCK key
        /// </summary>
        NUMLOCK = 0x90,

        /// <summary>
        /// SCROLL LOCK key
        /// </summary>
        SCROLL = 0x91,

        // 0x92 - 0x96 : OEM Specific

        // 0x97 - 0x9F : Unassigned

        //
        // L* & R* - left and right Alt, Ctrl and Shift virtual keys.
        // Used only as parameters to GetAsyncKeyState() and GetKeyState().
        // No other API or message will distinguish left and right keys in this way.
        //

        /// <summary>
        /// Left SHIFT key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        LSHIFT = 0xA0,

        /// <summary>
        /// Right SHIFT key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        RSHIFT = 0xA1,

        /// <summary>
        /// Left CONTROL key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        LCONTROL = 0xA2,

        /// <summary>
        /// Right CONTROL key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        RCONTROL = 0xA3,

        /// <summary>
        /// Left MENU key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        LMENU = 0xA4,

        /// <summary>
        /// Right MENU key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        RMENU = 0xA5,

        /// <summary>
        /// Windows 2000/XP: Browser Back key
        /// </summary>
        BROWSER_BACK = 0xA6,

        /// <summary>
        /// Windows 2000/XP: Browser Forward key
        /// </summary>
        BROWSER_FORWARD = 0xA7,

        /// <summary>
        /// Windows 2000/XP: Browser Refresh key
        /// </summary>
        BROWSER_REFRESH = 0xA8,

        /// <summary>
        /// Windows 2000/XP: Browser Stop key
        /// </summary>
        BROWSER_STOP = 0xA9,

        /// <summary>
        /// Windows 2000/XP: Browser Search key
        /// </summary>
        BROWSER_SEARCH = 0xAA,

        /// <summary>
        /// Windows 2000/XP: Browser Favorites key
        /// </summary>
        BROWSER_FAVORITES = 0xAB,

        /// <summary>
        /// Windows 2000/XP: Browser Start and Home key
        /// </summary>
        BROWSER_HOME = 0xAC,

        /// <summary>
        /// Windows 2000/XP: Volume Mute key
        /// </summary>
        VOLUME_MUTE = 0xAD,

        /// <summary>
        /// Windows 2000/XP: Volume Down key
        /// </summary>
        VOLUME_DOWN = 0xAE,

        /// <summary>
        /// Windows 2000/XP: Volume Up key
        /// </summary>
        VOLUME_UP = 0xAF,

        /// <summary>
        /// Windows 2000/XP: Next Track key
        /// </summary>
        MEDIA_NEXT_TRACK = 0xB0,

        /// <summary>
        /// Windows 2000/XP: Previous Track key
        /// </summary>
        MEDIA_PREV_TRACK = 0xB1,

        /// <summary>
        /// Windows 2000/XP: Stop Media key
        /// </summary>
        MEDIA_STOP = 0xB2,

        /// <summary>
        /// Windows 2000/XP: Play/Pause Media key
        /// </summary>
        MEDIA_PLAY_PAUSE = 0xB3,

        /// <summary>
        /// Windows 2000/XP: Start Mail key
        /// </summary>
        LAUNCH_MAIL = 0xB4,

        /// <summary>
        /// Windows 2000/XP: Select Media key
        /// </summary>
        LAUNCH_MEDIA_SELECT = 0xB5,

        /// <summary>
        /// Windows 2000/XP: Start Application 1 key
        /// </summary>
        LAUNCH_APP1 = 0xB6,

        /// <summary>
        /// Windows 2000/XP: Start Application 2 key
        /// </summary>
        LAUNCH_APP2 = 0xB7,

        //
        // 0xB8 - 0xB9 : Reserved
        //

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the ';:' key 
        /// </summary>
        OEM_1 = 0xBA,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '+' key
        /// </summary>
        OEM_PLUS = 0xBB,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the ',' key
        /// </summary>
        OEM_COMMA = 0xBC,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '-' key
        /// </summary>
        OEM_MINUS = 0xBD,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '.' key
        /// </summary>
        OEM_PERIOD = 0xBE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '/?' key 
        /// </summary>
        OEM_2 = 0xBF,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '`~' key 
        /// </summary>
        OEM_3 = 0xC0,

        //
        // 0xC1 - 0xD7 : Reserved
        //

        //
        // 0xD8 - 0xDA : Unassigned
        //

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '[{' key
        /// </summary>
        OEM_4 = 0xDB,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '\|' key
        /// </summary>
        OEM_5 = 0xDC,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the ']}' key
        /// </summary>
        OEM_6 = 0xDD,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the 'single-quote/double-quote' key
        /// </summary>
        OEM_7 = 0xDE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        OEM_8 = 0xDF,

        //
        // 0xE0 : Reserved
        //

        //
        // 0xE1 : OEM Specific
        //

        /// <summary>
        /// Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
        /// </summary>
        OEM_102 = 0xE2,

        //
        // (0xE3-E4) : OEM specific
        //

        /// <summary>
        /// Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        /// </summary>
        PROCESSKEY = 0xE5,

        //
        // 0xE6 : OEM specific
        //

        /// <summary>
        /// Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes. The PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        /// </summary>
        PACKET = 0xE7,

        //
        // 0xE8 : Unassigned
        //

        //
        // 0xE9-F5 : OEM specific
        //

        /// <summary>
        /// Attn key
        /// </summary>
        ATTN = 0xF6,

        /// <summary>
        /// CrSel key
        /// </summary>
        CRSEL = 0xF7,

        /// <summary>
        /// ExSel key
        /// </summary>
        EXSEL = 0xF8,

        /// <summary>
        /// Erase EOF key
        /// </summary>
        EREOF = 0xF9,

        /// <summary>
        /// Play key
        /// </summary>
        PLAY = 0xFA,

        /// <summary>
        /// Zoom key
        /// </summary>
        ZOOM = 0xFB,

        /// <summary>
        /// Reserved
        /// </summary>
        NONAME = 0xFC,

        /// <summary>
        /// PA1 key
        /// </summary>
        PA1 = 0xFD,

        /// <summary>
        /// Clear key
        /// </summary>
        OEM_CLEAR = 0xFE,
    }

    public enum WindowMessage : int
    {
        /// <summary>
        /// 设置文本
        /// </summary>
        WM_SETTEXT = 0x000C,
        /// <summary>
        /// 获取文本
        /// </summary>
        WM_GETTEXT = 0x000D,
        /// <summary>
        /// 获取文本长度
        /// </summary>
        WM_GETTEXTLENGTH = 0x000E,
        /// <summary>
        /// 鼠标左键压下
        /// </summary>
        WM_LBUTTONDOWN = 0x0201,
        /// <summary>
        /// 鼠标左键弹起
        /// </summary>
        WM_LBUTTONUP = 0x0202,
        /// <summary>
        /// 鼠标左键双击
        /// </summary>
        WM_LBUTTONDBLCLK = 0x0203,
        /// <summary>
        /// 鼠标右键按下
        /// </summary>
        WM_RBUTTONDOWN = 0x0204,
        /// <summary>
        /// 鼠标右键弹起
        /// </summary>
        WM_RBUTTONUP = 0x0205,
        /// <summary>
        /// 鼠标右键双击
        /// </summary>
        WM_RBUTTONDBLCLK = 0x0206,
        /// <summary>
        /// 鼠标中键按下
        /// </summary>
        WM_MBUTTONDOWN = 0x0207,
        /// <summary>
        /// 鼠标中键弹起
        /// </summary>
        WM_MBUTTONUP = 0x0208,
        /// <summary>
        /// 鼠标中键双击
        /// </summary>
        WM_MBUTTONDBLCLK = 0x0209,
        /// <summary>
        /// 鼠标滚轮
        /// </summary>
        WM_MOUSEWHEEL = 0x020A,
        /// <summary>
        /// 关闭
        /// </summary>
        WM_CLOSE = 0x0010,
        /// <summary>
        /// 按下
        /// </summary>
        WM_KEYDOWN = 0x0100,
        /// <summary>
        /// 弹起
        /// </summary>
        WM_KEYUP = 0x0101,
        /// <summary>
        /// 系统字符
        /// </summary>
        WM_SYSCHAR = 0x0106,
        WM_SYSKEYUP = 0x0105,
        WM_SYSKEYDOWN = 0x0104,
        /// <summary>
        /// 非系统字符
        /// </summary>
        WM_CHAR = 0x0102,
        WM_IME_CHAR = 0x0286,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_CHANGECBCHAIN = 0x030D,
        WM_HOTKEY = 0x0312,
    }

    public enum WMHotKeys : uint
    {
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        Win = 8
    }

    /// <summary>
    /// XButton definitions for use in the MouseData property of the <see cref="WinAPT.Struct"/> structure. 
    /// (See: http://msdn.microsoft.com/en-us/library/ms646273(VS.85).aspx)
    /// </summary>
    public enum XButton : uint
    {
        /// <summary>
        /// Set if the first X button is pressed or released.
        /// </summary>
        XButton1 = 0x0001,

        /// <summary>
        /// Set if the second X button is pressed or released.
        /// </summary>
        XButton2 = 0x0002,
    }

    public enum SnapshotFlags : uint
    {
        /// <summary>
        /// 在快照中包含在th32ProcessID中指定的进程的所有的堆
        /// </summary>
        TH32CS_SNAPHEAPLIST = 0x00000001,
        /// <summary>
        /// 在快照中包含系统中所有的进程
        /// </summary>
        TH32CS_SNAPPROCESS = 0x00000002,
        /// <summary>
        /// 在快照中包含系统中所有的线程
        /// </summary>
        TH32CS_SNAPTHREAD = 0x00000004,
        /// <summary>
        /// 在快照中包含在th32ProcessID中指定的进程的所有的模块
        /// </summary>
        TH32CS_SNAPMODULE = 0x00000008,
        /// <summary>
        /// 包括所有 32 位模块的快照时调用从 64 位进程中的 th32ProcessID 中指定的过程
        /// </summary>
        TH32CS_SNAPMODULE32 = 0x00000010,
        /// <summary>
        /// 在快照中包含系统中所有的进程和线程
        /// </summary>
        TH32CS_SNAPALL = (TH32CS_SNAPHEAPLIST | TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD | TH32CS_SNAPMODULE),
        /// <summary>
        /// 声明快照句柄是可继承的
        /// </summary>
        TH32CS_INHERIT = 0x80000000
    }
}
