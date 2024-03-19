using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interaction2 : MonoBehaviour
{
    public GameObject player;
    public GameObject distance_checker;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(player.transform.position, distance_checker.transform.position); //이무기와 표식 사이 거리
        if (dist < 5) {
            print("@@@@@");
            SceneManager.LoadScene("scene_2");}
    }
}
