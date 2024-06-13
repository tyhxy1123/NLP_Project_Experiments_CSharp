using System;
using System.Collections.Generic;
using NLP_Praktikum.enumeration;

namespace NLP_Praktikum.model
{
    public class Rule
    {
        public string Lhs { get; }
        public GrammarType Type{ get; }
        public List<string> Rhs { get; }

        public Rule(string lhs, GrammarType type, List<string> rhs)
        {
            Lhs = lhs;
            this.Type = type;
            this.Rhs = rhs;
        }

        protected bool Equals(Rule other)
        {
            return Lhs == other.Lhs && Type == other.Type && Equals(Rhs, other.Rhs);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rule) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Lhs, (int) Type, Rhs);
        }

        public override string ToString()
        {
            return $"{nameof(Lhs)}: {Lhs}, {nameof(Type)}: {Type}, {nameof(Rhs)}: {Rhs}";
        }
    }
}