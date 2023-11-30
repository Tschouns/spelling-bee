
namespace SpellingBee.Console.Rules
{
    public interface IWordRule
    {
        public string GetDescription();
        public bool CheckWord(string word);
    }
}
