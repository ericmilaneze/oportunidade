using System;
using System.Configuration;

namespace MinutoSeguros.Opt.WebAPI.Helpers
{
  public static class ConfigHelper
  {
    public static string GetFeedUrl()
    {
      return ConfigurationManager.AppSettings["FeedUrl"];
    }

    public static string GetArticlesAndPrepositions()
    {
      return ConfigurationManager.AppSettings["ArticlesAndPrepositions"];
    }

    public static int GetFeedPostCount()
    {
      return Convert.ToInt32(ConfigurationManager.AppSettings["FeedPostCount"]);
    }
  }
}