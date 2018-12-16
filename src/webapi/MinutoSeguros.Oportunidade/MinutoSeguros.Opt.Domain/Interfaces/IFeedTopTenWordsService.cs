using System.Collections.Generic;
using MinutoSeguros.Opt.Domain.Feeds;

namespace MinutoSeguros.Opt.Domain.Interfaces
{
  public interface IFeedTopTenWordsService
  {
    ICollection<BlogPostWord> GetTopTen(Feed feed, string[] articlesAndPrepositions);
  }
}