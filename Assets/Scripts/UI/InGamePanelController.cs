using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanelController : CanvasManager
{
    public static InGamePanelController Instance;

    [SerializeField] private Button _muteButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _tapToStartButton;
    [SerializeField] private Text _levelText;

    private void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        SetLevelText();
    }

    public void SetLevelText()
    {
        _levelText.text = LevelManager.Instance.GetCurrentLevel().ToString();
    }



    public void ActivateTapToStartButton()
    {
        _tapToStartButton.gameObject.SetActive(true);
    }

    public void DisableTapToStartButton()
    {
        _tapToStartButton.gameObject.SetActive(false);
    }


    public void AssignTaptoStartButton()
    {
        GameManager.Instance.GameState = GameManager.GameStates.IsGamePlaying;
        CanvasController.Instance.InGamePanel.DisableTapToStartButton();
    }

    public void AssignRestartButton()
    {
        GameManager.Instance.RestartGame();

        AudioController.Instance.PlaySound("ButtonSound");
    }

    public void AssignMuteButton()
    {
        if (!GameManager.Instance.GetIsGameMuted())
        {
            GameManager.Instance.SetIsGameMuted(true);
            AudioController.Instance.MuteSounds();

        }
        else
        {
            GameManager.Instance.SetIsGameMuted(false);
            AudioController.Instance.UnMuteSounds();
        }
        AudioController.Instance.PlaySound("ButtonSound");
    }

    public void AssignPauseButton()
    {
        if (GameManager.Instance.GameState == GameManager.GameStates.IsGamePaused)
        {
            GameManager.Instance.GameState = GameManager.GameStates.IsGamePlaying;
            AudioController.Instance.UnMuteSounds();
        }
        else
        {
            GameManager.Instance.GameState = GameManager.GameStates.IsGamePaused;
            AudioController.Instance.MuteSounds();
        }
        AudioController.Instance.PlaySound("ButtonSound");
    }
}
