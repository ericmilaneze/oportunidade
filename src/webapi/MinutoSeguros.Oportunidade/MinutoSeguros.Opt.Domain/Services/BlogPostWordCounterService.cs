using MinutoSeguros.Opt.Domain.Feeds;
using System.Linq;
using MinutoSeguros.Opt.Domain.Interfaces;

namespace MinutoSeguros.Opt.Domain.Services
{
  public class BlogPostWordCounterService : IBlogPostWordCounterService
  {
    IWordsRemovalService _wordsRemovalService;

    public BlogPostWordCounterService(IWordsRemovalService wordsRemovalService)
    {
      _wordsRemovalService = wordsRemovalService;
    }

    public int GetWordCount(BlogPost blogPost, string[] articlesAndPrepositions)
    {
      var uniqueWords = _wordsRemovalService.RemoveWords(
        words: blogPost.GetWords().Distinct().ToArray(), 
        wordsToRemove: articlesAndPrepositions);

      return uniqueWords.Count();
    }
  }
}
