using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int _pickNumber; // pickable object number
    [SerializeField] private GameObject _pickParent; //parent object that holds pick objects, under the each level prefab


    void Start()
    {
        _pickNumber = _pickParent.transform.childCount;      
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerContoller.ObjectPicked += CheckLevelComplete;
    }

    private void OnDisable()
    {
        PlayerContoller.ObjectPicked -= CheckLevelComplete;
    }

    private void CheckLevelComplete()
    {
        _pickNumber--; 

        if (_pickNumber == 0)
        {
            Destroy(gameObject);

            LevelManager.Instance.LevelPassed();
        }
    }

}
