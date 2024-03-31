using UnityEngine;
using UnityEngine.UI;

public class GameSlider : MonoBehaviour
{
    public Slider timeSlider;
    public float totalTime = 30f; // ゲージが0になるまでの総時間

    private float timeRemaining;

    void Start()
    {
        timeRemaining = totalTime;
        if (timeSlider != null)
        {
            timeSlider.maxValue = totalTime;
            timeSlider.value = totalTime;
        }
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timeSlider.value = timeRemaining;
        }
        else
        {
            // ここに時間切れ時の処理を記述
            Debug.Log("Time's up!");
        }
    }

}
