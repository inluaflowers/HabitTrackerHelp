using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UserInterface.States;

public class MainMenuState : BaseState
{
    private const string StateTitle = "Main Menu";
    public override void BuildMenuStates()
    {
        AddMenuStateAction<AddHabitTrackerState>(MenuEnum.Navigation, () => new AddHabitTrackerState(), "Create New Habit");
        AddMenuStateAction<ExitState>(MenuEnum.Navigation, () => new ExitState(), "Exit");
        StateMenu.BuildFromDictionary();
    }
    public override void Display()
    {
        var choice = InterfaceType.SelectionPrompt(StateTitle, StateMenu.AllMenuItems());
        if (choice.ItemKey == "Create New Habit")
        {
            Context.Cache = new Cache();
        }  
        StateActions[choice.ItemKey]();
    }
}

