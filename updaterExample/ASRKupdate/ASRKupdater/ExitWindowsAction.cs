﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ASRKupdator
{
   [DllImport("aygshell.dll", SetLastError="true")]
[return: MarshalAs(UnmanagedType.Bool)]
static extern bool ExitWindowsEx([MarshalAs(UnmanagedType.U4)]uint dwFlags, [MarshalAs(UnmanagedType.U4)]uint dwReserved);

enum ExitWindowsAction : uint
{
    EWX_LOGOFF = 0,
    EWX_SHUTDOWN = 1,
    EWX_REBOOT = 2,
    EWX_FORCE = 4,
    EWX_POWEROFF = 8
}

void rebootDevice()
{
    ExitWindowsEx(ExitWindowsAction.EWX_REBOOT, 0);
}
}
