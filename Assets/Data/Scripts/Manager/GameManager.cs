using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    public enum GameState
    {
        GamePlay,
        Paused,
        GameOver
    };

    public GameState currentState;
    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;


    private void Awake()
    {
        instance = this;
        BeginGame();
    }

    private void BeginGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.GamePlay:
                CheckPauseAndResume();
                break;

            case GameState.Paused:
                CheckPauseAndResume();
                break;

            case GameState.GameOver:

                break;

            default:
                Debug.LogWarning("STATE DOES NOT EXIST");
                break;
        }
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
}
