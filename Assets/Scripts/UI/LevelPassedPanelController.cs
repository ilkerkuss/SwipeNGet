using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassedPanelController : CanvasManager
{
    public static LevelPassedPanelController Instance;

    [SerializeField] private Button _nextLevelButton;

    private void Awake()
    {
        Instance = this;
    }


    public void AssignNextLevel()
    {
        GameManager.Instance.GameState = GameManager.GameStates.IsGameLoaded;

        LevelManager.Instance.GenerateLevel();
        PlayerManager.Instance.GenerateNewPlayer();

        CanvasController.Instance.LevelPassedPanel.HidePanel();
        CanvasController.Instance.InGamePanel.ShowPanel();

        CanvasController.Instance.InGamePanel.SetLevelText();
        CanvasController.Instance.InGamePanel.ActivateTapToStartButton();


        AudioController.Instance.StopSound("CheerSound");
        AudioController.Instance.PlaySound("ButtonSound");
        AudioController.Instance.PlaySound("BackgroundSound");

    }
}
