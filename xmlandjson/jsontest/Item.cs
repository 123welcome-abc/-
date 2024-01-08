using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsontest
{
    class RootObject
    {
        public List<Item> Items { get; set; }
        public List<Item> CompletedItems { get; set; }
    }
    class Item
    {
        public string Id { get; set; }
        public string Value { get; set; } 
        public string CurrentImagePath { get; set; }
        public DateTime CreationTime { get; set; }= DateTime.Now;

        public string Note { get; set; }
        public string CompletionTime { get; set; }
    }
}
