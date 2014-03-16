using System;
using Gtk;

namespace MonoDevelop.GapProxy.GapRootDirectory.Windows
{
    public class GapRootDirectoryWindow
    {
        private readonly IGapRootDirectoryProcessor gapRootDirectoryProcessor;

        public GapRootDirectoryWindow (IGapRootDirectoryProcessor gapRootDirectoryProcessor)
        {
            this.gapRootDirectoryProcessor = gapRootDirectoryProcessor;
        }

        public void Show()
        {
            //Igor: Это здесь зачем??? 
            //            Application.Init();

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
            gapRootDirectoryProcessor.SelectGapRootDirectory ();
        }
    }
}