using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NLP_Praktikum.enumeration;
using NLP_Praktikum.model;
using NLP_Praktikum.repository.nodeRepository;
using NLP_Praktikum.repository.parseRuleRepository;

namespace NLP_Praktikum.service.fileService
{
    public class FileService:IFileService
    {
        public ParseRuleRepository ReadRules(string rulePath, string lexicalPath)
        {
            var lines = File.ReadLines(rulePath, Encoding.UTF8);
            var repo = new ParseRuleRepository();
            foreach (var line in lines)
            {
                var arr = line.Split(" ").Where(s => s != "" && s != "->").ToList();
                var lhs = arr.First();
                var weight = float.Parse(arr.Last());
                var rhs = arr.Skip(1).SkipLast(1).ToList();
                repo.Add(new Rule(lhs, GrammarType.NonLexical, rhs), weight);
            }

            lines = File.ReadLines(lexicalPath, Encoding.UTF8);
            foreach (var line in lines)
            {
                var arr = line.Split(" ").Where(s => s != "").ToArray();
                var lhs = arr.First();
                var weight = float.Parse(arr.Last());
                var rhs = arr[1];
                repo.Add(new Lexical(lhs, rhs, GrammarType.Lexical), weight);
            }
            return repo;
        }
    }
}