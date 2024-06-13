using System;
using System.Collections.Generic;
using System.Linq;
using NLP_Praktikum.model;
using NLP_Praktikum.repository.parseRuleRepository;

namespace NLP_Praktikum.service.parseService
{
    public class ParseServiceImpl:IParseService
    {
        private ParseRuleRepository _repository;
        public ParseServiceImpl(ParseRuleRepository repository)
        {
            _repository = repository;
        }

        public Tuple<string, Bt, float> WeightedChainedCKY(string line, string initial)
        {
            var arr = line.Trim().Split(" ");
            var w = new Dictionary<int, string>();
            var c = new Dictionary<(int,int), HashSet<(string, Bt, float)>>();
            for (var i = 1; i <= arr.Length; i++)
            {
                w[i] = arr[i - 1];
            }

            var n = w.Count;
            for (var i = 1; i <= n; i++)
            {
                c[(i - 1, i)] = _repository.FindAllLexicon(w[i]).Select(tuple => (tuple.Item1.Lhs, new Bt(tuple.Item1), tuple.Item2)).ToHashSet();
            }

            for (var r = 2; r <= n; r++)
            {
                for (var i = 0; i <= n - r; i++)
                {
                    var j = i + r;
                    for (var m = i + 1; m <= j - 1; m++)
                    {
                        foreach (var (B, btB, weightB) in c[(i,m)])
                        {
                            foreach (var (C, btC, weightC) in c[(m,j)])
                            {
                                var rules = _repository.FindAllRules(B, C).ToArray();
                                if (rules.Length != 0)
                                    c[(i, j)] = rules.Select(tuple => (tuple.Item1.Lhs, new Bt(tuple.Item1, btB, btC),
                                        tuple.Item2 * weightB * weightC)).ToHashSet();
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}