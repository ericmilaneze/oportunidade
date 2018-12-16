using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MinutoSeguros.Opt.FeedReader.Test.Helpers
{
  public static class SyndicationFeedHelper
  {
    public static SyndicationFeed GetSyndicationFeed()
    {
      using (var streamReader = new StreamReader(@"feed.xml"))
      {
        using (var xmlReader = XmlReader.Create(streamReader))
        {
          var syndicationFeed = SyndicationFeed.Load(xmlReader);

          xmlReader.Close();

          return syndicationFeed;
        }
      }
    }

    public static SyndicationItem GetSyndicationItem(int indexItem)
    {
      var syndicationFeed = GetSyndicationFeed();

      return syndicationFeed.Items.ElementAt(indexItem);
    }
  }
}
