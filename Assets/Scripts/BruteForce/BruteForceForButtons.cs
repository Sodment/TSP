using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteForceForButtons : MonoBehaviour
{
    public Object bruteEnforcer;
    public void CreateBruteEnforcerAtPosition()
    {
        Instantiate(bruteEnforcer, Vector3.zero,Quaternion.identity);
    }
}
