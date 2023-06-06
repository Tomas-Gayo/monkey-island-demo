using System.Collections;

// Abstract class that will hold our futere states
public abstract class State
{
    protected GameplayManager GameplayManager;

    // Constructor for the states
    public State(GameplayManager gameplayManager)
    {
        GameplayManager = gameplayManager;
    }

    // The following methods will shared between the states
    // Each state can override the virtual methods here
    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator EndTurn(int enemyIndex, int playerIndex)
    {
        yield break;
    }
}
