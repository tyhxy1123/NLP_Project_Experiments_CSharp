using System.Collections.Generic;
using NLP_Praktikum.enumeration;

namespace NLP_Praktikum.model
{
    public class NodeModel
    {
        public ulong Id { get; }
        public string Value { get; }
        public NodeModel Parent { get; }
        public List<NodeModel> Children { get; }
        public GrammarType Type { get; }

        public NodeModel(ulong id, string value, NodeModel parent, List<NodeModel> children, GrammarType type)
        {
            this.Id = id;
            Value = value;
            Parent = parent;
            Children = children;
            Type = type;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Value)}: {Value}, {nameof(Parent)}: {Parent}, {nameof(Children)}: {Children}, {nameof(Type)}: {Type}";
        }
    }
}