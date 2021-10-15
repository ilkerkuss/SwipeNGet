using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private LevelController[] _levelList;
    [SerializeField] private LevelController _instantiatedLevel;


    private int _currentLevel;



    private void Awake()
    {
        Instance = this;
        
    }

    void Start()
    {
        _currentLevel = PlayerPrefs.GetInt("Level",0);
    }


    void Update()
    {

    }

    public void GenerateLevel()
    {
        if (_instantiatedLevel != null) //If there is a level in scene that remains from older levels,Destroy older level then instantiate new level 
        {
            Destroy(_instantiatedLevel.gameObject);
        }

        _instantiatedLevel = Instantiate(_levelList[_currentLevel % (_levelList.Length)], Vector3.zero, Quaternion.identity);

    }



    public void LevelPassed()
    {
        GameManager.Instance.GameOver();

        _currentLevel++;
        PlayerPrefs.SetInt("Level",_currentLevel);
       
    }

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("Level", 0);
    }


    }
