using System.Runtime.InteropServices;

namespace RunBashOrCMD;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string bubba = WhatOS();
        Console.WriteLine("your operationg system is: " + bubba);
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
}
