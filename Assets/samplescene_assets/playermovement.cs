using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class playermovement : MonoBehaviour
{
    //public�� unity editor�ε� ���� �ٲܼ�����
    private float movespeed = 5;
    private Rigidbody2D rb;
    private bool facingright = true;
    private float movedirection;

    //awake �޼ҵ�� start�޼ҵ� ���� ������Ʈ�� �����ɶ� ȣ���.
    private void Awake()
    {
        //������Ʈ�� ������Ʈ ������� �Ʒ��� �ڵ带 'component referencing'�̶�� �ϴµ�
        //�̰� start�� �ִ°ͺ��� awake�� �ִ� ���� �ξ� ȿ������. 
        //��ü ������Ʈ ���� �������� Ȯ���� ���̰� ����. 
        rb = GetComponent<Rigidbody2D>(); 

    }
    //����Ƽ ��ũ��Ʈ �⺻Ʋ
    // Start is called before the first frame update (�������Ҷ� �ѹ� ȣ���. ù update�Լ����� ���� ȣ��Ǵ°�.)
    void Start()
    {
        
    }

    // Update is called once per frame (�д� 60�������̸� 1�ʿ� �ѹ��� ȣ���)
    void Update()
    {
        // ���� ���⿡ �ζ������� ���� ����µ�
        // �κм����ϰ� ctrl+.�ϱ⸸ �ϸ� ���ݰ��� ����Լ��� ������ ������ټ�����
        ProcessInputs(); //a,d�� ȭ��ǥŰ �Է°����� ���� �ʱ�ȭ
        FlipAnimate(); // ������� �÷��̾������Ʈ ��������. 
    }

    private void FlipAnimate()
    {
        if (movedirection < 0 && facingright)
        {
            FlipCharacter();
        }
        else if (movedirection > 0 && !facingright)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        movedirection = Input.GetAxis("Horizontal"); //-1~1���� ��
        rb.velocity = new Vector2(movedirection * movespeed, rb.velocity.y);
        //2��° �� ������ �ɰͰ�...������ �츰 y���� �����̴ϱ�...
    }

    private void FlipCharacter() {

        facingright = !facingright;


        float nowpos = transform.position.x;
        transform.Rotate(0f, nowpos, 0f);
    }
}
