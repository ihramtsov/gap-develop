using MonoDevelop.Ide.CodeCompletion;

namespace MonoDevelop.GapHighlighting.Suggest
{
    public class ComplectionResult
    {
        public ComplectionResult(int triggerWordLength, ICompletionDataList completionDataList)
        {
            TriggerWordLength = triggerWordLength;
            CompletionDataList = completionDataList;
        }

        public int TriggerWordLength { get; private set; }
        public ICompletionDataList CompletionDataList { get; private set; }
    }
}