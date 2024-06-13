using System.Collections.Generic;
using NLP_Praktikum.model;

namespace NLP_Praktikum.service.treeService
{
    public interface ITreeService
    {
        void CreateTree(string line);
        List<NodeModel> FindAllTrees();
    }
}