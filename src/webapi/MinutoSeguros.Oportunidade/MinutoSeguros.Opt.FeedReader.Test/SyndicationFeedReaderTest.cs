using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace MinutoSeguros.Opt.FeedReader.Test
{
  [TestClass]
  public class SyndicationFeedReaderTest
  {
    readonly string _feedUrl = ConfigurationManager.AppSettings["feedUrl"];

    [TestMethod]
    public void DownloadSyndicationFeed()
    {
      var syndicationFeedReader = new SyndicationFeedReader();
      var syndicationFeed = syndicationFeedReader.GetSyndicationFeed(_feedUrl);

      Assert.IsNotNull(syndicationFeed);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void DownloadSyndicationFeedNullUrl()
    {
      var syndicationFeedReader = new SyndicationFeedReader();
      var syndicationFeed = syndicationFeedReader.GetSyndicationFeed(null);
    }
  }
}
