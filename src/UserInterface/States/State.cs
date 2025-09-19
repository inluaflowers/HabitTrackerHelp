using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace UserInterface.States;

public abstract class BaseState
{
    protected Menu StateMenu = new();
    protected Dictionary<string, Action> StateActions = [];
    protected InterfaceContext Context;
    public void SetContext(InterfaceContext context)
    {
        Context = context;
    }
    public void AddMenuStateAction<TState>(MenuEnum itemType, Func<string, TState> stateFactory, string itemKey, string? assignedName = null,
        float? assignedFloat = null)
        where TState : BaseState
    {
        StateMenu.AddItem(itemType, itemKey, assignedName, assignedFloat);
        StateActions[itemKey] = () => Context.TransitionTo(stateFactory(itemKey));
    }
    public void AddMenuStateAction<TState>(MenuEnum itemType, Func<TState> stateFactory, string itemKey, string? assignedName = null,
        float? assignedFloat = null)
        where TState : BaseState
    {
        StateMenu.AddItem(itemType, itemKey, assignedName, assignedFloat);
        StateActions[itemKey] = () => Context.TransitionTo(stateFactory());
    }

    public abstract void BuildMenuStates();
    public abstract void Display();
}
