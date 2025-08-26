using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;   

    void Start()
    {
        
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Input.GetAxis() = 어떤 축에 대한 입력값을 숫자로 반환, 입력 값이 부드럽게 바뀐다 = player 이동 시 미끄러짐 / GetAxisRaw = 명확한 컨트롤 구현 가능
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  // normalized = 벡터 값의 크기가 1이 되도록 좌표가 수정 / fixedDeltaTime = 물리 프레임 하나가 소비한 시간
        // 1. 힘을 준다
        //rigid.AddForce(inputVec);

        // 2. 속도 제어
        //rigid.linearVelocity = inputVec;                //속도를 직접 제어한다 = Velocity

        // 3. 위치 이동
        rigid.MovePosition(rigid.position + nextVec);   // 위치를 옮긴다 = MovePosition = 위치 이동이라 현재 위치도 더해주어야한다.
    }
}
