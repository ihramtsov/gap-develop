using System;
using System.IO;
using System.Linq;
using MonoDevelop.Core;
using MonoDevelop.Ide.CodeCompletion;

namespace MonoDevelop.GapHighlighting.Suggest
{
    public interface ISuggestBuilder
    {
        CompletionDataList BuildList ();
    }

    public class SuggestBuilder : ISuggestBuilder
    {
        public CompletionDataList BuildList ()
        {
            try {
                var lines = File.ReadAllLines(@"..\..\resources\function.txt").Select(l => new CompletionData(l));
                return new CompletionDataList(lines);
            }
            catch (Exception) {
                LoggingService.LogError("не удалось открыть файл с подсказкой");
                throw;
            }
        }
    }
}