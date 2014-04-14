using Mono.TextEditor.Highlighting;
using MonoDevelop.Components.Commands;

namespace MonoDevelop.GapHighlighting
{
    public class ConfigureHighlightingCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            SyntaxModeService.LoadStylesAndModes (this.GetType ().Assembly);
        }
    }
}