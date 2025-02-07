using System;
using System.Text;
using System.IO;

namespace Axes
{
    class Axes
    {
        private static string filePath;
        private static string outputPath;

        public static void Main(String[] args) //Program Entry point
        {
            HandleParameters(args);
        }

        private static void HandleParameters(String[] args)
        {
            if(args.Length > 1)
            {
                Console.WriteLine("Axes Usage");
                Console.WriteLine("\tAxes [file]");
            }
            else if (args.Length == 1)
            {
                RunFile(args[0]);
            }
            else
            {
                RunPrompt();
            }
        }
    
        private static void Run(string source)
        {
            ErrorHandler errorHandler = new ErrorHandler();
            Scanner scanner = new Scanner(source);
            Parser parser = new Parser(scanner.tokens);

            if (errorHandler.error || errorHandler.syntaxError)
            {
                errorHandler.PrintErrorList();
                throw new Exception("Errors encountered.");
            }

            Translator translator = new Translator();

            //TODO: Temporary Stuff
            Console.WriteLine(source);
        }

        private static void RunPrompt()
        {
            ErrorHandler errorHandler = new ErrorHandler();

            while (true)
            {
                Console.Write(">");
                string line = Console.ReadLine();
                if (line == null || line == "")
                    break;

                Run(line);
                errorHandler.Reset();
            }
        }
        
        private static void RunFile(string filepath)
        { 
            if(!File.Exists(filepath))  throw new IOException(filepath + " is not a valid file.");

            string[] source = File.ReadAllLines(filepath);

            foreach (string line in source)
            {
                Run(line);
            }
        }
    }
}
