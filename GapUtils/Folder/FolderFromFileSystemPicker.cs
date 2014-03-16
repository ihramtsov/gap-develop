using Gtk;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui.Dialogs;

namespace GapUtils.Folder
{
    public interface IFolderFromFileSystemPicker
    {
        string PickFolder();
    }

    public class FolderFromFileSystemPicker : IFolderFromFileSystemPicker
    {
        public string PickFolder()
        {
            var dlg = new OpenFileDialog(GettextCatalog.GetString("Folder to Open"), FileChooserAction.SelectFolder)
            {
                TransientFor = MonoDevelop.Ide.IdeApp.Workbench.RootWindow,
                ShowEncodingSelector = true,
                ShowViewerSelector = true,
            };
            if (!dlg.Run())
                return string.Empty;

            return dlg.SelectedFile;

        } 
    }
}