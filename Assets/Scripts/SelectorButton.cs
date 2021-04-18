using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorButton : MonoBehaviour
{
    // Start is called before the first frame update
    public List<char> heldCode;
    public List<GameObject> patternObjects;

    private void Start()
    {
        for (int i = 0; i < patternObjects.Count; i++)
        {
            switch (heldCode[i])
            {
                case 'A':
                    patternObjects[i].GetComponent<Image>().sprite = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueDash.sprite;
                    patternObjects[i].GetComponent<Image>().color = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueDash.color;
                    patternObjects[i].transform.localScale = new Vector3(1.5f, 1, 1);
                    break;
                case 'B':
                    patternObjects[i].GetComponent<Image>().sprite = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueCircle.sprite;
                    patternObjects[i].GetComponent<Image>().color = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueCircle.color;
                    break;
                case 'C':
                    patternObjects[i].GetComponent<Image>().sprite = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().redDash.sprite;
                    patternObjects[i].GetComponent<Image>().color = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().redDash.color;
                    break;
                case 'D':
                    patternObjects[i].GetComponent<Image>().sprite = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().redCircle.sprite;
                    patternObjects[i].GetComponent<Image>().color = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().redCircle.color;
                    patternObjects[i].transform.localScale = new Vector3(1.5f, 1, 1);
                    break;
                case 'E':
                    patternObjects[i].GetComponent<Image>().color = new Color(0, 0, 0, 0); //GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueDash.sprite;
                    break;
            }
        }
    }
    public void OnSelectorButtonPressed()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SelectorCheck(heldCode);
        heldCode = null;
        //Update button visuals
    }

    public void AssignCode(List<char> listToAssign)
    {
        heldCode = listToAssign;
        Debug.Log(heldCode[0]);
        for (int i = 0; i < patternObjects.Count; i++)
        {
            switch (heldCode[i])
            {
                case 'A':
                    patternObjects[i].GetComponent<Image>().sprite = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueDash.sprite;
                    patternObjects[i].GetComponent<Image>().color = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueDash.color;
                    patternObjects[i].transform.localScale = new Vector3(1.5f, 1, 1);
                    break;
                case 'B':
                    patternObjects[i].GetComponent<Image>().sprite = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueCircle.sprite;
                    patternObjects[i].GetComponent<Image>().color = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueCircle.color;
                    break;
                case 'C':
                    patternObjects[i].GetComponent<Image>().sprite = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().redDash.sprite;
                    patternObjects[i].GetComponent<Image>().color = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().redDash.color;
                    break;
                case 'D':
                    patternObjects[i].GetComponent<Image>().sprite = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().redCircle.sprite;
                    patternObjects[i].GetComponent<Image>().color = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().redCircle.color;
                    patternObjects[i].transform.localScale = new Vector3(1.5f, 1, 1);
                    break;
                case 'E':
                    patternObjects[i].GetComponent<Image>().color = new Color(0, 0, 0, 0); //GameObject.FindWithTag("GameManager").GetComponent<GameManager>().blueDash.sprite;
                    break;
            }
        }
    }
}
