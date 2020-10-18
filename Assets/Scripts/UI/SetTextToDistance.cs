using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextToDistance : MonoBehaviour
{
    public Text distanceText;
    void Start()
    {
        GameManager.instance.SwitchingToResults.AddListener(SetText);
    }

    void SetText()
    {
        distanceText.text = "Travelled Distance: " + ListOfCities.instance.distanceTraveled.ToString();
    }
}
