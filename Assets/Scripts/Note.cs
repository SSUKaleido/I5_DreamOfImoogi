using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    int currentStage = 1;
    Rigidbody2D rb;
    float speed = 10;

    private bool changeSpeed = false;
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

            if (tm >= 5.0f && !changeSpeed)
            {
                speed += 10;
                changeSpeed = true;
                rb.velocity = new Vector2(-speed, 0);         
            }
            else if (tm >= 20.0f)
            {
                speed = 10;
                rb.velocity = new Vector2(-speed, 0);
            }
        }

    }
}
