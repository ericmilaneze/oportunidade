using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using MinutoSeguros.Opt.Domain.Feeds;

namespace MinutoSeguros.Opt.FeedReader.Interfaces
{
  public interface ISyndicationItemConverter
  {
    IEnumerable<BlogPost> GetBlogPosts(IEnumerable<SyndicationItem> syndicationItems);
  }
}