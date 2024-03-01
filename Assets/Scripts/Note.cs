using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 7;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    void Update()
    {
        
    }
}
