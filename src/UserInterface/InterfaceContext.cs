using UserInterface.States;
namespace UserInterface;
public class InterfaceContext
{
    public BaseState State = null;
    public Cache Cache = null;

    public InterfaceContext(BaseState state)
    {
        TransitionTo(state);
    }
    public void TransitionTo(BaseState state)
    {
        State = state;
        State.SetContext(this);
        State.BuildMenuStates();
        Display();
    }
    public void Display()
    {
        State.Display();
    }
}


