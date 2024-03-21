using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class playermovement : MonoBehaviour
{
    //public은 unity editor로도 값을 바꿀수있음
    private float movespeed = 5;
    private Rigidbody2D rb;
    private bool facingright = true;
    private float movedirection;

    //awake 메소드는 start메소드 전에 오브젝트들 생성될때 호출됨.
    private void Awake()
    {
        //오브젝트의 컴포넌트 끌어오는 아래의 코드를 'component referencing'이라고 하는데
        //이걸 start에 넣는것보다 awake에 넣는 것이 훨씬 효율적임. 
        //전체 오브젝트 수가 많아지면 확실한 차이가 보임. 
        rb = GetComponent<Rigidbody2D>(); 

    }
    //유니티 스크립트 기본틀
    // Start is called before the first frame update (씬시작할때 한번 호출됨. 첫 update함수보다 전에 호출되는것.)
    void Start()
    {
        
    }

    // Update is called once per frame (분당 60프레임이면 1초에 한번씩 호출됨)
    void Update()
    {
        // 원래 여기에 인라인으로 줄줄 썼었는데
        // 부분선택하고 ctrl+.하기만 하면 지금같은 멤버함수로 빠르게 만들어줄수있음
        ProcessInputs(); //a,d나 화살표키 입력값으로 변수 초기화
        FlipAnimate(); // 방향따라 플레이어스프라이트 뒤집어줌. 
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
        movedirection = Input.GetAxis("Horizontal"); //-1~1사이 값
        rb.velocity = new Vector2(movedirection * movespeed, rb.velocity.y);
        //2번째 항 버려도 될것같...어차피 우린 y축은 고정이니까...
    }

    private void FlipCharacter() {

        facingright = !facingright;


        float nowpos = transform.position.x;
        transform.Rotate(0f, nowpos, 0f);
    }
}
