using System;
using NLP_Praktikum.enumeration;

namespace NLP_Praktikum.model
{
    public class Lexical
    {
        public string Lhs { get; }
        public string Rhs { get; }
        public GrammarType Type { get; }

        public Lexical(string lhs, string rhs, GrammarType type)
        {
            this.Lhs = lhs;
            this.Rhs = rhs;
            this.Type = type;
        }

        protected bool Equals(Lexical other)
        {
            return Lhs == other.Lhs && Rhs == other.Rhs && Type == other.Type;
        }

        public override string ToString()
        {
            return $"{nameof(Lhs)}: {Lhs}, {nameof(Rhs)}: {Rhs}, {nameof(Type)}: {Type}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Lexical) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Lhs, Rhs, (int) Type);
        }
    }
}