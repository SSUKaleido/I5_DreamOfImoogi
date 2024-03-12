using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 10;

    bool changeSpeed = false;
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
        /*
        if (!changeSpeed && (gm.GetComponent<GameManager>().totalHit >= 10) && (gm.GetComponent<GameManager>().totalHit % 10 == 0))
        {
            speed += 3;
            rb.velocity = new Vector2(-speed, 0);
            Debug.Log(speed);
            changeSpeed = true;
        }
        */
    }
}
