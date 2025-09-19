using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface;

public class Cache
{
    public Dictionary<string, MenuItem> MenuItemCache = [];
    public Dictionary<string, Action> ActionCache = [];
    public int MeasurementCount = 1;

    public bool IsEmpty()
    {
        return (MenuItemCache.Count == 0 && ActionCache.Count == 0);
    }
}




