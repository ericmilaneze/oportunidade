using System;
using System.Collections.Generic;
using System.Linq;

namespace MinutoSeguros.Opt.Domain.Feeds
{
  public class BlogPost
  {
    public string Title { get; }
    public string Content { get; }

    public BlogPost(string title, string content)
    {
      Title = title ?? "";
      Content = content ?? "";
    }

    public string[] GetWords()
    {
      string[] separators = new string[] { " ", ":", ";", ",", ".", "!", "\'", "\'s", "(", ")" };

      var titleWords = Title.ToLower()
        .Split(separators, StringSplitOptions.RemoveEmptyEntries);

      var contentWords = Content.ToLower()
        .Split(separators, StringSplitOptions.RemoveEmptyEntries);

      var ret = new List<string>();
      ret.AddRange(titleWords);
      ret.AddRange(contentWords);

      return ret.ToArray();
    }
  }
}