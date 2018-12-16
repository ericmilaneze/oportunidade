using MinutoSeguros.Opt.Domain.Feeds;
using System.Collections.Generic;

namespace MinutoSeguros.Opt.WebAPI.Models
{
  public class FeedInformationModel
  {
    public ICollection<BlogPostWord> TopTenWords { get; set; }
    public ICollection<WordCountPerPost> WordCountPerPost { get; set; }
  }
}