using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyConstant : MonoBehaviour
{
    public int difficulty, skillLevel;

    void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("DifficultyConstant").Length > 0)
        {
            for (int i = 1; i < GameObject.FindGameObjectsWithTag("DifficultyConstant").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("DifficultyConstant")[i]);
            }
        }
    }

    void Update()
    {
        
    }
}
