using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    int currentStage = 3;
    Rigidbody2D rb;
    float speed = 10;

    private bool changeSpeed1 = false;
    private bool changeSpeed2 = false;
    GameObject gm;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = new Vector2(-speed, 0);
        gm = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (currentStage == 2)
        {
            float tm = gm.GetComponent<GameManager>().timeElapsed;

            if (tm >= 45.0f && !changeSpeed1)
            {
                speed += 10;
                changeSpeed1 = true;
                rb.velocity = new Vector2(-speed, 0);         
            }
            else if (tm >= 70.0f)
            {
                speed = 10;
                rb.velocity = new Vector2(-speed, 0);
            }

            if (tm >= 100.0f && !changeSpeed2)
            {
                speed += 10;
                changeSpeed2 = true;
                rb.velocity = new Vector2(-speed, 0);
            }
            else if (tm >= 150.0f)
            {
                speed = 10;
                rb.velocity = new Vector2(-speed, 0);
            }
        }

    }
}
