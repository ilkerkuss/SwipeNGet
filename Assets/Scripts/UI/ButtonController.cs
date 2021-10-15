using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public static ButtonController Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void OnClickNextLevel()
    {
        LevelPassedPanelController.Instance.AssignNextLevel();
    }

    public void OnClickRestartGame()
    {
        InGamePanelController.Instance.AssignRestartButton();

    }

    public void OnClickPause()
    {
        InGamePanelController.Instance.AssignRestartButton();
    }

    public void OnClickMute()
    {
        InGamePanelController.Instance.AssignMuteButton();
    }

    public void OnClickTapToStart()
    {
        InGamePanelController.Instance.AssignTaptoStartButton();
    }
}
