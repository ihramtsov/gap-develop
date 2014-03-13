//..\src\core\MonoDevelop.Ide\MonoDevelop.Ide.Commands\
using MonoDevelop.Components.Commands;
using System;
using Gtk;

using MonoDevelop.Ide.Gui.Dialogs;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Projects;
using MonoDevelop.Ide.Gui.Content;
using System.IO;
using MonoDevelop.Ide.Projects;
using MonoDevelop.Ide.Desktop;
using System.Linq;

namespace MonoDevelop.GapProxy
{
    class InsertDateHandler : CommandHandler
    {
        protected override void Run()
        {

            Application.Init();

            //Create the Window
            Window myWin = new Window("My first GTK# Application! ");
            myWin.Resize(400, 100);
            Fixed fix = new Fixed();


            Button open = new Button("open");
            fix.Put(open, 350, 70);
            myWin.Add(fix);
            open.Clicked += OnClick;
            //Show Everything     
            myWin.ShowAll();


            Application.Run();
        }

        void OnClick(object sender, EventArgs args)
        {
            var dlg = new OpenFileDialog(GettextCatalog.GetString("File to Open"), Gtk.FileChooserAction.Open)
            {
                TransientFor = MonoDevelop.Ide.IdeApp.Workbench.RootWindow,
                ShowEncodingSelector = true,
                ShowViewerSelector = true,
            };
            if (!dlg.Run())
                return;

            var file = dlg.SelectedFile;

            if (dlg.SelectedViewer != null)
            {
                dlg.SelectedViewer.OpenFile(file, dlg.Encoding);
                return;
            }

            if (Services.ProjectService.IsWorkspaceItemFile(file) || Services.ProjectService.IsSolutionItemFile(file))
            {
                MonoDevelop.Ide.IdeApp.Workspace.OpenWorkspaceItem(file, dlg.CloseCurrentWorkspace);
            }
            else
                MonoDevelop.Ide.IdeApp.Workbench.OpenDocument(file, dlg.Encoding);
        }

    }
}