using MonoDevelop.Ide.CodeCompletion;

namespace MonoDevelop.GapHighlighting.Suggest
{
    public interface IFullSuggestListKeeper
    {
        CompletionDataList GetSuggestList();
    }

    public class FullSuggestListKeeper : IFullSuggestListKeeper
    {
        private static CompletionDataList innerCompletionDataList;

        public static void SetSuggestList(CompletionDataList completionDataList)
        {
            innerCompletionDataList = completionDataList;
        } 

        public CompletionDataList GetSuggestList()
        {
            return innerCompletionDataList;
        }
    }
}