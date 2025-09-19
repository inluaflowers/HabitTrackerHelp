using System.Reflection.Metadata.Ecma335;
using Spectre.Console;

namespace UserInterface;
public class InterfaceType
{
    public static MenuItem SelectionPrompt(string title, List<MenuItem> allMenuItems)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuItem>()
                .Title(title)
                .AddChoices(allMenuItems)
                .UseConverter(i => i.ToString())
        );
        return choice;
    }

    public static T AskPrompt<T>(string title)
    {
        while (true)
        {
            var input = AnsiConsole.Ask<T>(title);

            if (input is null)
            {
                continue;
            }
            else
            {
                Console.Clear();
                return input;
            }
        }
    }
}
