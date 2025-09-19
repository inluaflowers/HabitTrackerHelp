using UserInterface.Menus;

namespace UserInterface;
public class Selection<T>(string name, T value, Menu nextMenu)
{
    public string Name = name;
    public T Value = value;
    public Menu NextMenu = nextMenu;
}

