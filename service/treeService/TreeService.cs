using System;
using System.Collections.Generic;
using System.Linq;
using NLP_Praktikum.enumeration;
using NLP_Praktikum.model;

namespace NLP_Praktikum.service.treeService
{
    public class TreeService:ITreeService
    {
        private readonly INodeService _nodeService;
        public TreeService(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        public void CreateTree(string line)
        {
            var stack = new Stack<NodeModel>();
            line = line.Substring(1, line.Length-2);
            var list = line.Split(" ").ToList();
            var root = _nodeService.CreateNode(value: list[0], parent: null, children: new List<NodeModel>(), type: GrammarType.Atom);
            stack.Push(root);
            list.RemoveAt(0);
            list.ForEach(str =>
            {
                if (str.StartsWith("("))
                {
                    var node = _nodeService.CreateNode(value: str.Substring(1), parent: stack.Peek(), children: new List<NodeModel>(), type: GrammarType.NonLexical);
                    node.Parent.Children.Add(node);
                    stack.Push(node);
                }
                else
                {
                    var node = _nodeService.CreateNode(value: str.Substring(0, str.IndexOf(')')), parent: stack.Peek(), new List<NodeModel>(), type: GrammarType.Lexical);
                    node.Parent.Children.Add(node);
                    var it = str.Substring(str.IndexOf(')')).GetEnumerator();
                    while (it.MoveNext())
                    {
                        stack.Pop();
                    }
                    it.Dispose();
                }
            });
        }

        public List<NodeModel> FindAllTrees()
        {
            return _nodeService.FindAllAtoms();
        }
    }
}