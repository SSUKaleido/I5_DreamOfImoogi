using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;

    bool active = false;
    GameObject note, gm;

    public GameObject UpNote;
    public GameObject DownNote;
    public GameObject LeftNote;
    public GameObject RightNote;

    private void Start()
    {
        gm = GameObject.Find("GameManager");
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(leftKey) && active)
        {
                if (CheckNoteTag("LeftNote"))
                {
                    Destroy(note);
                    gm.GetComponent<GameManager>().AddStreak();
                    active = false;
                }
                else
                {
                    Destroy(note);
                    gm.GetComponent<GameManager>().ResetStreak();
                    Debug.Log("Miss");
                    active = false;
                }               
        }
        else if (Input.GetKeyDown(rightKey) && active)
        {
                if (CheckNoteTag("RightNote"))
                {
                    Destroy(note);
                    gm.GetComponent<GameManager>().AddStreak();
                    active = false;
                }
                else
                {
                    Destroy(note);
                    gm.GetComponent<GameManager>().ResetStreak();
                    Debug.Log("Miss");
                    active = false;
                }
        }
        else if (Input.GetKeyDown(upKey) && active)
        {
                if (CheckNoteTag("UpNote"))
                {
                    Destroy(note);
                    gm.GetComponent<GameManager>().AddStreak();
                    active = false;
                }
                else
                {
                    Destroy(note);
                    gm.GetComponent<GameManager>().ResetStreak();
                    Debug.Log("Miss");
                    active = false;
                }
        }
        else if (Input.GetKeyDown(downKey) && active)
        {
                if (CheckNoteTag("DownNote"))
                {
                    Destroy(note);
                    gm.GetComponent<GameManager>().AddStreak();
                    active = false;
                }
                else
                {
                    Destroy(note);
                    gm.GetComponent<GameManager>().ResetStreak();
                    Debug.Log("Miss");
                    active = false;
                }
        }        
            
        
    }
    
    
    
    
    
    
    
    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.CompareTag("LeftNote")|| col.gameObject.CompareTag("RightNote")|| col.gameObject.CompareTag("UpNote")|| col.gameObject.CompareTag("DownNote"))
        {
            note = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.gameObject == note)
        {
            active = false;
        }
        if (active)
        {
            gm.GetComponent<GameManager>().ResetStreak();
        }
        
    }

    bool CheckNoteTag(string expectedTag)
    {
        return note != null && note.CompareTag(expectedTag);
    }

}

