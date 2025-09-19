using System.Reflection.Metadata;
using System.Xml.Linq;
using UserInterface;
namespace UserInterface.States;

public sealed class AddHabitTrackerState : BaseState
{
    private const string StateTitle = "Build A Habit Tracker";
    public override void BuildMenuStates()
    {
        if (Context.Cache.IsEmpty())
        {
            AddMenuStateAction(MenuEnum.Value, key => 
                new InputState<AddHabitTrackerState, string>("Name", key, () => new AddHabitTrackerState()), "Habit Name", "None");
            AddMenuStateAction(MenuEnum.Value, key => 
                new InputState<AddHabitTrackerState, string>("Name", key, () => new AddHabitTrackerState()), "Base Unit of Measurement", "None");

            AddMenuStateAction(MenuEnum.Navigation, () => new AdditionalUnitOfMeasurement<AddHabitTrackerState>(), "Additional Unit of Measurement");
            AddMenuStateAction(MenuEnum.Navigation, () => new MainMenuState(), "Cancel");
            StateMenu.BuildFromDictionary();
            Context.Cache.MenuItemCache = StateMenu.ItemDictionary;
            Context.Cache.ActionCache = StateActions;
        }
        else
        {
            StateMenu.BuildFromDictionary(Context.Cache.MenuItemCache);
            StateActions = Context.Cache.ActionCache;
        }
    }

    public override void Display()
    {
        var choice = InterfaceType.SelectionPrompt(StateTitle, StateMenu.AllMenuItems());
        StateActions[choice.ItemKey]();
    }
}
