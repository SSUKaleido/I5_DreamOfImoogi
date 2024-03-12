using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    int streak = 0; //combo
    public int totalHit = 0; 
    GameObject health;

    GameObject spawner;
    public GameObject UpNote;
    public GameObject DownNote;
    public GameObject LeftNote;
    public GameObject RightNote;

    public AudioSource music;
    float MusicStartTime = 1.8f; // caution!!! bluetooth headphone sync

    //int beat = 1;
    float timeElapsed = 0.0f; 
    bool musicStart = true;

    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;
    
    
    private void Awake()
    {
        spawnList = new List<Spawn>();
        ReadSpawnFile();
    }

    private void Start()
    {
        
        PlayerPrefs.SetInt("Streak", 0);

        health = GameObject.Find("HealthBarManager");
        spawner = GameObject.Find("SpawnPoint");


    }

    private bool musicStarted = false;

    private void Update()
    {
        
        if (musicStart == true)
        {
            timeElapsed += Time.deltaTime;
            if( spawnEnd == false) {
                spawnNote();
            }
            if (timeElapsed >= MusicStartTime && !musicStarted)
            {
                music.Play();
                Debug.Log("db0");
                musicStarted = true;
            }
        }          
    }
    void ReadSpawnFile()
    {
        // 1. initialize  
        timeElapsed = 0;
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        // 2. read text file 
        TextAsset textFile = Resources.Load("Sheet2") as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);

        while (stringReader != null)
        {

            string line = stringReader.ReadLine();

            if (line == null)
            {
                break;
            }

            Spawn spawnData = new Spawn();
            spawnData.arrow = int.Parse(line.Split('\t')[0]);
            spawnData.delay = float.Parse(line.Split('\t')[1]);
            spawnData.noteType = int.Parse(line.Split('\t')[2]);
            spawnData.length = float.Parse(line.Split('\t')[3]);
            spawnList.Add(spawnData);
        }
        stringReader.Close();
    }
    void spawnNote()
    {
        int noteArrow = spawnList[spawnIndex].arrow;
        float noteTime = spawnList[spawnIndex].delay;
        //int Type = spawnList[spawnIndex].noteType;
        //float lnLength = spawnList[spawnIndex].length;

        if ( noteTime <= timeElapsed )
        {
            switch (noteArrow)
            {
                case 0:
                    Instantiate(UpNote, spawner.transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(DownNote, spawner.transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(LeftNote, spawner.transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(RightNote, spawner.transform.position, Quaternion.identity);
                    break;
                default:
                    //Debug.LogError("Invalid note arrow type: " + noteArrow);
                    break;
            }
            spawnIndex++;
           
        }
       
        if (spawnIndex == spawnList.Count)
        {
            spawnEnd = true;
            musicStart = false;
            return;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        ResetStreak();
        
    }
    public void AddStreak()
    {
        //n보다 작으면
        health.GetComponent<UserInterface>().Hit();
        streak++;
        totalHit++;
        UpdateGUI();
    }

    public void ResetStreak()
    {
        health.GetComponent<UserInterface>().Miss();
        //0보다 작으면?
        //lose
        streak = 0;
        UpdateGUI();
    }
    
    void Lose()
    {
        //lose the game 
    }

    public void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
    }


}
