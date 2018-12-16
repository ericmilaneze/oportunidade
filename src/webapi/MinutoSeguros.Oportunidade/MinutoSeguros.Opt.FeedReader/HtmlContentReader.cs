using MinutoSeguros.Opt.FeedReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinutoSeguros.Opt.FeedReader
{
  public class HtmlContentReader : IHtmlContentReader
  {
    public string GetHtmlContent(SyndicationItem item)
    {
      var ext = item?.ElementExtensions?
        .FirstOrDefault(e =>
          e.GetObject<XElement>()?.Name?.Namespace == "http://purl.org/rss/1.0/modules/content/" &&
          e.GetObject<XElement>()?.Name?.LocalName == "encoded");

      return ext?.GetObject<XElement>()?.Value;
    }
  }
}
