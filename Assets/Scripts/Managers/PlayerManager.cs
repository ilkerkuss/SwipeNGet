using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private PlayerContoller _prefabPlayer;
    [SerializeField] private PlayerContoller _currentPlayer;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GenerateNewPlayer()
    {
        if (_currentPlayer != null) //If there is a player in scene that remains from older levels,Destroy older player then instantiate new player 
        {
            Destroy(_currentPlayer.gameObject);
        }

        _currentPlayer = Instantiate(_prefabPlayer, _prefabPlayer.transform.position, Quaternion.identity);
    }

}
