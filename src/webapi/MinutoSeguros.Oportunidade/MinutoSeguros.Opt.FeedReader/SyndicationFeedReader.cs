using MinutoSeguros.Opt.FeedReader.Interfaces;
using System.ServiceModel.Syndication;
using System.Xml;

namespace MinutoSeguros.Opt.FeedReader
{
  public class SyndicationFeedReader : ISyndicationFeedReader
  {
    public SyndicationFeed GetSyndicationFeed(string feedUrl)
    {
      using (var xmlReader = XmlReader.Create(feedUrl))
      {
        var syndicationFeed = SyndicationFeed.Load(xmlReader);
        xmlReader.Close();

        return syndicationFeed;
      }
    }
  }
}
