using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsontest
{
    class jsonItem
    {
        public string Id { get; set; } = "baidu";
        public string Value { get; set; } = "Baidu Site";
        public string CurrentImagePath { get; set; } = "www.baidu.com";
        public string CreationTime { get; set; } = "Nothing.";


        public ObservableCollection<jsonItem> Items { get; } = new ObservableCollection<jsonItem>();

        public ObservableCollection<jsonItem> CompletedItems { get; } = new ObservableCollection<jsonItem>();
    }
}
