using MinutoSeguros.Opt.Domain.Feeds;
using MinutoSeguros.Opt.Domain.Interfaces;
using MinutoSeguros.Opt.FeedReader.Interfaces;
using System.Linq;

namespace MinutoSeguros.Opt.FeedReader
{
  public class FeedReader : IFeedReader
  {
    ISyndicationFeedReader _syndicationFeedReader;
    ISyndicationItemConverter _syndicationItemConverter;

    public FeedReader(ISyndicationFeedReader syndicationFeedReader, ISyndicationItemConverter syndicationItemConverter)
    {
      _syndicationFeedReader = syndicationFeedReader;
      _syndicationItemConverter = syndicationItemConverter;
    }

    public Feed GetFeed(string feedUrl, int postCount = 10)
    {
      var syndicationFeedItems = _syndicationFeedReader.GetSyndicationFeed(feedUrl)?
        .Items?
        .Take(postCount)
        .ToList();

      var blogPosts = _syndicationItemConverter.GetBlogPosts(syndicationFeedItems);

      return new Feed(blogPosts.ToList());
    }
  }
}
