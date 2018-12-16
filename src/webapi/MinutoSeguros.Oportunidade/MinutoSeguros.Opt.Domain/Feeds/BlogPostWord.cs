using System;
using System.Collections.Generic;
using System.Text;

namespace MinutoSeguros.Opt.Domain.Feeds
{
  public class BlogPostWord
  {
    public int WordCount { get; }
    public string Word { get; }

    public BlogPostWord(string word, int wordCount)
    {
      Word = word;
      WordCount = wordCount;
    }
  }
}
