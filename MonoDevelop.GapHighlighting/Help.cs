using System;
using MonoDevelop.Core;
using MonoDevelop.GapHighlighting.Suggest;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.Ide.CodeCompletion;

namespace MonoDevelop.GapHighlighting
{
    class Help : CompletionTextEditorExtension 
    {
        private readonly SuggestProvider suggestProvider = new SuggestProvider (new FullSuggestListKeeper (), new CharValidator ());

        public override string CompletionLanguage
        {
            get
            {
                return "Gap";
            }
        }

        public override ICompletionDataList HandleCodeCompletion(
            CodeCompletionContext completionContext, char completionChar, ref int triggerWordLength)
        {
            try {
                var completionDataList = suggestProvider.Complete (completionChar);
                triggerWordLength = completionDataList.TriggerWordLength;
                return completionDataList.CompletionDataList;
            }
            catch (Exception e)
            {
                LoggingService.LogError("Unexpected code completion exception." + Environment.NewLine +
                    "FileName: " + document.FileName + Environment.NewLine +
                    "Position: line=" + completionContext.TriggerLine + " col=" + completionContext.TriggerLineOffset + Environment.NewLine +
                    "Line text: " + Document.Editor.GetLineText(completionContext.TriggerLine),
                    e);
                return null;
            }
            
        }
	}
}
