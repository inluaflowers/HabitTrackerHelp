namespace UserInterface.States;

public class InputState<TParentState, T1Input>(string title, string itemKey, Func<TParentState> stateFactory) : BaseState
    where TParentState : BaseState
{
    private readonly string _title = $"Choose a {title} for {itemKey}";
    public override void Display()
    {
        var choice = InterfaceType.AskPrompt<T1Input>(_title);
        switch (choice)
        {
            case string s:
                Context.Cache.MenuItemCache[itemKey].AssignedName = s;
                break;
            case float f:
                Context.Cache.MenuItemCache[itemKey].AssignedFloat = f;
                break;
            default:
                throw new Exception("Choice is Null");
        }
        Context.TransitionTo(stateFactory());
    }

    public override void BuildMenuStates()
    {
    }
}
public class InputState<TParentState, T1Input, T2Input>(string title1, string title2, string itemKey, Func<InputState<TParentState, T2Input>> stateFactory) : BaseState
    where TParentState : BaseState
{
    private readonly string _title = $"Choose a {title1} for {itemKey} ";
    public override void Display()
    {
        var choice = InterfaceType.AskPrompt<T1Input>(_title);
        switch (choice)
        {
            case string s:
                Context.Cache.MenuItemCache[itemKey].AssignedName = s;
                break;
            case float f:
                Context.Cache.MenuItemCache[itemKey].AssignedFloat = f;
                break;
            default:
                throw new Exception("Choice is Null");
        }
        Context.TransitionTo(stateFactory());
    }

    public override void BuildMenuStates()
    {
    }
}

public class AdditionalUnitOfMeasurement<TParentState> : BaseState
where TParentState : BaseState, new()
{
    public override void Display()
    {
        Context.Cache.MeasurementCount++;
        var itemKey = $"Unit of Measurement {Context.Cache.MeasurementCount}";
        Context.Cache.MenuItemCache.Add(itemKey, new MenuItem(MenuEnum.Value, itemKey, "None"));
        Context.Cache.ActionCache.Add(itemKey, () =>
            Context.TransitionTo(
                new InputState<TParentState, string, float>("Name", "Factor of Base Measurement", itemKey, ()  =>
                    new InputState<TParentState, float>("Factor of Base Measurement", itemKey, () => 
                        new TParentState()))));

        Context.TransitionTo(new TParentState());
    }

    public override void BuildMenuStates()
    {

    }

    public void MultiTransition()
    {
        Context.TransitionTo(new TParentState());
    }
}
