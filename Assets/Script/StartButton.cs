using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnStartButtonClicked);
    }

    public void OnStartButtonClicked()
    {
        GameManager.Instance.ChangeGameState(GameManager.GameState.InGame);
    }
}
