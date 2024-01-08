using System.Text.RegularExpressions;

static void ShowMatch(Match aMatch)
{
    // 整体提取
    if (aMatch.Success)
        Console.WriteLine($"匹配结果：{aMatch.Value}");

    // 局部提取
    foreach (Group aGroup in aMatch.Groups.Cast<Group>())
    {
        Console.WriteLine($"    Group: {aGroup.Value}");
    }
}

Console.Write("请输入测试文本：");
string aText = Console.ReadLine() ?? "";

Console.Write("请输入正则表达式：");
string aPattern = Console.ReadLine() ?? "";
Regex aRegex = new(aPattern);

// 检测
if (!aRegex.IsMatch(aText))
    Console.WriteLine("检测不通过！");
else
{
    Console.WriteLine("检测通过！");

    Console.WriteLine("显示首个匹配……");
    ShowMatch(aRegex.Match(aText));

    Console.WriteLine("显示全部匹配……");
    MatchCollection aMatches = aRegex.Matches(aText);
    foreach (Match aMatch in aMatches.Cast<Match>())
    {
        ShowMatch(aMatch);
    }
}
