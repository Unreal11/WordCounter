using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();
var url = @"https://animego.org/anime/zaderzhi-etot-zvuk-937";
var text = await PageTextRequestHelper.GetTextAsync(url);

var preparedText = text
    .RemoveHtmlBlock("style")
    .RemoveHtmlBlock("script")
    .RemoveHtmlComments()
    .RemoveHtmlTags()
    .RemoveStringReturns()
    .RemovePunctuations();

var wordCounter = new WordCounter(
    new GrammarValidator());

var words = wordCounter.CountWords(preparedText);

app.UseCors(x => { 
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});

app.MapPost("/api/getWordsCount", (RequestModel model) =>
{
    return "";
});

app.Run();
