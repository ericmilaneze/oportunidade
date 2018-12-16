using HtmlAgilityPack;
using MinutoSeguros.Opt.FeedReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutoSeguros.Opt.FeedReader
{
  public class TextContentFromHtml : ITextContentFromHtml
  {
    public string GetContent(string htmlContent)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(htmlContent);

      string content = HtmlEntity.DeEntitize(doc.DocumentNode.InnerText)
        .Replace("\n", " ")
        .Replace("\r", " ");

      return content;
    }
  }
}
