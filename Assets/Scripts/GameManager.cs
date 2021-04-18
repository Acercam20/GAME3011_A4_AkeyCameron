using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject TilePrefab;
    public List<GameObject> TileList;
    public int maxNumberOfTiles; //Total number of tiles. This cannot exceed the amount of grid spaces
    public float tileMovementSpeed = 1; //Seconds between each blink
    public int rows;
    public int columns;
    private int totalSpaces = 0;

    public GameObject keyTile1;
    public GameObject keyTile2;
    public GameObject keyTile3;

    public GameObject selectorButton;

    private string keyTileCombo1;
    private string keyTileCombo2;
    private string keyTileCombo3;

    public Image blueDash;
    public Image redDash;
    public Image blueCircle;
    public Image redCircle;

    public Text timerText;
    public Text skillText;

    public GameObject HackingCanvas;
    public GameObject ResultsCanvas;
    public Text resultsText;
    public Text skillLevelText;
    GameObject t1;
    GameObject t2;
    GameObject t3;

    private int seconds = 1;
    float timer = 0.0f;
    public int maxTime;

    private bool shining = false;
    public bool isMin = false;
    //Add a time between tile shuffles
    void Start()
    {
        ResultsCanvas.SetActive(false);
        maxNumberOfTiles = rows * columns;
        //GameObject t1 = Instantiate(TilePrefab);
        CreateTiles();
        SpawnTiles();
        

        if (GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().difficulty == 0)
        {
            maxTime = 120;
            InvokeRepeating("ShuffleTiles", 0.1f, 1.5f);
        }
        else if (GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().difficulty == 1)
        {
            maxTime = 90;
            InvokeRepeating("ShuffleTiles", 0.1f, 1.0f);
        }
        else if (GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().difficulty == 2)
        {
            maxTime = 60;
            InvokeRepeating("ShuffleTiles", 0.1f, 0.5f);
        }

        InvokeRepeating("TimerLoop", 1, 1);
        InvokeRepeating("TileShine", 1, 1);
        timerText.text = "Time: " + maxTime.ToString();
        skillText.text = "Skill Level: " + GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().skillLevel.ToString();
    }

    public void TileShine()
    {
        if (!shining)
        {
            int r = Random.Range(0, 60);
            if (r > 59 - GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().skillLevel)
            {
                int min = 1;
                int max = 4;

                if (keyTile1.GetComponent<KeyTile>().completed)
                    min = 2;

                if (keyTile3.GetComponent<KeyTile>().completed)
                    max = 3;


                if (keyTile1.GetComponent<KeyTile>().completed && keyTile2.GetComponent<KeyTile>().completed)
                {
                    t3.GetComponent<Image>().color = new Color(0.5136614f, 0.9150943f, 0.5718657f, 1);
                    shining = true;
                    return;
                }
                else if (keyTile3.GetComponent<KeyTile>().completed && keyTile2.GetComponent<KeyTile>().completed)
                {
                    t1.GetComponent<Image>().color = new Color(0.5136614f, 0.9150943f, 0.5718657f, 1);
                    shining = true;
                    return;
                }
                else if (keyTile3.GetComponent<KeyTile>().completed && keyTile1.GetComponent<KeyTile>().completed)
                {
                    t2.GetComponent<Image>().color = new Color(0.5136614f, 0.9150943f, 0.5718657f, 1);
                    shining = true;
                    return;
                }

                if (Random.Range(min, max) == 1)
                {
                    t1.GetComponent<Image>().color = new Color(0.5136614f, 0.9150943f, 0.5718657f, 1);
                }
                else if (Random.Range(min, max) == 2)
                {
                    t2.GetComponent<Image>().color = new Color(0.5136614f, 0.9150943f, 0.5718657f, 1);
                }
                else if (Random.Range(min, max) == 3)
                {
                    t3.GetComponent<Image>().color = new Color(0.5136614f, 0.9150943f, 0.5718657f, 1);
                }
                shining = true;
            }
        }
        else
        {
            t1.GetComponent<Image>().color = new Color(0.34117647058f, 0.34117647058f, 0.34117647058f, 1);
            t2.GetComponent<Image>().color = new Color(0.34117647058f, 0.34117647058f, 0.34117647058f, 1);
            t3.GetComponent<Image>().color = new Color(0.34117647058f, 0.34117647058f, 0.34117647058f, 1);
            shining = false;
        }
    }

    void Update()
    {
        
    }

    public void TimerLoop()
    {
        if (!isMin)
            seconds++;
        timerText.text = "Time: " + (maxTime - seconds).ToString();

        if (maxTime - seconds <= 0)
        {
            maxTime = 999;
            EndGame(false);
        }
    }

    public void EndGame(bool win)
    {
        ResultsCanvas.SetActive(true);
        if (win)
        {
            GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().skillLevel++;
            resultsText.text = "Victroy!";
            skillLevelText.text = "Skill Level Increased to Level " + GameObject.FindWithTag("DifficultyConstant").GetComponent<DifficultyConstant>().skillLevel.ToString();
        }
        else
        {
            resultsText.text = "Defeat";
            skillLevelText.text = "";
        }
    }

    void ShuffleTiles()
    {
        for (int i = 0; i < TileList.Count; i++)
        {
            if ((TileList[i].transform.position.x + 100) > 1661 )
            {
                TileList[i].transform.position = new Vector3(TileList[i].transform.position.x - 1000, TileList[i].transform.position.y, TileList[i].transform.position.z);
            }
            TileList[i].transform.position = new Vector3(TileList[i].transform.position.x + 100, TileList[i].transform.position.y, TileList[i].transform.position.z);
        }
    }

    private void CreateTiles()
    {
        t1 = Instantiate(TilePrefab);
        t2 = Instantiate(TilePrefab);
        t3 = Instantiate(TilePrefab);
        for (int i = 0; i < 6; i++)
        {
            char c = (char)('A' + Random.Range(0, 5));
            keyTileCombo1 += c;
            //t1.GetComponent<Tiles>().patternCode[i] = keyTileCombo1[i];
            t1.GetComponent<Tiles>().patternCode.Add(keyTileCombo1[i]);
            t1.GetComponent<Tiles>().AssignPattern();
        }
        keyTile1.GetComponent<KeyTile>().SetTile(keyTileCombo1);
        for (int i = 0; i < 6; i++)
        {
            char c = (char)('A' + Random.Range(0, 5));
            keyTileCombo2 += c;
            //t2.GetComponent<Tiles>().patternCode[i] = keyTileCombo2[i];
            t2.GetComponent<Tiles>().patternCode.Add(keyTileCombo2[i]);
            t2.GetComponent<Tiles>().AssignPattern();
        }
        keyTile2.GetComponent<KeyTile>().SetTile(keyTileCombo2);
        for (int i = 0; i < 6; i++)
        {
            char c = (char)('A' + Random.Range(0, 5));
            keyTileCombo3 += c;
            //t3.GetComponent<Tiles>().patternCode[i] = keyTileCombo3[i];
            t3.GetComponent<Tiles>().patternCode.Add(keyTileCombo3[i]);
            t3.GetComponent<Tiles>().AssignPattern();
        }
        keyTile3.GetComponent<KeyTile>().SetTile(keyTileCombo3);

        t1.transform.parent = HackingCanvas.transform;
        t2.transform.parent = HackingCanvas.transform;
        t3.transform.parent = HackingCanvas.transform;


        TileList.Add(t1.gameObject);
        TileList.Add(t2.gameObject);
        TileList.Add(t3.gameObject);

        for (int i = 0; i < maxNumberOfTiles - 3; i++)
        {
            if (Random.value > 0.4f)
            {
                GameObject t = Instantiate(TilePrefab);
                t.GetComponent<Tiles>().patternCode.Add((char)('A' + Random.Range(0, 5)));
                t.GetComponent<Tiles>().patternCode.Add((char)('A' + Random.Range(0, 5)));
                t.GetComponent<Tiles>().patternCode.Add((char)('A' + Random.Range(0, 5)));
                t.GetComponent<Tiles>().patternCode.Add((char)('A' + Random.Range(0, 5)));
                t.GetComponent<Tiles>().patternCode.Add((char)('A' + Random.Range(0, 5)));
                t.GetComponent<Tiles>().patternCode.Add((char)('A' + Random.Range(0, 5)));
                t.transform.parent = HackingCanvas.transform;
                t.GetComponent<Tiles>().AssignPattern();
                TileList.Add(t.gameObject);
            }
            else
            {
                GameObject t = Instantiate(TilePrefab);
                for (int j = 0; j < 6; j++)
                    t.GetComponent<Tiles>().patternCode.Add('E');

                t.transform.parent = HackingCanvas.transform;
                TileList.Add(t.gameObject);
                t.GetComponent<Tiles>().AssignPattern();
            }
        }
    }

    private void SpawnTiles()
    {
        for (int i = 0; i < TileList.Count; i++)
        {
            GameObject temp = TileList[i];
            int randomIndex = Random.Range(i, TileList.Count);
            TileList[i] = TileList[randomIndex];
            TileList[randomIndex] = temp;
        }

        Debug.Log(TileList.Count);
        int c = 0;
        int r = 0;
        for (int i = 0; i < TileList.Count; i++)
        {
            TileList[i].transform.position = new Vector3(c * 100 + 670, r * 100 + 200, 0);
            c++;
            if (c == 10)
            {
                c = 0;
                r++;
            }
        }
    }

    public void SelectorCheck(List<char> listToAssign)
    {
        keyTile1.GetComponent<KeyTile>().CheckMatch(listToAssign);
        keyTile2.GetComponent<KeyTile>().CheckMatch(listToAssign);
        keyTile3.GetComponent<KeyTile>().CheckMatch(listToAssign);
    }

    public void AssignToButton(List<char> listToAssign)
    {
        selectorButton.GetComponent<SelectorButton>().AssignCode(listToAssign);
        //Update button visuals
    }
}
