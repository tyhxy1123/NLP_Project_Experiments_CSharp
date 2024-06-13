using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NLP_Praktikum.model;
using NLP_Praktikum.repository.nodeRepository;

namespace NLP_Praktikum.repository.parseRuleRepository
{
    public class ParseRuleRepository
    {
        private readonly Dictionary<Rule, float> _ruleRepository = new Dictionary<Rule, float>();
        private readonly HashSet<(string, Rule, float)> _rules = new HashSet<(string, Rule, float)>();
        private readonly Dictionary<List<string>, HashSet<(Rule, float)>> _reverseRuleDict = new Dictionary<List<string>, HashSet<(Rule, float)>>();
        
        private readonly Dictionary<Lexical, float> _lexiconRepository = new Dictionary<Lexical, float>();
        private readonly Dictionary<string, HashSet<(Lexical, float)>> _reverseLexiconDict = new Dictionary<string, HashSet<(Lexical, float)>>();
        private readonly HashSet<(string, Lexical, float)> _lexicon = new HashSet<(string, Lexical, float)>();
        
        public Dictionary<Lexical, float> FindAllLexicon()
        {
            return _lexiconRepository;
        }

        public IEnumerable<(Lexical, float)> FindAllLexicon(string rhs)
        {
            var key = rhs;
            return _reverseLexiconDict.ContainsKey(key) ? _reverseLexiconDict[key] : new HashSet<(Lexical, float)>();
        }
        
        public Dictionary<Rule, float> FindAllRules()
        {
            return _ruleRepository;
        }

        public IEnumerable<(Rule, float)> FindAllRules(List<string> rhs)
        {
            return _reverseRuleDict.ContainsKey(rhs) ? _reverseRuleDict[rhs] : new HashSet<(Rule, float)>();
        }

        public IEnumerable<(Rule, float)> FindAllRules(params string[] rhs)
        {
            return FindAllRules(rhs.ToList());
        }

        public void Add(Rule rule, float weight)
        {
            _ruleRepository[rule] = weight;
            _rules.Add((rule.Lhs, rule, weight));    
            if (_reverseRuleDict.ContainsKey(rule.Rhs))
            {
                _reverseRuleDict[rule.Rhs].Add((rule, weight));
            }
            else
            {
                _reverseRuleDict[rule.Rhs] = new HashSet<(Rule, float)> {(rule, weight)};
            }
        }

        public void Add(Lexical lexical, float weight)
        {
            _lexiconRepository[lexical] = weight;
            _lexicon.Add((lexical.Lhs, lexical, weight));
            if (_reverseLexiconDict.ContainsKey(lexical.Rhs))
            {
                _reverseLexiconDict[lexical.Rhs].Add((lexical, weight));
            }
            else
            {
                _reverseLexiconDict[lexical.Rhs] = new HashSet<(Lexical, float)>{(lexical, weight)};
            }
        }
    }
}