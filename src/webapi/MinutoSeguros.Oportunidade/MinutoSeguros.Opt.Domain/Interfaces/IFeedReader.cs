using MinutoSeguros.Opt.Domain.Feeds;
using System.Threading.Tasks;

namespace MinutoSeguros.Opt.Domain.Interfaces
{
  public interface IFeedReader
  {
    Feed GetFeed(string feedUrl, int postCount);
  }
}
