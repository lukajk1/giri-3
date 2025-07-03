using UnityEngine;

public class CCState
{
    public enum State
    {
        Hidden,
        Exposed,
        Disarmed,
        Rooted,
        Stunned,
        Wraithed // disables unit collision
    }
    public State _effect;
    public CCState(State effect)
    {
        _effect = effect;
    }
}