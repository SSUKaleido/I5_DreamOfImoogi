using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Slider PlayerHealthBar;
    public Slider EnemyMaxHealthBar;

    public float Damage;

    private void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.H))
        {
            EnemyMaxHealthBar.value -= 2 * Damage;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            EnemyMaxHealthBar.value -= 1 * Damage;
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            //no change
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            PlayerHealthBar.value -= 2 * Damage;
        }*/


    }

    public void Hit()
    {
        EnemyMaxHealthBar.value -= 1 * Damage;
    }

    public void Miss()
    {
        PlayerHealthBar.value -= 1 * Damage;
    }
}
