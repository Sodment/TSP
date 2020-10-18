using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnGameState : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public GameObject gameObjectToEnable;

    void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.SwitchingToUIMainView.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.GraphSetting:
                GameManager.instance.SwitchingToGraphSetting.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.Simulating:
                GameManager.instance.SwitchingToSimulating.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.Results:
                GameManager.instance.SwitchingToResults.AddListener(EnableGameObject);
                break;
        }
    }

    void EnableGameObject()
    {
        gameObjectToEnable.SetActive(true);
    }
}
