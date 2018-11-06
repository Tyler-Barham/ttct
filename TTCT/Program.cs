using System;

namespace TTCT
{
    class Program
    {
        private static bool ignoreCase = false;
        private static bool useStemmer = false;
        private static string ifPath = "";
        private static string cfPath = "";

        static void Main(string[] args)
        {
            //If there were incorrect/not enough args then return
            if(!setArgs(args))
            {
                return;
            }
            
            //Create an instance of the reader and dll
            Reader r = new Reader(ignoreCase, useStemmer);
            DoublyLinkedList dll;

            //Store all terms in the dll
            dll = r.getDLLOfTerms(ifPath);
            //Remove terms from the dll
            dll = r.removeTermsFromDll(cfPath, dll);

            //Display output
            Console.WriteLine(string.Format("There are {0} unique terms:", dll.size()));
            Console.WriteLine(dll.getAllTerms());
        }

        //Extract the args, set variables accordingly or display help
        private static bool setArgs(string[] args)
        {
            //Check each arg
            foreach(string arg in args)
            {
                switch(arg)
                {
                    case "--ignore-case":
                        ignoreCase = true;
                        break;

                    case "--stemmer":
                        useStemmer = true;
                        break;
                    
                    case "--help":
                        printHelp();
                        return false;
                    
                    default:
                        if(arg.Contains("if="))
                        {
                            ifPath = arg.Remove(0,3);
                        }
                        else if (arg.Contains("cf="))
                        {
                            cfPath = arg.Remove(0,3);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("\"{0}\" is an unsupported argument.", arg));
                            printHelp();
                            return false;
                        }
                        break;
                }
            }

            //If no required args were given
            if(ifPath.Equals("") || cfPath.Equals(""))
            {
                Console.WriteLine("Both the input and comparison folders/files need to be supplied");
                printHelp();
                return false;
            }

            return true;
        }

        //Displays the help
        private static void printHelp()
        {
            Console.WriteLine();
            Console.WriteLine("TTCT - Tyler's Text Comparison Tool");
            Console.WriteLine("A tool for determining all the words that appear in one folder/file but not another");
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine("    if=<path>        The input folder/file.");
            Console.WriteLine("    cf=<path>        The comparison folder/file.");
            Console.WriteLine();
            Console.WriteLine("Optional:");
            Console.WriteLine("    --ignore-case    Ignores upper/lower case when comparing files.");
            Console.WriteLine("    --stemmer        Uses the porter stemmer when comparing files (forces --ignore-case).");
            Console.WriteLine("    --help           Displays this page.");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("    TTCT if=~/Downloads cf=../../myFolder");
            Console.WriteLine("    TTCT if=./myFolder cf=./myFolder/subFolder --use-stemmer");
            Console.WriteLine("    TTCT --help");
            Console.WriteLine();
        }
    }
}
