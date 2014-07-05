namespace MonoDevelop.GapHighlighting.Suggest
{
    public interface ISuggestProvider
    {
        ComplectionResult Complete(char charToComplete);
    }

    public class SuggestProvider : ISuggestProvider
    {
        private const int triggerWordLength = 1;
        private readonly IFullSuggestListKeeper fullSuggestListKeeper;
        private readonly ICharValidator charValidator;

        public SuggestProvider(
            IFullSuggestListKeeper fullSuggestListKeeper,
            ICharValidator charValidator)
        {
            this.fullSuggestListKeeper = fullSuggestListKeeper;
            this.charValidator = charValidator;
        }

        public ComplectionResult Complete(char charToComplete)
        {
            if (charValidator.IsCharValid (charToComplete))
            {
                var completionDataList = fullSuggestListKeeper.GetSuggestList ();
                return new ComplectionResult(triggerWordLength, completionDataList);
            }

            return new ComplectionResult(triggerWordLength, null);
        } 
    }
}