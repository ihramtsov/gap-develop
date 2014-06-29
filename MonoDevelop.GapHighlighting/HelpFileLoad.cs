using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoDevelop.Ide.CodeCompletion;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Components.Commands;

namespace MonoDevelop.GapHighlighting
{
    class HelpFileLoad : CommandHandler
    {
        public static CompletionDataList list = new CompletionDataList();
        protected override void Run()
        {
            readFile();
        }
        private void readFile()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"..\..\resources\function.txt");
                foreach (string x in lines)
                {
                    list.Add(x);
                }
                list.Sort();
            }
            catch (Exception e)
            {
                LoggingService.LogError("не удалось открыть файл с подсказкой");
            }

        }
    }
}
