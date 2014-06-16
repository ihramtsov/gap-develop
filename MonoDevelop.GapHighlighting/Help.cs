using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoDevelop.Core;
using MonoDevelop.Ide.FindInFiles;
using System.Threading;
using MonoDevelop.SourceEditor;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Content;

using ICSharpCode.NRefactory.CSharp.Resolver;

using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.Completion;
using MonoDevelop.Ide.CodeCompletion;

namespace MonoDevelop.GapHighlighting
{
    class Help : CompletionTextEditorExtension 
    {
        ICompletionDataList InternalHandleCodeCompletion(CodeCompletionContext completionContext, bool ctrlSpace) {
            CompletionDataList list = new CompletionDataList();
            list.AutoCompleteEmptyMatchOnCurlyBrace = true;
            list.Add("Подсказка =)");
            return list;
        }
        public override string CompletionLanguage
        {
            get
            {
                return "C#";
            }
        }

        public override ICompletionDataList HandleCodeCompletion(CodeCompletionContext completionContext, char completionChar, ref int triggerWordLength)
        {
                return InternalHandleCodeCompletion(completionContext, true);
        }

        public override ICompletionDataList CodeCompletionCommand(CodeCompletionContext completionContext)
        {
            
            return InternalHandleCodeCompletion(completionContext,true);
        }

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
