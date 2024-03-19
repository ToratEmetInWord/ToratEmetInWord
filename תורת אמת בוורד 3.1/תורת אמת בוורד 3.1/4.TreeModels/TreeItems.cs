using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace תורת_אמת_בוורד_3._1.TreeModels
{
    public class FolderTreeItem: TreeItem { }
    public class FileTreeItem : TreeItem { }
    public class TreeItem: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<object> _children = new ObservableCollection<object>();
        public ObservableCollection<object> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                OnPropertyChanged(nameof(Children));
            }
        }

        private TreeItem _parent;
        public TreeItem Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                OnPropertyChanged(nameof(Parent));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        private bool? _isChecked = false;
        public bool? IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                    UpdateChildCheckSatus(value);
                    UpdateParentCheckSatus();
                }
            }
        }

        private bool? _isChecked2 = false;
        public bool? IsChecked2
        {
            get { return _isChecked2; }
            set
            {
                if (_isChecked2 != value)
                {
                    _isChecked2 = value;
                    OnPropertyChanged(nameof(IsChecked2));
                }
            }
        }

        private bool? _isChecked3 = false;
        public bool? IsChecked3
        {
            get { return _isChecked3; }
            set
            {
                if (_isChecked3 != value)
                {
                    _isChecked3 = value;
                    OnPropertyChanged(nameof(IsChecked3));
                }
            }
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged(nameof(IsExpanded));
                }
            }
        }

        void UpdateChildCheckSatus(bool? value)
        {
            foreach (TreeItem child in Children)
            {
                if (value != null) { child.IsChecked = value; }
            }
        }
        void UpdateParentCheckSatus()
        {
            if (Parent != null)
            {
                bool allChecked = Parent.Children.OfType<TreeItem>().All(child => child.IsChecked == true);
                bool allUnchecked = Parent.Children.OfType<TreeItem>().All(child => child.IsChecked == false);

                if (allChecked) { Parent.IsChecked = true; }
                else if (allUnchecked) { Parent.IsChecked = false; }
                else { Parent.IsChecked = null; }
            }
        }
        public void AddChild(TreeItem child)
        {
            if (child is TreeItem TreeItem)
            {
                TreeItem.Parent = this;
                Children.Add(child);
            }
        }
        public void InsertChild(TreeItem child)
        {
            if (child is TreeItem TreeItem)
            {
                TreeItem.Parent = this;
                Children.Insert(0, child);
            }
        }
    }
}
