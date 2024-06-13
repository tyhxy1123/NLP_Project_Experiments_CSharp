using System;
using CommandLine;
using NLP_Praktikum.repository;
using NLP_Praktikum.repository.nodeRepository;
using NLP_Praktikum.service;
using NLP_Praktikum.service.treeService;

namespace NLP_Praktikum.app
{
    [Verb("induce", HelpText = "induce grammar from penn trees")]
    public class Induce
    {
        public void Run(String[] args)
        {
            var nodeService = new NodeService();
            var treeService = new TreeService(nodeService);
            string line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                treeService.CreateTree(line);
            }
            treeService.FindAllTrees().ForEach(Console.WriteLine);
        }
    }
}