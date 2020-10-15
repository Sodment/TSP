using UnityEngine;

public class GameStateSwitcher : MonoBehaviour
{
    public GameStateMachine.GameState stateToSwitch;
    
    public void SwitchState()
    {
        GameManager.instance.SwitchGameState(stateToSwitch);
    }
}
