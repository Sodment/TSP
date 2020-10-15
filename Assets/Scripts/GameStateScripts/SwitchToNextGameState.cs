using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToNextGameState : MonoBehaviour
{
    public void Switch()
    {
        GameManager.instance.SwitchToNextState();
    }
}
