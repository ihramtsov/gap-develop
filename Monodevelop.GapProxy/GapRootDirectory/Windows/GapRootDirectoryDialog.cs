using System;
using Gtk;

namespace MonoDevelop.GapProxy.GapRootDirectory.Windows
{
    public class GapRootDirectoryDialog : Dialog
    {
        private const string browseButtonText = "browse";
        private const string dialodName = "Select GAP root folder";
        private readonly IGapRootDirectoryProcessor gapRootDirectoryProcessor;

        public GapRootDirectoryDialog (IGapRootDirectoryProcessor gapRootDirectoryProcessor)
        {
            this.gapRootDirectoryProcessor = gapRootDirectoryProcessor;
            InitializeComponents();
        }

        public void InitializeComponents()
        {
            Modal = true;
            this.Title = dialodName;

            var browseButton = (Button) AddButton(browseButtonText, ResponseType.Yes);
            browseButton.Clicked += OnClick;
        }

        void OnClick(object sender, EventArgs args)
        {
            var selectGapRootDirectory = gapRootDirectoryProcessor.SelectGapRootDirectory ();
        }
    }
}