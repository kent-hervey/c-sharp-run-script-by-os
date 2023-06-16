using System.Diagnostics;
using System.Runtime.InteropServices;
using System;

namespace RunBashOrCMD;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string bubba = WhatOS();
        Console.WriteLine("your operationg system is: " + bubba);

        if (bubba.Contains("OSX"))
        {
            Console.WriteLine("you are on a Mac");
            Console.WriteLine();

            string scriptPath = Path.Combine("/Users/khervey/VisualStudioProjects/RunBashOrCMD", "utilities", "createVersionTxt.sh");



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

        }

        Console.ReadKey();
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


    static string ExecuteBashCommand()
    {
        // according to: https://stackoverflow.com/a/15262019/637142
        // thans to this we will pass everything as one command
        

        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "$(ProjectDir)/utilities/createVersionTxt.sh",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };

        proc.Start();
        proc.WaitForExit();

        return proc.StandardOutput.ReadToEnd();
    }






}
