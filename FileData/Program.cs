using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        static FileDetails fd = new FileDetails();
        /* Expected arguments: 
         *  First argument: indicate the functionality to perform
         *  Second argument: indicate the filename
         */
        public static void Main(string[] args)
        {
            String result = chooseFunctionality(args);
            Console.WriteLine(result);
            Console.ReadKey(true);
        }

        /*This function takes the args parameters and based on the 
         functionality return version or size of the file*/
        public static string chooseFunctionality(String [] args) {
            try
            {
                switch (args[0])
                {
                    case "-v":
                    case "--v":
                    case "/v":
                    case "--version":
                        return fd.Version(args[1]);
                    case "-s":
                    case "--s":
                    case "/s":
                    case "--size":
                        return fd.Size(args[1]).ToString();
                    default:
                        return "Wrong input";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                return "Wrong input";
            }
        }
    }
}
