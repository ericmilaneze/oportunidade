using System;
using System.Collections.Generic;
using System.Text;

namespace MinutoSeguros.Opt.Domain.Feeds
{
  public class Feed
  {
    public ICollection<BlogPost> BlogPosts { get; }

    public Feed(ICollection<BlogPost> blogPosts)
    {
      BlogPosts = blogPosts;
    }
  }
}
