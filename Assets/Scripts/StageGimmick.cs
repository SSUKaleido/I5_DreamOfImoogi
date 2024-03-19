using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StageGimmick : MonoBehaviour
{

    public GameObject gm;
    int currentStage = 1;

    /* stage 1*/
    public GameObject mob;
    private bool mobInterrupt = false;
    private float Speed = 2.0f;

    /* stage 2*/

    /* stage 3*/
    private bool cameraRotated = false;


    public void Gimmick(){
        float tm = gm.GetComponent<GameManager>().timeElapsed;


        if (currentStage == 1)
        {
            if ( tm >= 3.0f && !mobInterrupt)
            {
                mob.transform.Translate(Vector3.up * Speed * Time.deltaTime);
                if (mob.transform.position.y >= -4f || mob.transform.position.y <= -10f)
                {
                    Speed *= -1; // �̵� �ӵ��� ��ȣ�� �ٲ㼭 �ݴ� �������� �̵��ϵ��� ��
                }
                else if (mob.transform.position.y <= -9.7f && tm >= 20.0f)
                {              
                    mobInterrupt = true;
                }
            }
            
            
        }
        else if (currentStage == 2)
        {
            //stage2
        }
        else if (currentStage == 3)
        {
            if (tm > 5f && tm < 7f && !cameraRotated)
            {
                RotateCamera180Degrees();
                cameraRotated = true;
            }
            else if (tm >= 7f)
            {
                ResetCameraRotation();
            }
        }
    }

    void RotateCamera180Degrees()
    {
        // ���� ī�޶��� ȸ������ ������
        Vector3 currentRotation = Camera.main.transform.rotation.eulerAngles;

        // z�� ȸ������ 180���� �����Ͽ� ī�޶� ȸ��
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z + 180f);
        Camera.main.transform.transform.Translate(0f, 1.5f, 0f);
    }

    void ResetCameraRotation()
    {
        // ���� ī�޶��� ȸ������ ������
        Vector3 currentRotation = Camera.main.transform.rotation.eulerAngles;

        // z�� ȸ������ ���� ������ �����Ͽ� ī�޶� ȸ��
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0.0f);
        Camera.main.transform.position = new Vector3(0f, 0f, -10.0f);

    }



}
