using System.ServiceModel.Syndication;

namespace MinutoSeguros.Opt.FeedReader.Interfaces
{
  public interface ISyndicationFeedReader
  {
    SyndicationFeed GetSyndicationFeed(string feedUrl);
  }
}
