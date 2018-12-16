using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinutoSeguros.Opt.Domain.Feeds;
using MinutoSeguros.Opt.Domain.Interfaces;
using MinutoSeguros.Opt.Domain.Services;
using Moq;

namespace MinutoSeguros.Opt.Domain.Test
{
  [TestClass]
  public class FeedTopTenWordsServiceTest
  {
    [TestMethod]
    public void GetTopTen()
    {
      Mock<IWordsRemovalService> mockWordsRemovalService = new Mock<IWordsRemovalService>();

      mockWordsRemovalService
        .Setup(m => m.RemoveWords(It.IsAny<string[]>(), It.IsAny<string[]>()))
        .Returns(() => new string[] { "teste1", "teste2", "teste2", "teste3", "teste3", "teste3" });

      var posts = new List<BlogPost>()
      {
        new BlogPost("Testando o teste", "Esse teste é para testar o teste"),
        new BlogPost("Testando o teste", "Esse teste é para testar o teste")
      };

      Feed feed = new Feed(posts);

      FeedTopTenWordsService feedTopTenWordsService = new FeedTopTenWordsService(mockWordsRemovalService.Object);
      var res = feedTopTenWordsService.GetTopTen(feed, new string[] { });

      Assert.AreEqual(3, res.Count);
    }
  }
}
