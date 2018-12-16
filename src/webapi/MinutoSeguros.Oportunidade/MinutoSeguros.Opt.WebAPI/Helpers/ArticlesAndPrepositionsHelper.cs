using System.Configuration;

namespace MinutoSeguros.Opt.WebAPI.Helpers
{
  public static class ArticlesAndPrepositionsHelper
  {
    public static string[] Get()
    {
      string config = ConfigHelper.GetArticlesAndPrepositions();

      return config.Split(',');
    }
  }
}