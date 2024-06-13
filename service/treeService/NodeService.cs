using System.Collections.Generic;
using NLP_Praktikum.enumeration;
using NLP_Praktikum.model;
using NLP_Praktikum.repository.nodeRepository;

namespace NLP_Praktikum.service.treeService
{
    public class NodeService:INodeService
    {
        private static ulong _id;
        private readonly NodeRepository _nodeRepository;
        private readonly LexicalRepository _lexicalRepository;
        private readonly NonLexicalRepository _nonLexicalRepository;
        private readonly AtomRepository _atomRepository;

        public NodeService()
        {
            _nodeRepository = new NodeRepository();
            _lexicalRepository = new LexicalRepository();
            _nonLexicalRepository = new NonLexicalRepository();
            _atomRepository = new AtomRepository();
        }

        public List<NodeModel> FindAllNodes()
        {
            return _nodeRepository.FindAll();
        }

        public NodeModel CreateNode(string value, NodeModel parent, List<NodeModel> children, GrammarType type)
        {
            var node = new NodeModel(id: ++_id, value: value, children: children, parent: parent, type: type);
            _nodeRepository.Add(node);
            if (node.Type == GrammarType.Lexical)
            {
                _lexicalRepository.Add(node);
            }
            else
            {
                _nonLexicalRepository.Add(node);
                if (node.Type == GrammarType.Atom)
                {
                    _atomRepository.Add(node);
                }
            }

            return node;
        }

        public List<NodeModel> FindAllLexical()
        {
            return _lexicalRepository.FindAll();
        }

        public List<NodeModel> FindAllAtoms()
        {
            return _atomRepository.FindAll();
        }

        public List<NodeModel> FindAllNonLexical()
        {
            return _nonLexicalRepository.FindAll();
        }
    }
}