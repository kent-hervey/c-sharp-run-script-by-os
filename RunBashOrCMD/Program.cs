using System.Diagnostics;
using System.Runtime.InteropServices;
using System;

namespace RunBashOrCMD;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string foundOs = WhatOS();
        Console.WriteLine("your operationg system is: " + foundOs);

        if (foundOs.Contains("OSX"))
        {
            Console.WriteLine("you are on a Mac");
            String version = runShellScript();
        }

        Console.ReadKey();
    }

    private static string runShellScript()
    { 

        string execPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
    
        string scriptPath = Path.Combine(execPath, "utilities", "createVersionTxt.sh");

        Console.WriteLine("here is the file path " + scriptPath);

        // Create a new ProcessStartInfo object
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = scriptPath,
            UseShellExecute = false,
            RedirectStandardOutput = true
        };

        // Start the process
        Process process = new Process
        {
            StartInfo = startInfo

        };

        process.Start();

        // Wait for the process to finish
        process.WaitForExit();

        // Get the output from the process
        string output = process.StandardOutput.ReadToEnd();

        // Print the output
        Console.WriteLine(output);

        return output;
    }


    public static string WhatOS()
    {

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return  OSPlatform.OSX.ToString();
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return OSPlatform.Linux.ToString();
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return OSPlatform.Windows.ToString();
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
        {
            return OSPlatform.FreeBSD.ToString();
        }

        throw new Exception("Cannot determine operating system!");
    }
}
