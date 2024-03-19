using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class block3 : MonoBehaviour
{

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("scene_5");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
