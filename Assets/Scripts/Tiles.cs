using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tiles : MonoBehaviour
{
    /*Char Pattern to Image Pattern Legend:
    A = BlueDash
    B = RedDash
    C = BlueCircle
    D = RedCircle
     */
    public List<char> patternCode;
    public int patternLimit = 6;
    public List<GameObject> patternObjects;
    void Start()
    {
        //AssignPattern();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignPattern()
    {
        if (patternCode.Count == 6)
        {
            for (int i = 0; i < patternObjects.Count; i++)
            {
                //Debug.Log(i);
                switch (patternCode[i])
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

    public void OnButtonPress()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AssignToButton(patternCode);
    }
}
