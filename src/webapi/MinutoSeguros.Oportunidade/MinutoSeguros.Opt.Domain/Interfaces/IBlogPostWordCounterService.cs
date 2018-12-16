using MinutoSeguros.Opt.Domain.Feeds;

namespace MinutoSeguros.Opt.Domain.Interfaces
{
  public interface IBlogPostWordCounterService
  {
    int GetWordCount(BlogPost blogPost, string[] articlesAndPrepositions);
  }
}