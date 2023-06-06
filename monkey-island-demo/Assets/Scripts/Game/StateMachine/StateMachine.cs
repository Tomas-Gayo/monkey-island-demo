using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State State;

    // Set the states in the State class
    public void SetState(State state)
    {
        State = state;
        StartCoroutine(State.Start());
    }
}
