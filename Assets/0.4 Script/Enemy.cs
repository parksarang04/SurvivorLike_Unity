using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    bool isLive;
    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {   
        // ��ġ ���� = Ÿ�� ��ġ - ���� ��ġ
        Vector2 dirVec = target.position - rigid.position;  
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);   //�÷��̾��� Ű�Է� ���� ���� �̵� = ������ ���� ���� ���� �̵�
        rigid.linearVelocity  = Vector2.zero;
    }
}
