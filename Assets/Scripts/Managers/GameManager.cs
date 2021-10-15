using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public bool IsPlaying { private set; get;}

    public enum GameStates
    {
        IsGameLoaded,
        IsGamePlaying,
        IsGameOver,
        IsGamePaused
    }

    public GameStates GameState;

    public bool IsGameMuted;

    private void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        GameState = GameStates.IsGameLoaded;

        LevelManager.Instance.GenerateLevel();
        PlayerManager.Instance.GenerateNewPlayer();
    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        GameState = GameStates.IsGameLoaded;

        LevelManager.Instance.GenerateLevel();
        PlayerManager.Instance.GenerateNewPlayer();

        CanvasController.Instance.InGamePanel.ActivateTapToStartButton();
    }

    public void GameOver()
    {
        GameState = GameStates.IsGameOver;

        CanvasController.Instance.InGamePanel.HidePanel();
        CanvasController.Instance.LevelPassedPanel.ShowPanel();
        

        AudioController.Instance.StopSound("BackgroundSound");
        AudioController.Instance.PlaySound("CheerSound");

    }

    public bool GetIsGameMuted()
    {
        return IsGameMuted;
    }
    public void SetIsGameMuted(bool Value)
    {
        IsGameMuted = Value;
    }


}
