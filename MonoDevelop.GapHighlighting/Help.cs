using System;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.Ide.CodeCompletion;

namespace MonoDevelop.GapHighlighting
{
    class Help : CompletionTextEditorExtension 
    {

        ICompletionDataList InternalHandleCodeCompletion(CodeCompletionContext completionContext, char completionChar, bool ctrlSpace, ref int triggerWordLength)
        {
            CompletionDataList list = new CompletionDataList();
            list.Sort();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"..\..\resources\function.txt");
                foreach (string x in lines)
                {
                    list.Add(x);
                }
                return list.Count > 0 ? list : null;
            }
            catch (Exception e)
            {
                LoggingService.LogError("Unexpected code completion exception." + Environment.NewLine +
                    "FileName: " + Document.FileName + Environment.NewLine +
                    "Position: line=" + completionContext.TriggerLine + " col=" + completionContext.TriggerLineOffset + Environment.NewLine +
                    "Line text: " + Document.Editor.GetLineText(completionContext.TriggerLine),
                    e);
                return null;
            }
        }

        public override string CompletionLanguage
        {
            get
            {
                return "Gap";
            }
        }

        public override ICompletionDataList HandleCodeCompletion(CodeCompletionContext completionContext, char completionChar, ref int triggerWordLength)
        {
            //	var timer = Counters.ResolveTime.BeginTiming ();
            try
            {
                if (char.IsLetterOrDigit(completionChar) || completionChar == '_')
                {
                    if (completionContext.TriggerOffset > 1 && char.IsLetterOrDigit(document.Editor.GetCharAt(completionContext.TriggerOffset - 2)))
                        return null;
                    triggerWordLength = 1;
                }
                return InternalHandleCodeCompletion(completionContext, completionChar, false, ref triggerWordLength);
            }
            catch (Exception e)
            {
                LoggingService.LogError("Unexpected code completion exception." + Environment.NewLine +
                    "FileName: " + Document.FileName + Environment.NewLine +
                    "Position: line=" + completionContext.TriggerLine + " col=" + completionContext.TriggerLineOffset + Environment.NewLine +
                    "Line text: " + Document.Editor.GetLineText(completionContext.TriggerLine),
                    e);
                return null;
            }
            
        }

        //public override ICompletionDataList CodeCompletionCommand(CodeCompletionContext completionContext)
        //{

        //    return InternalHandleCodeCompletion(completionContext, completionChar, false, ref triggerWordLength);
        //}

        internal Mono.TextEditor.TextEditorData TextEditorData
        {
            get
            {
                var doc = Document;
                if (doc == null)
                    return null;
                return doc.Editor;
            }
        }
        public new MonoDevelop.Ide.Gui.Document Document
        {
            get
            {
                return base.document;
            }
        }
	}
}
