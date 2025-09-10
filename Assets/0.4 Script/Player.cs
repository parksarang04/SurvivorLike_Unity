using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;
    Animator  anim;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Start()
    {
        
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponentInChildren<Scanner>();
    }
    void Update()
    {
        //Input.GetAxis() = 어떤 축에 대한 입력값을 숫자로 반환, 입력 값이 부드럽게 바뀐다 = player 이동 시 미끄러짐 / GetAxisRaw = 명확한 컨트롤 구현 가능
        //inputVec.x = Input.GetAxisRaw("Horizontal");
        //inputVec.y = Input.GetAxisRaw("Vertical");

        //Input System 패키지설치로 player 이동 코드 불필요. 대신 void OnMove() 사용
    }

    void FixedUpdate()
    {
                            //OnMove()에서 normalized 사용하기에 빼줘도된다.
        Vector2 nextVec = inputVec/*.normalized*/* speed * Time.fixedDeltaTime;  // normalized = 벡터 값의 크기가 1이 되도록 좌표가 수정 / fixedDeltaTime = 물리 프레임 하나가 소비한 시간
        // 1. 힘을 준다
        //rigid.AddForce(inputVec);

        // 2. 속도 제어
        //rigid.linearVelocity = inputVec;                //속도를 직접 제어한다 = Velocity

        // 3. 위치 이동
        rigid.MovePosition(rigid.position + nextVec);   // 위치를 옮긴다 = MovePosition = 위치 이동이라 현재 위치도 더해주어야한다.
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0; //spriter.flipX = inputVec.x < true 는 무조건 뒤집어서 고정이기에 입력 방향대로 뒤집어지는 연산식을 넣음.
        }
    }
}
