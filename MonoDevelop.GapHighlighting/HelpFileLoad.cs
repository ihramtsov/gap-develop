using MonoDevelop.GapHighlighting.Suggest;
using MonoDevelop.Components.Commands;

namespace MonoDevelop.GapHighlighting
{
    public class HelpFileLoad : CommandHandler
    {
        private readonly ISuggestBuilder suggestBuilder;

        public HelpFileLoad ()
        {
            suggestBuilder = new SuggestBuilder ();
        }
        protected override void Run()
        {
            ReadFile();
        }

        private void ReadFile()
        {
            var completionDataList = suggestBuilder.BuildList ();
            FullSuggestListKeeper.SetSuggestList(completionDataList);   
        }
    }
}
