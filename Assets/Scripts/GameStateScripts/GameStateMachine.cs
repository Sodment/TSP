using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public enum GameState
    {
        UIMainView,
        GraphSetting,
        Simulating,
        Results,
    }

    [SerializeField]
    public GameState currentState;

    // Update is called once per frame
    public void SwitchToState(GameState state)
    {
        currentState = state;
    }
}
