using Spectre.Console;
namespace UserInterface;
internal interface IDisplayStrategy
{
    public Selection Show();
}

public class SelectionStrategy(string title, Selection[] menuChoices) : IDisplayStrategy
{
    public Selection Show()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<Selection>()
                .Title(title)
                .UseConverter(t => t.ToString() ?? "<null>")
                .AddChoices(menuChoices)
        );
    }
}

public class AskStrategy(string title) : IDisplayStrategy
{
    public Selection Show()
    {
        return AnsiConsole.Ask<Selection>(title);
    }
}