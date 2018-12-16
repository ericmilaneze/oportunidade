using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinutoSeguros.Opt.FeedReader.Interfaces;
using Moq;
using System.Linq;

namespace MinutoSeguros.Opt.FeedReader.Test
{
  [TestClass]
  public class SyndicationItemConverterTest
  {
    IHtmlContentReader _htmlContentReaderMocked;
    ITextContentFromHtml _textContentFromHtmlMocked;

    [TestInitialize]
    public void Initialize()
    {
      Mock<IHtmlContentReader> mockHtmlContentReader = new Mock<IHtmlContentReader>();
      mockHtmlContentReader
        .Setup(m => m.GetHtmlContent(It.IsAny<SyndicationItem>()))
        .Returns(() => It.IsAny<string>());

      Mock<ITextContentFromHtml> mockTextContentFromHtml = new Mock<ITextContentFromHtml>();
      mockTextContentFromHtml
        .Setup(m => m.GetContent(It.IsAny<string>()))
        .Returns(() => It.IsAny<string>());

      _htmlContentReaderMocked = mockHtmlContentReader.Object;
      _textContentFromHtmlMocked = mockTextContentFromHtml.Object;
    }

    [TestMethod]
    public void GetBlogPosts()
    {
      List<SyndicationItem> syndicationItems = new List<SyndicationItem>()
      {
        new SyndicationItem("Title 1", "", new Uri("http://teste")),
        new SyndicationItem("Title 2", "", new Uri("http://teste")),
        new SyndicationItem("Title 3", "", new Uri("http://teste")),
        new SyndicationItem("Title 4", "", new Uri("http://teste"))
      };

      SyndicationItemConverter syndicationItemConverter = new SyndicationItemConverter(_htmlContentReaderMocked, _textContentFromHtmlMocked);

      var blogPosts = syndicationItemConverter.GetBlogPosts(syndicationItems);

      Assert.AreEqual(syndicationItems.Count, blogPosts.Count());

      for (int i = 0; i < syndicationItems.Count; i++)
        Assert.AreEqual(syndicationItems[i].Title.Text, blogPosts.ElementAt(i).Title);
    }

    [TestMethod]
    public void GetBlogPosts_SyndicationItems_Null()
    {
      SyndicationItemConverter syndicationItemConverter = new SyndicationItemConverter(_htmlContentReaderMocked, _textContentFromHtmlMocked);

      List<SyndicationItem> syndicationItems = null;

      var blogPosts = syndicationItemConverter.GetBlogPosts(syndicationItems);

      Assert.AreEqual(0, blogPosts.Count());
    }
  }
}
