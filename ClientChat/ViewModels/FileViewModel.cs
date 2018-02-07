using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels
{
    class FileViewModel : PropertyChangedBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private bool _editorIsFocused = false;
        public bool EditorIsVisible
        {
            get { return _editorIsFocused; }
        }
        public bool ReaderIsVisible
        {
            get { return !EditorIsVisible; }
        }
        public bool EditorIsFocused
        {
            get { return _editorIsFocused; }
            set
            {
                if (_editorIsFocused != value)
                {
                    _editorIsFocused = value;
                    NotifyOfPropertyChange(() => EditorIsFocused);
                    NotifyOfPropertyChange(() => EditorIsVisible);
                    NotifyOfPropertyChange(() => ReaderIsVisible);
                }
            }
        }
        private bool _fileIsSelected = false;
        public bool FileIsSelected
        {
            get { return _fileIsSelected; }
            set
            {
                if (_fileIsSelected != value)
                {
                    _fileIsSelected = value;
                    NotifyOfPropertyChange(() => FileIsSelected);
                    NotifyOfPropertyChange(() => CanRename);
                }
            }
        }
        public bool CanRename
        {
            get { return FileIsSelected; }
        }

        public void Rename()
        {
            EditorIsFocused = true;
        }
    }
}
