using UnityEngine;
using UnityEngine.UI;

public class ChangeToResults : MonoBehaviour
{
    public Sprite resultSprite;
    public Sprite startSprite;
    public Button button;

    void Start()
    {
        GameManager.instance.SwitchingToSimulating.AddListener(SwapImageToResults);
        GameManager.instance.QuittingResults.AddListener(SwapImageToStart);
    }

    void SwapImageToResults()
    {
        button.image.sprite = resultSprite;
    }

    void SwapImageToStart()
    {
        button.image.sprite = startSprite;
    }
}
