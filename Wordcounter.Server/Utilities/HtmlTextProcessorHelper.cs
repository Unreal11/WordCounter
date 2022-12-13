using System.Text;
using System.Text.RegularExpressions;

public static class HtmlTextProcessorHelper
{
    public static string RemoveStringReturns(this string text)
    {
        return RemoveByRegexp(text, @"\t|\n|\r");
    }

    public static string RemoveHtmlTags(this string text)
    {
        return RemoveByRegexp(text, "<[^>]+>");
    }

    public static string RemovePunctuations(this string text)
    {
        return Regex.Replace(text, @"[^\w\d\s]", string.Empty, RegexOptions.Compiled);
    }

    public static string RemoveHtmlBlock(this string text, string htmlTag)
    {
        var htmlTagStartExpression = new Regex($"<{htmlTag}[^>]*>");
        var htmlTagEndExpression = new Regex($"</{htmlTag}[^>]*>");

        var result = new StringBuilder();
        var currentPos = 0;
        var startMatch = htmlTagStartExpression.Match(text, currentPos);

        while (startMatch.Success)
        {
            result.Append(text.Substring(currentPos, startMatch.Index - currentPos));

            var endMatch = htmlTagEndExpression.Match(text, startMatch.Index);
            currentPos = endMatch.Success ? endMatch.Index + endMatch.Length : text.Length;
            startMatch = htmlTagStartExpression.Match(text, currentPos);
        }

        result.Append(text.Substring(currentPos));

        return result.ToString();
    }

    public static string RemoveHtmlComments(this string text)
    {
        var htmlTagStartExpression = new Regex($"<!--");
        var htmlTagEndExpression = new Regex($"-->");

        var result = new StringBuilder();
        var currentPos = 0;
        var startMatch = htmlTagStartExpression.Match(text, currentPos);

        while (startMatch.Success)
        {
            result.Append(text.Substring(currentPos, startMatch.Index - currentPos));

            var endMatch = htmlTagEndExpression.Match(text, startMatch.Index);
            currentPos = endMatch.Success ? endMatch.Index + endMatch.Length : text.Length;
            startMatch = htmlTagStartExpression.Match(text, currentPos);
        }

        result.Append(text.Substring(currentPos));

        return result.ToString();
    }

    private static string RemoveByRegexp(string text, string expression)
    {
        var regexExpression = new Regex(expression);
        var result = new StringBuilder();
        var currentPos = 0;
        var match = regexExpression.Match(text);

        while(match.Success)
        {
            result.Append(text.Substring(currentPos, match.Index - currentPos) + CharDictionary.Whitespace);
            currentPos = match.Index + match.Length;

            match = regexExpression.Match(text, currentPos);
        }
        if (currentPos == 0) 
        {
            return text;
        }

        result.Append(text.Substring(currentPos));

        return result.ToString();
    }
}