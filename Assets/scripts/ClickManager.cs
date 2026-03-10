using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    [SerializeField] TMP_Text counterText;
    [SerializeField] Image fillBar;

    int clicks;
    int maxClicks = 10;

    private void Start()
    {
        fillBar.fillAmount = 0;
    }

    public void OnClick()
    {
        clicks = clicks >= maxClicks ? 0 : clicks ++;
        counterText.text = $"Clicks: {clicks}";
        fillBar.fillAmount = clicks / (float)maxClicks;
    }
}