//..\src\core\MonoDevelop.Ide\MonoDevelop.Ide.Commands\
using MonoDevelop.Components.Commands;
using System;
using Gtk;

namespace MonoDevelop.GapProxy
{
    class InsertDateHandler : CommandHandler
    {
        protected override void Run()
        {
            Application.Init();

            //Create the Window
            Window myWin = new Window("My first GTK# Application! ");
            myWin.Resize(200, 200);

            //Create a label and put some text in it.     
            Label myLabel = new Label();
            myLabel.Text = "Hello World!!!!";

            //Add the label to the form     
            myWin.Add(myLabel);

            Button myButton = new Button("close");
            myWin.Add(myButton);

            //Show Everything     
            myWin.ShowAll();

            Application.Run(); 
        }

        protected override void Update(CommandInfo info)
        {
        }
    }
}
