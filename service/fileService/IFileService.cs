
using NLP_Praktikum.repository.parseRuleRepository;

namespace NLP_Praktikum.service.fileService
{
    public interface IFileService
    {
        ParseRuleRepository ReadRules(string rulePath, string lexicalPath);
    }
}