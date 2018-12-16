using MinutoSeguros.Opt.Domain.Feeds;
using MinutoSeguros.Opt.Domain.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MinutoSeguros.Opt.Domain.Services
{
  public class FeedTopTenWordsService : IFeedTopTenWordsService
  {
    IWordsRemovalService _wordsRemovalService;

    public FeedTopTenWordsService(IWordsRemovalService wordsRemovalService)
    {
      _wordsRemovalService = wordsRemovalService;
    }

    public ICollection<BlogPostWord> GetTopTen(Feed feed, string[] articlesAndPrepositions)
    {
      var words = new List<string>();

      feed.BlogPosts.ToList().ForEach(b =>
      {
        words.AddRange(_wordsRemovalService.RemoveWords(b.GetWords(), articlesAndPrepositions));
      });

      var topTen = words
        .GroupBy(w => w)
        .Select(g => new BlogPostWord(g.Key, g.Count()))
        .OrderByDescending(w => w.WordCount)
        .Take(10)
        .ToList();

      return topTen;
    }
  }
}
