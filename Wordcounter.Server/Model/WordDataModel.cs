public class WordDataModel
{
    public int Id { get; }
    public string Word { get; }
    public int Count { get; set; }
    
    public WordDataModel(int id, string word)
    {
        Id = id;
        Word = word;
    }
}