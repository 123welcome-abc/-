using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace TODO
{
    public class DataItem : INotifyPropertyChanged
    {
        static int _Count = 0;
        [Key]
        public string Id { get => _Id; set { if (_Id == value) return; _Id = value; OnPropertyChanged(nameof(Id)); } }
        private string _Id = $"{++_Count:000}";

        
        public string Value { get => _Value; set { if (_Value == value) return; _Value = value; OnPropertyChanged(nameof(Value)); } }
        private string _Value;

        
        public string CurrentImagePath { get => _CurrentImagePath; set { if (_CurrentImagePath == value) return; _CurrentImagePath = value; OnPropertyChanged(nameof(CurrentImagePath)); } }
        private string _CurrentImagePath = "notop.png";

        //时间戳
        
        private DateTime _creationTime= DateTime.Now;
        public DateTime CreationTime
        {
            get { return _creationTime; }
            set
            {
                if (_creationTime != value)
                {
                    _creationTime = value;
                    OnPropertyChanged(nameof(CreationTime));
                }
            }
        }

        public string Note { get => _Note; set { if (_Note == value) return; _Note = value; OnPropertyChanged(nameof(Note)); } }
        private string _Note;


        private string _CompletionTime;
        public string CompletionTime
        {
            get { return _CompletionTime; }
            set
            {
                if (_CompletionTime != value)
                {
                    _CompletionTime = value;
                    OnPropertyChanged(nameof(CompletionTime));
                }
            }
        }

        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler? PropertyChanged;
    }


}
