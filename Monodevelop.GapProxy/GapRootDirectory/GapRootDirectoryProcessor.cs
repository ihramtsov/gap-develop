using GapUtils.Folder;

namespace MonoDevelop.GapProxy.GapRootDirectory
{
    public interface IGapRootDirectoryProcessor
    {
        void SelectGapRootDirectory();
    }

    public class GapRootDirectoryProcessor : IGapRootDirectoryProcessor
    {
        private readonly IFolderFromFileSystemPicker folderFromFileSystemPicker;
        private readonly IGapRootDirectoryPersistor gapRootDirectoryPersistor;

        public GapRootDirectoryProcessor (
            IFolderFromFileSystemPicker folderFromFileSystemPicker,
            IGapRootDirectoryPersistor gapRootDirectoryPersistor)
        {
            this.folderFromFileSystemPicker = folderFromFileSystemPicker;
            this.gapRootDirectoryPersistor = gapRootDirectoryPersistor;
        }

        public void SelectGapRootDirectory()
        {
            var pickFolder = folderFromFileSystemPicker.PickFolder ();

            if (!string.IsNullOrEmpty (pickFolder))
                gapRootDirectoryPersistor.PersistGapRootDirectoryPath(pickFolder);
        }
    }
}