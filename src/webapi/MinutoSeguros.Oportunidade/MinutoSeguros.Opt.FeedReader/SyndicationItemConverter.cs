using MinutoSeguros.Opt.Domain.Feeds;
using MinutoSeguros.Opt.FeedReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace MinutoSeguros.Opt.FeedReader
{
  public class SyndicationItemConverter : ISyndicationItemConverter
  {
    IHtmlContentReader _htmlContentReader;
    ITextContentFromHtml _textContentFromHtml;

    public SyndicationItemConverter(IHtmlContentReader htmlContentReader, ITextContentFromHtml textContentFromHtml)
    {
      _htmlContentReader = htmlContentReader;
      _textContentFromHtml = textContentFromHtml;
    }

    public IEnumerable<BlogPost> GetBlogPosts(IEnumerable<SyndicationItem> syndicationItems)
    {
      foreach (var syndicationItem in syndicationItems ?? Enumerable.Empty<SyndicationItem>())
      {
        string htmlContent = _htmlContentReader.GetHtmlContent(syndicationItem);

        yield return new BlogPost(
          title: syndicationItem?.Title?.Text, 
          content: _textContentFromHtml.GetContent(htmlContent));
      }
    }
  }
}
