using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [SerializeField] private GameObject gameOverPanel;

    public void GameOverEnabled(bool enabled)
    {
        gameOverPanel.SetActive(enabled);
    }
}
