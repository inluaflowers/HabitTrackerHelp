using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface;
internal class HelperMethods
{
    public static List<string> Zipper(List<string> firstEnumerable, List<object> secondEnumerable, bool fill = false)
    {
        List<string> firstHolder = [.. firstEnumerable];
        var secondHolder = secondEnumerable.ConvertAll(i => i.ToString()!);

        while (fill && secondHolder.Count < firstHolder.Count)
        {
            secondHolder.Add("");
        }

        return firstEnumerable.Zip(secondHolder, (first, second) => first + " " + second).ToList();
    }

    public static string ZipperAsString(List<string> firstEnumerable, List<object> secondEnumerable, bool fill = false)
    {
        var zipper = Zipper(firstEnumerable, secondEnumerable, fill);
        return string.Join("\n", zipper);
    }

    public static List<string> ConcatFirstListWithColon(List<string> firstEnumerable, List<string> secondEnumerable)
    {
        return firstEnumerable.Select(n => n + ": ").ToList().Concat(secondEnumerable).ToList();
    }
}
