using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoDevelop.Projects;
using MonoDevelop.Core;
using System.IO;

namespace MonoDevelop.GapHighlighting
{
    class GapLanguageBinding : ILanguageBinding
    {
        public string Language
        {
            get { return "gap"; }
        }

        public string SingleLineCommentTag
        {
            get { return "#"; }
        }

        public string BlockCommentStartTag
        {
            get { return "#"; }
        }

        public string BlockCommentEndTag
        {
            get { return "#"; }
        }

        public bool IsSourceCodeFile(FilePath fileName){return StringComparer.OrdinalIgnoreCase.Equals (Path.GetExtension (fileName), ".g");}
        public FilePath GetFileName(FilePath fileNameWithoutExtension) {return fileNameWithoutExtension + ".g";}
    }
}
