namespace UserInterface.Menus;

internal class ViewHabitMenu : Menu
{
    private const string Title = "Select a Habit to View";
    // Use SQL to pull habit names
    private static readonly Selection[] MenuSelections = [new Selection(), new Selection(), new Selection()];
    internal UserInterface MenuUi = new(Title, MenuSelections);
    public override Selection SetActive()
    {
        return MenuUi.Show();
    }
}

