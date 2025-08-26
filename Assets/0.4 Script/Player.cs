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
        //Input.GetAxis() = � �࿡ ���� �Է°��� ���ڷ� ��ȯ, �Է� ���� �ε巴�� �ٲ�� = player �̵� �� �̲����� / GetAxisRaw = ��Ȯ�� ��Ʈ�� ���� ����
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  // normalized = ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ���� / fixedDeltaTime = ���� ������ �ϳ��� �Һ��� �ð�
        // 1. ���� �ش�
        //rigid.AddForce(inputVec);

        // 2. �ӵ� ����
        //rigid.linearVelocity = inputVec;                //�ӵ��� ���� �����Ѵ� = Velocity

        // 3. ��ġ �̵�
        rigid.MovePosition(rigid.position + nextVec);   // ��ġ�� �ű�� = MovePosition = ��ġ �̵��̶� ���� ��ġ�� �����־���Ѵ�.
    }
}
