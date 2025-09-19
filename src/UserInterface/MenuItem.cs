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
        SetPadding();
    }
    public void BuildFromDictionary(Dictionary<string, MenuItem> menuDictionary)
    {
        _valueItems = GetItemsOfType(menuDictionary, MenuEnum.Value);
        _navigationItem = GetItemsOfType(menuDictionary, MenuEnum.Navigation);
        ItemDictionary = menuDictionary;
        SetPadding();
    }

    public static List<MenuItem> GetItemsOfType(Dictionary<string, MenuItem> menuDictionary, MenuEnum tEnum)
    {
        return menuDictionary.Values.Where(p => p.ItemType == tEnum).ToList();
    }

    public List<MenuItem> AllMenuItems()
    {
        return _valueItems.Concat(_navigationItem).ToList();
    }

    public void SetPadding()
    {

        var keyLength = AllMenuItems().Select(p => p.ItemKey.Length).ToList().Max();
        foreach (var item in AllMenuItems())
        {
            var diff = keyLength - item.ItemKey.Length;
            item.SetPadding((diff + 10, diff + 10));
        }

    }

}
public class MenuItem
{
    public MenuEnum ItemType;
    public string ItemKey { get; set; }
    public string? AssignedName { get; set; }
    public float? AssignedFloat { get; set; }
    public (int keyNamePadding, int nameFactorPadding) Padding { get; set; }

    public string NamedItemString;
    public string FactorString;

    public MenuItem(MenuEnum itemType, string itemKey, string? assignedName = null, float? assignedFloat = null)
    {
        ItemType = itemType;
        ItemKey = itemKey;
        AssignedName = assignedName;
        AssignedFloat = assignedFloat;
    }

    public void SetPadding((int keyNamePadding, int nameFactorPadding) padding)
    {;
        NamedItemString = (AssignedName != null ? ": " + AssignedName : "").PadLeft(padding.keyNamePadding);
        FactorString = (AssignedFloat != null ? "Factor: " + AssignedFloat : "").PadLeft(padding.nameFactorPadding);
    }

    public override string ToString()
    {
        return $"{ItemKey}{NamedItemString}{FactorString}";
    }
}

public enum MenuEnum
{
    Value,
    Navigation,
    Input
}