using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas inGameCanvas;

    [SerializeField]
    private Slider timeSlider;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Image[] hpImages;

    [SerializeField]
    private Sprite hpFullSprite;

    [SerializeField]
    private Sprite hpEmptySprite;

    public void UIEnabled(bool enabled)
    {
        inGameCanvas.enabled = enabled;
    }

    public void UpdateTimeDisplay(float currentTime, float maxTime, string label)
    {
        if (timeSlider != null)
        {
            timeSlider.maxValue = maxTime;
            timeSlider.value = currentTime;
        }

        if (timeText != null)
        {
            timeText.text = label;
        }
    }

    public void UpdateHpDisplay(int hp)
    {
        for (int i = 0; i < hpImages.Length; i++)
        {
            if (i < hp)
            {
                hpImages[i].sprite = hpFullSprite;
            }
            else
            {
                hpImages[i].sprite = hpEmptySprite;
            }
        }
    }
}
