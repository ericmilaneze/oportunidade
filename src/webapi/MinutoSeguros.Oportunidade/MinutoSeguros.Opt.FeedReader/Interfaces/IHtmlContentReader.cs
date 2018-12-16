using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace MinutoSeguros.Opt.FeedReader.Interfaces
{
  public interface IHtmlContentReader
  {
    string GetHtmlContent(SyndicationItem item);
  }
}
