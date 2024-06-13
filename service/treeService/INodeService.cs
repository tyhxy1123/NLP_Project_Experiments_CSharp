using System.Collections.Generic;
using NLP_Praktikum.enumeration;
using NLP_Praktikum.model;

namespace NLP_Praktikum.service.treeService
{
    public interface INodeService
    {
        NodeModel CreateNode(string value, NodeModel parent, List<NodeModel> children, GrammarType type);
        List<NodeModel> FindAllNodes();
        List<NodeModel> FindAllLexical();
        List<NodeModel> FindAllNonLexical();
        List<NodeModel> FindAllAtoms();
    }
}