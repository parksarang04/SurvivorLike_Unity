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
        //Input.GetAxis() = � �࿡ ���� �Է°��� ���ڷ� ��ȯ, �Է� ���� �ε巴�� �ٲ�� = player �̵� �� �̲����� / GetAxisRaw = ��Ȯ�� ��Ʈ�� ���� ����
        //inputVec.x = Input.GetAxisRaw("Horizontal");
        //inputVec.y = Input.GetAxisRaw("Vertical");

        //Input System ��Ű����ġ�� player �̵� �ڵ� ���ʿ�. ��� void OnMove() ���
    }

    void FixedUpdate()
    {
                            //OnMove()���� normalized ����ϱ⿡ ���൵�ȴ�.
        Vector2 nextVec = inputVec/*.normalized*/* speed * Time.fixedDeltaTime;  // normalized = ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ���� / fixedDeltaTime = ���� ������ �ϳ��� �Һ��� �ð�
        // 1. ���� �ش�
        //rigid.AddForce(inputVec);

        // 2. �ӵ� ����
        //rigid.linearVelocity = inputVec;                //�ӵ��� ���� �����Ѵ� = Velocity

        // 3. ��ġ �̵�
        rigid.MovePosition(rigid.position + nextVec);   // ��ġ�� �ű�� = MovePosition = ��ġ �̵��̶� ���� ��ġ�� �����־���Ѵ�.
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
            spriter.flipX = inputVec.x < 0; //spriter.flipX = inputVec.x < true �� ������ ����� �����̱⿡ �Է� ������ ���������� ������� ����.
        }
    }
}
