using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinutoSeguros.Opt.Domain.Feeds;
using MinutoSeguros.Opt.Domain.Interfaces;
using MinutoSeguros.Opt.Domain.Services;
using Moq;

namespace MinutoSeguros.Opt.Domain.Test
{
  [TestClass]
  public class BlogPostWordCounterServiceTest
  {
    [TestMethod]
    public void GetWordCount()
    {
      Mock<IWordsRemovalService> mockWordsRemovalService = new Mock<IWordsRemovalService>();

      mockWordsRemovalService
        .Setup(m => m.RemoveWords(It.IsAny<string[]>(), It.IsAny<string[]>()))
        .Returns(() => new string[] { "teste1", "teste2" });

      BlogPostWordCounterService blogPostWordCounterService = new BlogPostWordCounterService(mockWordsRemovalService.Object);
      int res = blogPostWordCounterService.GetWordCount(new BlogPost("abc", "xyz"), new string[] { });

      Assert.AreEqual(2, res);
    }
  }
}
