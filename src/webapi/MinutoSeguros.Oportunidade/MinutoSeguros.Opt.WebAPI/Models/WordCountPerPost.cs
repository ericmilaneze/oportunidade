using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinutoSeguros.Opt.WebAPI.Models
{
  public class WordCountPerPost
  {
    public string PostTitle { get; set; }
    public int WordCount { get; set; }

    public WordCountPerPost(string postTitle, int wordCount)
    {
      PostTitle = postTitle;
      WordCount = wordCount;
    }
  }
}