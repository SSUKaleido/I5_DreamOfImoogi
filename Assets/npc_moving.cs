using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_moving : MonoBehaviour
{

    float speed = 0.000001f;//�������� ��������

    int time; //�󸶳� ���� �� �ɼǴ�� �����ϰ���
    int option;
    /*option1-���������� �̵�
    option2-�������� �̵�
    option3-��ü�����*/

    void option1()
    { transform.Translate(Vector2.right* speed * Time.deltaTime);
    }
    void option2()
    {transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void option3()
    {    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        option = Random.Range(1, 4); //1,2,3
        time = Random.Range(900000,1000000); //�������� ��������


        if (option == 1)
        {
            for (int t = 0; t <= time; t++)
            { option1(); }
        }
        else if (option == 2)
        {
            for (int t = 0; t <= time; t++)
            { option2(); }
        }
        else if (option == 3)
        {for (int t = 0; t <= time; t++)
            option3();}
        }
    }






