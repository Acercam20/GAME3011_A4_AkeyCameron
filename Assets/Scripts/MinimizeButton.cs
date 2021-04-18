using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimizeButton : MonoBehaviour
{
    public GameObject hackingCanvas;
    public GameObject gridOutline;
    public GameObject resultsCanvas;
    bool active = true;

    public void OnMinimizeButtonPressed()
    {
        if (active)
        {
            gridOutline.SetActive(false);
            hackingCanvas.SetActive(false);
            //resultsCanvas.SetActive(false);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isMin = true;
            active = false;
        }
        else
        {
            gridOutline.SetActive(true);
            hackingCanvas.SetActive(true);
            //resultsCanvas.SetActive(true);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isMin = false;
            active = true;
        }
    }
}
