//..\src\core\MonoDevelop.Ide\MonoDevelop.Ide.Commands\

using GapUtils.Folder;
using MonoDevelop.Components.Commands;
using MonoDevelop.GapProxy.GapRootDirectory;
using MonoDevelop.GapProxy.GapRootDirectory.Windows;

namespace MonoDevelop.GapProxy
{
    class InsertDateHandler : CommandHandler
    {
        protected override void Run()
        {
            var gapRootDirectoryWindow =
                new GapRootDirectoryWindow (new GapRootDirectoryProcessor (new FolderFromFileSystemPicker (),
                                                                           new GapRootDirectoryPersistor ()));
            gapRootDirectoryWindow.Show ();
        }
    }
}
