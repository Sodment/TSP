using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UnityEvent OnStateChange;

    public UnityEvent SwitchingToUIMainView;
    public UnityEvent SwitchingToGraphSetting;
    public UnityEvent SwitchingToSimulating;
    public UnityEvent SwitchingToResults;

    public UnityEvent QuittingUIMainView;
    public UnityEvent QuittingGraphSetting;
    public UnityEvent QuittingSimulating;
    public UnityEvent QuittingResults;

    GameStateMachine gameStateMachine;

    private void Awake()
    {
        if( instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    public void SwitchGameState(GameStateMachine.GameState state)
    {
        switch(state)
        {
            case GameStateMachine.GameState.UIMainView:
                SwitchingToUIMainView.Invoke();
                break;
            case GameStateMachine.GameState.GraphSetting:
                SwitchingToGraphSetting.Invoke();
                break;
            case GameStateMachine.GameState.Simulating:
                SwitchingToSimulating.Invoke();
                break;
            case GameStateMachine.GameState.Results:
                SwitchingToResults.Invoke();
                break;
        }

        GameStateMachine.GameState lastState = gameStateMachine.currentState;
        gameStateMachine.SwitchToState(state);

        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                QuittingUIMainView.Invoke();
                break;
            case GameStateMachine.GameState.GraphSetting:
                QuittingGraphSetting.Invoke();
                break;
            case GameStateMachine.GameState.Simulating:
                QuittingSimulating.Invoke();
                break;
            case GameStateMachine.GameState.Results:
                QuittingResults.Invoke();
                break;
        }

        OnStateChange.Invoke();
    }

    public void SwitchToNextState()
    {
        switch (gameStateMachine.currentState)
        {
            case GameStateMachine.GameState.UIMainView:
                SwitchGameState(GameStateMachine.GameState.GraphSetting);
                break;
            case GameStateMachine.GameState.GraphSetting:
                SwitchGameState(GameStateMachine.GameState.Simulating);
                break;
            case GameStateMachine.GameState.Simulating:
                SwitchGameState(GameStateMachine.GameState.Results);
                break;
            case GameStateMachine.GameState.Results:
                SwitchGameState(GameStateMachine.GameState.UIMainView);
                break;
        }
    }

    public GameStateMachine.GameState GetCurrentState()
    {
        return gameStateMachine.currentState;
    }
}
