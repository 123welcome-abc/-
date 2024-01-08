//using Android.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Text.RegularExpressions;

namespace TODO
{

    public class MainModel : INotifyPropertyChanged
    {


        public ObservableCollection<DataItem> Items { get; set; } = new ObservableCollection<DataItem>();

        public ObservableCollection<DataItem> CompletedItems { get; set; } = new ObservableCollection<DataItem>();

        public ObservableCollection<DataItem> ItemsSearch { get; set; } = new ObservableCollection<DataItem>();

        public ObservableCollection<DataItem> CompletedSearch { get; set; } = new ObservableCollection<DataItem>();

        public MainModel()
        {
    
            NewCommand = new Command(OnNew_Execute, OnNew_CanExecute);
            DeleteCommand = new Command<DataItem>(OnDelete_Execute, OnDelete_CanExecute);   
            DeleteCompletedCommand = new Command<DataItem>(OnDeleteCompleted_Execute, OnDeleteCompleted_CanExecute);
            TopCommand = new Command<DataItem>(OnTop_Execute, OnTop_CanExecute);
            BottomCommand= new Command<DataItem>(OnBottom_Execute, OnBottom_CanExecute);
            BackCommand= new Command<DataItem>(OnBack_Execute, OnBack_CanExecute);
            ShowDetailCommand = new Command<DataItem>(OnShowDetail_Execute, OnShowDetail_CanExecute);
            SearchCommand= new Command<DataItem>(OnSearch_Execute, OnSearch_CanExecute);
            ResetCommand= new Command<DataItem>(OnReset_Execute, OnReset_CanExecute);
            LoadTodoItems();
           
        }

        private bool OnReset_CanExecute(DataItem item)
        {
            return true;
        }

        private void OnReset_Execute(DataItem item)
        {
            SearchText = string.Empty;
            LoadTodoItems();
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(CompletedItems));
        }

        private bool OnSearch_CanExecute(DataItem item)
        {
            return true;
        }

        private void OnSearch_Execute(DataItem item)
        {
            string searchText = SearchText;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var regex = new Regex(Regex.Escape(SearchText), RegexOptions.IgnoreCase);
                var searchItems = ItemsSearch
                        .Where(item => regex.IsMatch(item.Value))
                        .ToList();
                var searchCompletedItems = CompletedSearch
                        .Where(item => regex.IsMatch(item.Value))
                        .ToList();
                Items.Clear();
                CompletedItems.Clear();
                foreach (var aitem in searchItems)
                {
                    Items.Add(aitem);
                }
                
                foreach (var bitem in searchCompletedItems)
                {
                    CompletedItems.Add(bitem);
                }
            }
            else
            {
                LoadTodoItems();
            }

            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(CompletedItems));
        }



        public INavigation NavigationManager { get; set; }
        private bool OnShowDetail_CanExecute(DataItem item)
        {
           
            return item != null;
        }

        private void OnShowDetail_Execute(DataItem item)
        {
            if (item != null)
            {
                // 导航到详情页面
                NavigationManager.PushAsync(new DetailPage { BindingContext = item });
            }
          
        }


        private void LoadTodoItems()
        {
            try
            {
                string jsonPath1 = Path.Combine(System.AppContext.BaseDirectory, "CompletedItems.json");
                string jsonPath2 = Path.Combine(System.AppContext.BaseDirectory, "Items.json");

                string jsonText1 = File.ReadAllText(jsonPath1);
                string jsonText2 = File.ReadAllText(jsonPath2);

                List<DataItem> loadedItems1 = JsonSerializer.Deserialize<List<DataItem>>(jsonText1, new JsonSerializerOptions
                {
                    Converters = { new DateTimeConverter() } // 注册自定义的 DateTime 转换器
                });
                List<DataItem> loadedItems2 = JsonSerializer.Deserialize<List<DataItem>>(jsonText2, new JsonSerializerOptions
                {
                    Converters = { new DateTimeConverter() } // 注册自定义的 DateTime 转换器
                });
                CompletedItems = new ObservableCollection<DataItem>(loadedItems1);
                Items = new ObservableCollection<DataItem>(loadedItems2);

                CompletedSearch = new ObservableCollection<DataItem>(loadedItems1);
                ItemsSearch =new ObservableCollection<DataItem>(loadedItems2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading todo items: {ex.Message}");
            }
        }

        private void SaveTodoItems()
        {
            try
            {
                string jsonText1 = JsonSerializer.Serialize(CompletedItems.ToList(), new JsonSerializerOptions
                {
                    Converters = { new DateTimeConverter() } // 注册自定义的 DateTime 转换器
                });
                string jsonText2 = JsonSerializer.Serialize(Items.ToList(), new JsonSerializerOptions
                {
                    Converters = { new DateTimeConverter() } // 注册自定义的 DateTime 转换器
                });
                string jsonPath1 = Path.Combine(System.AppContext.BaseDirectory, "CompletedItems.json");
                string jsonPath2 = Path.Combine(System.AppContext.BaseDirectory, "Items.json");
                File.WriteAllText(jsonPath1, jsonText1);
                File.WriteAllText(jsonPath2, jsonText2);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving todo items: {ex.Message}");
            }
        }



        public class DateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options) =>
                    DateTime.Parse(reader.GetString()!);

            public override void Write(
                Utf8JsonWriter writer,
                DateTime dateTimeValue,
                JsonSerializerOptions options) =>
                    writer.WriteStringValue(dateTimeValue.ToString("yyyy/MM/dd HH:mm:ss"));
        }








        private bool OnDeleteCompleted_CanExecute(DataItem item)
        {
            return item != null && CompletedItems.Contains(item);
        }

        private void OnDeleteCompleted_Execute(DataItem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
            else if (CompletedItems.Contains(item))
            {
                CompletedItems.Remove(item);
            }
            SaveTodoItems();
        }

        private bool OnBack_CanExecute(DataItem item)
        {
            return item != null && CompletedItems.Contains(item);
        }

        private void OnBack_Execute(DataItem item)
        {
            if (item != null)
            {
                // 移回待办列表
                CompletedItems.Remove(item);
                var index = Items.OrderByDescending(i => i.CreationTime).ToList().FindIndex(i => i.CreationTime < item.CreationTime);
                if (index == -1)
                {
                    Items.Add(item); // 如果找不到合适的位置，插入到末尾
                    
                }
                else
                {
                    Items.Insert(index, item);
                    
                }
                SaveTodoItems();

            }
        }

        private bool OnBottom_CanExecute(DataItem item)
        {
            return item != null && Items.Contains(item);
        }

        private void OnBottom_Execute(DataItem item)
        {
            if (item != null)
            {
                // 移动任务到已完成
                Items.Remove(item);
                CompletedItems.Add(item);
                SaveTodoItems();

            }
            
        }

        private bool OnNew_CanExecute(object? _)
        {
            return true;
        }

        
        private void OnNew_Execute(object? _)
        {
            DataItem item = new DataItem();
            item.Value = X;
            Items.Insert(0, item);
            SaveTodoItems();
        }

        private bool OnDelete_CanExecute(DataItem item)
        {
            return item != null && Items.Contains(item);
        }

        private void OnDelete_Execute(DataItem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
            else if (CompletedItems.Contains(item))
            {
                CompletedItems.Remove(item);
            }
            SaveTodoItems();
        }

        private bool OnTop_CanExecute(DataItem item)
        {
            return item != null && Items.Contains(item);
        }



        private Dictionary<string, bool> _topStatus = new Dictionary<string, bool>();
        private void OnTop_Execute(DataItem item)
        {
            if (item != null)
            {
                string itemId = item.Id;

                if (!_topStatus.ContainsKey(itemId) || !_topStatus[itemId])
                {
                    // 置顶
                    Items.Move(Items.IndexOf(item), 0);
                    item.CurrentImagePath = "top.png";
                }
                else
                {
                    // 取消置顶
                    Items.Remove(item);

                    // 插入到合适的位置
                    var index = Items.OrderByDescending(i => i.CreationTime).ToList().FindIndex(i => i.CreationTime < item.CreationTime);
                    if (index == -1)
                    {
                        Items.Add(item); 
                    }
                    else
                    {
                        Items.Insert(index, item);
                    }

                    // 更新图标
                    item.CurrentImagePath = "notop.png";

                }

                // 切换置顶状态
                if (_topStatus.ContainsKey(itemId))
                {
                    _topStatus[itemId] = !_topStatus[itemId];
                }
                else
                {
                    _topStatus[itemId] = true;
                }
                SaveTodoItems();
            }
        }

        public ICommand TopCommand { get; }

        public ICommand BottomCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand NewCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand DeleteCompletedCommand { get; }

        public ICommand ShowDetailCommand { get; }

        public ICommand SearchCommand { get; }
        public ICommand ResetCommand { get; }

        public string X { get => _X; set { if (_X == value) return; _X = value; OnPropertyChanged(nameof(X)); } }
        private string _X;

        public string SearchText { get => _SearchText; set { if (_SearchText == value) return; _SearchText = value; OnPropertyChanged(nameof(SearchText)); } }
        private string _SearchText;

        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        //private void OnPropertyChanged(string aPropertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        //    SaveTodoItems();
        //}
        
        public event PropertyChangedEventHandler? PropertyChanged;




    }
}
