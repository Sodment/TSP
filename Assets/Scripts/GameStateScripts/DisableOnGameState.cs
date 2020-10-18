using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnGameState : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public GameObject gameObjectToDisable;

    void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.SwitchingToUIMainView.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.GraphSetting:
                GameManager.instance.SwitchingToGraphSetting.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Simulating:
                GameManager.instance.SwitchingToSimulating.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Results:
                GameManager.instance.SwitchingToResults.AddListener(DisableGameObject);
                break;
        }
    }

    void DisableGameObject()
    {
        gameObjectToDisable.SetActive(false);
    }
}
