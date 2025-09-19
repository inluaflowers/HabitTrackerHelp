namespace UserInterface.Menus;

public class MainMenu : Menu
{
    private const string Title = "LMer\nShhh! Be vewy, vewy quiet. We're tracking habits!\nMain Menu";

    public static Menu ViewHabitMenu = new ViewHabitMenu();

    private static readonly Selection<MenuEnum>[] MenuSelections = 
    [
        new Selection<MenuEnum> ("View Habit", MenuEnum.ViewHabit, ViewHabitMenu)
    ];

    public UserInterface MenuUi = new(Title, MenuSelections);
    public override Selection<T> SetActive<T>()
    {
        return MenuUi.Show();
    }


    public enum MenuEnum
    {
        ViewHabit,
        CreateHabit,
        EditHabit,
        Exit
    }

 
}

