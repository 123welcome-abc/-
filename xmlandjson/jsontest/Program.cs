using jsontest;
using System.ComponentModel;
using System.Text.Json;

//string aJsonText =
////@"{
////""Name"": ""Google"",
////""Description"": ""Google Site"",
////""Url"": ""www.google.com""
////}";

//Item aItem = JsonSerializer.Deserialize<Item>("data.json");

//Console.WriteLine($"Name = {aItem.Name}");
//Console.WriteLine($"Description = {aItem.Description}");
//Console.WriteLine($"Url = {aItem.Url}");
//Console.WriteLine($"Memo = {aItem.Memo}");

//string aJsonText = JsonSerializer.Serialize(aItem);

//Console.WriteLine(aJsonText);
//string jsonData = File.ReadAllText("data.json");
//jsonItem aItem2 = JsonSerializer.Deserialize<jsonItem>(jsonData);

//Console.WriteLine(aItem2.Items);
//jsonData = JsonSerializer.Serialize(aItem2);

//foreach (var item in aItem2.Items)
//{
//    Console.WriteLine(item);
//}


string jsonData = File.ReadAllText("data.json");
Console.WriteLine($"Loaded JSON data: {jsonData}");

var data = JsonSerializer.Deserialize<RootObject>(jsonData, new JsonSerializerOptions
{
    Converters = { new DateTimeJsonConverter() } // 添加 DateTime 转换器
});
//Console.WriteLine(data.Value);
//string aJsonText = JsonSerializer.Serialize(data);
//Console.WriteLine(aJsonText);
