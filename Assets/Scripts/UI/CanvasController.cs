using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;

    public LevelPassedPanelController LevelPassedPanel;
    public InGamePanelController InGamePanel;

    private void Awake()
    {
        Instance = this;

    }
}
