namespace UserInterface;

public class UserInterface
{
    private readonly IDisplayStrategy _strategy;
    public UserInterface(string title)
    {
        _strategy = new AskStrategy(title);
    }

    public UserInterface(string title, Selection<T>[] menuChoices)
    {
        _strategy = new SelectionStrategy(title, menuChoices);
    }

    public Selection Show()
    {
        return _strategy.Show();
    }
}