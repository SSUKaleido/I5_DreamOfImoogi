using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interaction2 : MonoBehaviour
{
    public GameObject player;
    public GameObject distance_checker;
    public GameObject Tkey;
    private bool Tactive = false;

    private float dist;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(player.transform.position, distance_checker.transform.position);
        if (dist < 7)
        {
            Tkey.SetActive(true);
            Tactive = true;
            if (Input.GetKeyDown(KeyCode.T))
            { SceneManager.LoadScene("RGstage3"); }

        }
        else
        {
            Tkey.SetActive(false);
            Tactive = false;
        }
    }
}