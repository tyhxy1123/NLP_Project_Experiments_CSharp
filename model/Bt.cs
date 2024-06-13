using System;
using System.Collections.Generic;
using System.Linq;
using NLP_Praktikum.enumeration;

namespace NLP_Praktikum.model
{
    public class Bt : IEquatable<Bt>
    {
        public string Lhs { get; }
        public List<string> Rhs { get; }
        public Bt[] Children { get; }
        
        public GrammarType Type { get; }

        public Bt(Rule rule, params Bt[] bts)
        {
            Lhs = rule.Lhs;
            Rhs = rule.Rhs;
            Children = bts;
            Type = rule.Type;
        }

        public Bt(Lexical lexical, params Bt[] bts)
        {
            Lhs = lexical.Lhs;
            Rhs = new List<string>{lexical.Rhs};
            Children = bts;
            Type = lexical.Type;
        }

        public bool Equals(Bt other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Lhs == other.Lhs;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Bt) obj);
        }

        public override int GetHashCode()
        {
            return (Lhs != null ? Lhs.GetHashCode() : 0);
        }
    }
}