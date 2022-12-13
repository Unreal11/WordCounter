namespace wordcounter.Model;

public class WordCountModel
{
    public int[] WordsId { get; }
    public int Count { get; set; }

    public WordCountModel(params int[] wordsId)
    {
        WordsId = wordsId;
    }
}