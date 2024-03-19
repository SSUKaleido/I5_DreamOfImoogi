using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    /* stage control */
    int currentStage = 1 ;
    GameObject trick;

    /* HP system & Combo */
    int streak = 0;
    public int totalHit = 0; 
    GameObject health;

    /* spawn notes */
    GameObject spawner;
    public GameObject UpNote;
    public GameObject DownNote;
    public GameObject LeftNote;
    public GameObject RightNote;
    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;

    /* music delay */
    public AudioSource music;
    float MusicStartTime = 1.3f; // sync
    bool musicStart = true;
    private bool musicStarted = false;

    /* time control */
    public float timeElapsed = 0.0f; 

    
    private void Awake()
    {
        spawnList = new List<Spawn>();
        ReadSpawnFile();
    }

    private void Start()
    {
        music.Stop();
        PlayerPrefs.SetInt("Streak", 0);
        trick = GameObject.Find("StageGimmick");
        health = GameObject.Find("HealthBarManager");
        spawner = GameObject.Find("SpawnPoint");
    }


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
                musicStarted = true;
            }
            trick.GetComponent<StageGimmick>().Gimmick();
        }          
    }

    void ReadSpawnFile()
    {
        // 1. initialize  
        timeElapsed = 0;
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;
        TextAsset textFile = null;

        // 2. read text file 
        if (currentStage == 1)
        {
            textFile = Resources.Load("Sheet1") as TextAsset;
        }
        else if (currentStage == 2)
        {
            textFile = Resources.Load("Sheet2") as TextAsset;
        }
        else if (currentStage == 3)
        {
            textFile = Resources.Load("Sheet3") as TextAsset;
        }

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
