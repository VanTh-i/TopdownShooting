using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    public enum GameState
    {
        GamePlay,
        Paused,
        GameOver,
        LevelUp
    };

    public bool isGameOver = false;
    public bool upgrade;

    public GameState currentState;
    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject resultsScreen;
    public GameObject statsScreen;
    public GameObject levelUpScreen;


    [Header("Stats UI")]
    public TextMeshProUGUI maxHPDisplay;
    public TextMeshProUGUI recoveryDisplay;
    public TextMeshProUGUI moveSpeedDisplay;
    public TextMeshProUGUI attackDamageDisplay;
    public TextMeshProUGUI specialDamageDisplay;

    [Header("Result UI")]
    public TextMeshProUGUI timeSurvivalDisplay;
    public Image chosenCharacters;
    public TextMeshProUGUI charactersName;

    [Header("Stopwatch")]
    public float timeLimit;
    private float stopwatchTime;
    public TextMeshProUGUI stopwatchDisplay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        BeginGame();
    }

    private void BeginGame()
    {
        pauseScreen.SetActive(false);
        resultsScreen.SetActive(false);
        statsScreen.SetActive(false);
        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.GamePlay:
                CheckPauseAndResume();
                UpdateStopwatch();
                break;

            case GameState.Paused:
                CheckPauseAndResume();
                break;

            case GameState.GameOver:
                if (!isGameOver)
                {
                    isGameOver = true;
                    Time.timeScale = 0f;
                    Debug.Log("GAME OVER");
                    DisplayResults();
                }
                break;

            case GameState.LevelUp:
                if (!upgrade)
                {
                    upgrade = true;
                    Time.timeScale = 0f;
                    levelUpScreen.SetActive(true);
                }
                break;

            default:
                Debug.LogWarning("STATE DOES NOT EXIST");
                break;
        }

        StatsResult();
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PausedGame()
    {
        if (currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
    }
    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
    }
    private void CheckPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PausedGame();
            }
        }
    }

    private void StatsResult()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (currentState == GameState.Paused || currentState == GameState.GameOver)
            {
                return;
            }
            else
            {
                statsScreen.SetActive(true);
            }
        }
        else
        {
            statsScreen.SetActive(false);
        }
    }

    public void GameOver()
    {
        timeSurvivalDisplay.text = stopwatchDisplay.text;
        ChangeState(GameState.GameOver);
    }
    private void DisplayResults()
    {
        resultsScreen.SetActive(true);
    }
    public void ResultChosenCharacters(CharacterScriptableObjects characterData)
    {
        chosenCharacters.sprite = characterData.CharacterIcon;
        charactersName.text = characterData.Name;
    }

    private void UpdateStopwatch()
    {
        stopwatchTime += Time.deltaTime;
        UpdateStopwatchTimeDisplay();

        // if (stopwatchTime >= timeLimit)
        // {
        //     GameOver();
        // }
    }
    private void UpdateStopwatchTimeDisplay()
    {
        int min = Mathf.FloorToInt(stopwatchTime / 60);
        int sec = Mathf.FloorToInt(stopwatchTime % 60);
        stopwatchDisplay.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void StartLevelUp()
    {
        ChangeState(GameState.LevelUp);
    }
    public void EndLevelUp()
    {
        upgrade = false;
        Time.timeScale = 1f;
        levelUpScreen.SetActive(false);
        ChangeState(GameState.GamePlay);
    }
}
