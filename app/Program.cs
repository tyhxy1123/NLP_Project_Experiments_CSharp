using CommandLine;

namespace NLP_Praktikum.app
{
    class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Induce>(args).WithParsed((Induce i) => i.Run(args));
        }
    }
}