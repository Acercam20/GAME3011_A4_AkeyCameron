using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DifficultyButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEasyButtonPressed()
    {
        GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().difficulty = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void OnMediumButtonPressed()
    {
        GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().difficulty = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void OnHardButtonPressed()
    {
        GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().difficulty = 2;
        SceneManager.LoadScene("SampleScene");
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
