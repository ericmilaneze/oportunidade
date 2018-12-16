using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinutoSeguros.Opt.Domain.Feeds;
using System.Linq;

namespace MinutoSeguros.Opt.Domain.Test
{
  [TestClass]
  public class BlogPostTest
  {
    [TestMethod]
    public void GetWords()
    {
      BlogPost blogPost = new BlogPost(" Testando o meu teste 1 (testando)", " Obtendo e  testando o meu   teste número 1 é a tarefa...  ");

      string[] expectedWords = new string[]
      {
        "testando",
        "o",
        "meu",
        "teste",
        "1",
        "testando",
        "obtendo",
        "e",
        "testando",
        "o",
        "meu",
        "teste",
        "número",
        "1",
        "é",
        "a",
        "tarefa"
      };

      var words = blogPost.GetWords().ToList();

      Assert.AreEqual(17, words.Count());

      for (int i = 0; i < expectedWords.Length; i++)
        Assert.IsTrue(words.IndexOf(expectedWords[i]) != -1);
    }
  }
}
