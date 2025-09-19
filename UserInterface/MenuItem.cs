using System.Dynamic;
using System.Net.Http.Headers;

namespace UserInterface;

public class Menu
{
    private  List<MenuItem> _valueItems = [];
    private List<MenuItem> _navigationItem = [];
    public Dictionary<string, MenuItem> ItemDictionary = [];
    public void AddItem(MenuEnum itemType, string itemKey, string? assignedName = null, float? assignedFloat = null)
    {
        var menuItem = new MenuItem(itemType, itemKey, assignedName, assignedFloat);
        ItemDictionary.Add(itemKey, menuItem);
    }
    public void BuildFromDictionary()
    {
        _valueItems = GetItemsOfType(ItemDictionary, MenuEnum.Value);
        _navigationItem = GetItemsOfType(ItemDictionary, MenuEnum.Navigation);
    }
    public void BuildFromDictionary(Dictionary<string, MenuItem> menuDictionary)
    {
        _valueItems = GetItemsOfType(menuDictionary, MenuEnum.Value);
        _navigationItem = GetItemsOfType(menuDictionary, MenuEnum.Navigation);
        ItemDictionary = menuDictionary;
    }

    public static List<MenuItem> GetItemsOfType(Dictionary<string, MenuItem> menuDictionary, MenuEnum tEnum)
    {
        return menuDictionary.Values.Where(p => p.ItemType == tEnum).ToList();
    }

    public List<MenuItem> AllMenuItems()
    {
        return _valueItems.Concat(_navigationItem).ToList();
    }

}
public class MenuItem(MenuEnum itemType, string itemKey, string? assignedName = null, float? assignedFloat = null)
{
    public MenuEnum ItemType = itemType;
    public string ItemKey { get; set; } = itemKey;
    public string? AssignedName { get; set; } = assignedName;
    public float? AssignedFloat { get; set; } = assignedFloat;

    public override string ToString()
    {
        var namedItemString = AssignedName != null ? ":\t\t" + AssignedName  : "";
        var floatValue = AssignedFloat != null ? "\n\tFactor: " + AssignedFloat.ToString() : "";
        return $"{ItemKey}{namedItemString}{floatValue}";
    }
}

public enum MenuEnum
{
    Value,
    Navigation,
    Input
}