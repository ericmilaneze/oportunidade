namespace MinutoSeguros.Opt.Domain.Interfaces
{
  public interface IWordsRemovalService
  {
    string[] RemoveWords(string[] words, string[] wordsToRemove);
  }
}
