using MinutoSeguros.Opt.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MinutoSeguros.Opt.Domain.Services
{
  public class WordsRemovalService : IWordsRemovalService
  {
    public string[] RemoveWords(string[] words, string[] wordsToRemove)
    {
      List<string> ret = new List<string>();

      words?
        .ToList()
        .ForEach(w =>
        {
          if (!wordsToRemove?.Contains(w) ?? false)
            ret.Add(w);
        });

      return ret.ToArray();
    }
  }
}
