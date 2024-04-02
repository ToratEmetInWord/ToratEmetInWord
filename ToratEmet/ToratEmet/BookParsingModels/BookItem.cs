using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.TreeModels;


namespace ToratEmet.BookParsingModels
{
    public class BookItem
    {
        public string Title { get; set; }
        public string FilePath { get; set; }

        public string Info = "";

        public IdItem RootItem = new IdItem { Level = 0, };

        public ObservableCollection<object> RelativeBooks = new ObservableCollection<object>();
        public ObservableCollection<IdItem> AllChapters = new ObservableCollection<IdItem>();
    }

    public class ChapterItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddChild(ChapterItem chapterItem)
        {
            Children.Add(chapterItem);
            if (Parent != null && !Parent.IdChildren.Contains(this) && this is IdItem)
            {
                Parent.IdChildren.Add(this);
            }
        }

        public string Content { get; set; }
        public ChapterItem Parent { get; set; }
        public int Level { get; set; }
        public string Id { get; set; }
        
        private string _shortId = "";
        public string ShortId
        {
            get { return _shortId; }
            set
            {
                if (_shortId != value)
                {
                    _shortId = value;
                    OnPropertyChanged(nameof(ShortId));
                }
            }
        }
        public  ObservableCollection<ChapterItem> _children = new ObservableCollection<ChapterItem>();
        public ObservableCollection<ChapterItem> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                OnPropertyChanged(nameof(Children));               
            }
        }

        private ObservableCollection<ChapterItem> _idchildren = new ObservableCollection<ChapterItem>();
        public ObservableCollection<ChapterItem> IdChildren
        {
            get { return _idchildren; }
            set
            {
                _idchildren = value;
                OnPropertyChanged(nameof(IdChildren));
            }
        }
    }

    public class IdItem : ChapterItem  { }

}
