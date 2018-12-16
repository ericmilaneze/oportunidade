using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinutoSeguros.Opt.Domain.Feeds;
using MinutoSeguros.Opt.FeedReader.Interfaces;
using MinutoSeguros.Opt.FeedReader.Test.Helpers;
using Moq;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel.Syndication;

namespace MinutoSeguros.Opt.FeedReader.Test
{
  [TestClass]
  public class FeedReaderTest
  {
    string _feedUrl;
    ISyndicationFeedReader _syndicationFeedReaderMocked;
    ISyndicationItemConverter _syndicationItemConverterMocked;

    [TestInitialize]
    public void Initialize()
    {
      _feedUrl = ConfigurationManager.AppSettings["feedUrl"];

      Mock<ISyndicationFeedReader> mockSyndicationFeedReader = new Mock<ISyndicationFeedReader>();
      mockSyndicationFeedReader
        .Setup(m => m.GetSyndicationFeed(It.IsAny<string>()))
        .Returns(() => SyndicationFeedHelper.GetSyndicationFeed());

      _syndicationFeedReaderMocked = mockSyndicationFeedReader.Object;

      Mock<ISyndicationItemConverter> mockSyndicationItemConverter = new Mock<ISyndicationItemConverter>();
      mockSyndicationItemConverter
        .Setup(m => m.GetBlogPosts(It.IsAny<IEnumerable<SyndicationItem>>()))
        .Returns(() => new List<BlogPost>()
        {
          new BlogPost(content: "Content 1", title: "Title 1"),
          new BlogPost(content: "Content 2", title: "Title 2"),
          new BlogPost(content: "Content 3", title: "Title 3"),
        });

      _syndicationItemConverterMocked = mockSyndicationItemConverter.Object;
    }

    [TestMethod]
    public void GetFeed()
    {
      FeedReader feedReader = new FeedReader(_syndicationFeedReaderMocked, _syndicationItemConverterMocked);

      Feed feed = feedReader.GetFeed("http://teste", 10);

      Assert.AreEqual(3, feed.BlogPosts.Count);
    }
  }
}
