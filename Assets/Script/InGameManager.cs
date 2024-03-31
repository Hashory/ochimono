using System;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance { get; private set; }

    public enum InGameState
    {
        startIn,
        gaming,
        breakTime
    }

    private InGameState inGameState;

    [SerializeField] private float startinTime = 5f;
    [SerializeField] private float gameTime = 30f;
    [SerializeField] private float breakTime = 20f;
    [SerializeField] private int hp = 3;
    [SerializeField] private float defaultSpawnRate = 0.1f;

    /// <summary>
    /// RainSpowner
    /// </summary>
    [SerializeField] private GameObject Spowner;

    /// <summary>
    /// ゲームのフェーズのフェーズ
    /// </summary>
    private int phase = 1;

    private float timer;


    [SerializeField] private InGameUIManager inGameUIManager;
    [SerializeField] private RainSpawner rainSpawner;
    [SerializeField] private FirstPersonCamera firstPersonCamera;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator damageOverrayAnimator;

    private bool isIngameEnabled = false;

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

    public void InGameEnabled(bool enabled)
    {
        isIngameEnabled = enabled;

        inGameUIManager.UIEnabled(enabled);
        firstPersonCamera.FirstPersonCameraEnabled(enabled);
        playerMovement.PlayerMovementEnabled(enabled);

        // ゲームが開始されたら、最初の状態を設定します
        if(enabled)
        {
            inGameState = InGameState.startIn;
            timer = startinTime;
            phase = 1;
            hp = 3;
            rainSpawner.SpawnSpeed = defaultSpawnRate;
            rainSpawner.IsSpawning = false;
            inGameUIManager.UpdateTimeDisplay(timer, gameTime, $"Starting in  -  {timer:0.0}s");
            inGameUIManager.UpdateHpDisplay(hp);
        }
    }

    private void Update()
    {
        switch (inGameState)
        {
            case InGameState.startIn:
                timer -= Time.deltaTime;
                inGameUIManager.UpdateTimeDisplay(timer, startinTime, $"Starting in  -  {timer:0.0}s");
                if (timer <= 0)
                {
                    inGameState = InGameState.gaming;
                    timer = gameTime;
                    inGameUIManager.UpdateTimeDisplay(timer, gameTime, $"Phase {phase}  -  {timer:0.0}s");
                    rainSpawner.IsSpawning = true;
                }
                break;
            case InGameState.gaming:
                timer -= Time.deltaTime;
                
                inGameUIManager.UpdateTimeDisplay(timer, gameTime, $"Phase {phase}  -  {timer:0.0}s");
                if (timer <= 0)
                {
                    inGameState = InGameState.breakTime;
                    timer = breakTime;
                    inGameUIManager.UpdateTimeDisplay(timer, breakTime, $"Phase {phase}  -  {timer:0.0}s");
                    rainSpawner.IsSpawning = false;
                }
                break;
            case InGameState.breakTime:
                timer -= Time.deltaTime;
                inGameUIManager.UpdateTimeDisplay(timer, breakTime, $"Brak Time  {timer:0.0}s");
                if (timer <= 0)
                {
                    inGameState = InGameState.gaming;
                    timer = gameTime;
                    inGameUIManager.UpdateTimeDisplay(timer, gameTime, $"Brak Time  {timer:0.0}s");
                    rainSpawner.SpawnSpeed = Mathf.Max(defaultSpawnRate * Mathf.Pow(0.9f, (float)phase), 0.01f);
                    rainSpawner.IsSpawning = true;
                    phase++;
                }
                break;
        }
    }

    public void ReducePlayerHP()
    {
        hp--;
        inGameUIManager.UpdateHpDisplay(hp);
        damageOverrayAnimator.SetTrigger("damaged");
        if (hp <= 0 && isIngameEnabled)
        {
            Debug.Log("GameOver");
            GameManager.Instance.ChangeGameState(GameManager.GameState.GameOver);
        }
    }
}
