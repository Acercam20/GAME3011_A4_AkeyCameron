using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTile : MonoBehaviour
{
    public List<char> comboCode;
    public List<GameObject> patternObjects;
    public int id;
    public bool completed;
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckMatch(List<char> givenCode)
    {
        
        if (!completed)
        {
            //Debug.Log(comboCode.Count + " = " + givenCode.Count);
            if (givenCode != null)
            {
                bool temp = true;
                for (int i = 0; i < givenCode.Count; i++)
                {
                    if (!(givenCode[i] == comboCode[i]))
                    {
                        temp = false;
                    }
                }
                if (temp)
                {
                    Debug.Log("We in");
                    completed = true;
                    CompleteTile();
                }
            }
        }
    }

    private void CompleteTile()
    {
        completed = true;
        gameObject.GetComponent<Image>().color = new Color(0, 0.8f, 0, 1);

        if (gameManager.keyTile1.GetComponent<KeyTile>().completed && gameManager.keyTile2.GetComponent<KeyTile>().completed && gameManager.keyTile3.GetComponent<KeyTile>().completed)
        {
            gameManager.EndGame(true);
        }
    }

    public void SetTile(string listToSet)
    {
        Debug.Log(listToSet.Length);
        for (int i = 0; i < listToSet.Length; i++)
        {
            if (listToSet.Length == 6)
                comboCode.Add(listToSet[i]);
        }
            


        for (int i = 0; i < patternObjects.Count; i++)
        {
            switch (comboCode[i])
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
