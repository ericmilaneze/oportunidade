using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinutoSeguros.Opt.FeedReader.Test
{
  [TestClass]
  public class TextContentFromHtmlTest
  {
    [TestMethod]
    public void GetContent()
    {
      string html = "<p>Teste</p><!--teste-->\r\n";
      string expectedResult = "Teste  ";

      var textContentFromHtml = new TextContentFromHtml();
      string content = textContentFromHtml.GetContent(html);

      Assert.AreEqual(expectedResult, content);
    }

    [TestMethod]
    public void GetContentNewLinesInHtml()
    {
      string html = "<p><!--teste-->Teste\r\n</p>";
      string expectedResult = "Teste  ";

      var textContentFromHtml = new TextContentFromHtml();
      string content = textContentFromHtml.GetContent(html);

      Assert.AreEqual(expectedResult, content);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetContentNullHtml()
    {
      var textContentFromHtml = new TextContentFromHtml();
      string content = textContentFromHtml.GetContent(null);
    }
  }
}
