using System.Security.Cryptography;
using wordcounter.Model;

public class WordCounter
{
    private IWordCounterValidator[] validators;

    public WordCounter(params IWordCounterValidator[] validators)
    {
        this.validators = validators;

        if (this.validators == null)
        {
            this.validators = new IWordCounterValidator[0];
        }
    }

    public List<WordDataModel> CountWords(string text)
    {
        text = text.ToLower();

        var wordList = new Dictionary<string, WordDataModel>();

        var singleWordCountList = new Dictionary<string, WordCountModel>();
        var doubleWordCountList = new Dictionary<string, WordCountModel>();
        var tripleWordCountList = new Dictionary<string, WordCountModel>();

        var split = text.Split(CharDictionary.Whitespace)
            .Where(x => IsValidWord(x))
            .ToArray();

        for (var index = 0; index < split.Length; index++)
        {
            var word = split[index];
            var word1 = split.ElementAtOrDefault(index - 1);
            var word3 = split.ElementAtOrDefault(index - 2);

            if (!wordList.ContainsKey(word))
            {
                var id = wordList.Count + 1;
                var wordData = new WordDataModel(id, word);
                wordList.Add(word, wordData);
            }

            var singleWordData = singleWordCountList.GetValueOrDefault(wordList[word].Id) ??
                                 new WordCountModel(wordList[word].Id);

            HashCode.Combine(word, word1);
            if (word1 != null)
            {
                var doubleCountData = new WordCountModel()
            }

            if (word3 != null)
            {

            }

            singleWordData.Count++;
        }

        return wordList;
    }

    private bool IsValidWord(string word)
    {
        if (string.IsNullOrEmpty(word) || !word.Any(x => char.IsLetter(x)))
        {
            return false;
        }

        foreach (var validator in validators)
        {
            if (!validator.IsValidWord(word))
            {
                return false;
            }
        }

        return true;
    }
}