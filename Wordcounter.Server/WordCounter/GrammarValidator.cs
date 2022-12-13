public class GrammarValidator : IWordCounterValidator
{
    private readonly string[] invalidGrammar = new string[]
    {
        "a",
        "an",
        "the",

        "и",
        "в",
        "над",
        "от",
        "для",
    };

    public bool IsValidWord(string word)
    {
        return !invalidGrammar.Contains(word);
    }
}