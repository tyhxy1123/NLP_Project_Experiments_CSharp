using System;
using NLP_Praktikum.model;

namespace NLP_Praktikum.service.parseService
{
    public interface IParseService
    {
        Tuple<String, Bt, float> WeightedChainedCKY(String line, String initial);
    }
}