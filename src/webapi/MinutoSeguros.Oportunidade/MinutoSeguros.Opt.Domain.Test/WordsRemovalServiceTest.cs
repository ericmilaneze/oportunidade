using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MinutoSeguros.Opt.Domain.Services;

namespace MinutoSeguros.Opt.Domain.Test
{
  [TestClass]
  public class WordsRemovalServiceTest
  {
    readonly string[] _words = new string[]
    {
      "testando",
      "o",
      "meu",
      "teste",
      "1",
      "obtendo",
      "e",
      "o",
      "meu",
      "número",
      "é",
      "a",
      "tarefa"
    };

    readonly string[] _wordsToRemove = new string[] { "a", "o" };

    [TestMethod]
    public void RemoveWords()
    {
      WordsRemovalService wordsRemovalService = new WordsRemovalService();

      var res = wordsRemovalService.RemoveWords(_words, _wordsToRemove);

      for (int i = 0; i < _wordsToRemove.Length; i++)
        Assert.IsFalse(res.Contains(_wordsToRemove[i]));
    }

    [TestMethod]
    public void RemoveWords_WordsIsNull()
    {
      WordsRemovalService wordsRemovalService = new WordsRemovalService();

      var res = wordsRemovalService.RemoveWords(null, _wordsToRemove);

      for (int i = 0; i < _words.Length; i++)
        Assert.IsFalse(res.Contains(_words[i]));
    }

    [TestMethod]
    public void RemoveWords_WordsToRemoveIsNull()
    {
      WordsRemovalService wordsRemovalService = new WordsRemovalService();

      var res = wordsRemovalService.RemoveWords(_words, null);

      for (int i = 0; i < _words.Length; i++)
        Assert.IsFalse(res.Contains(_words[i]));
    }
  }
}
