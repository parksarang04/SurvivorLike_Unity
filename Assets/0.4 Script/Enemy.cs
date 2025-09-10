using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    bool isLive;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
#if UNITY_6000_0_OR_NEWER
        rigid.linearVelocity = Vector2.zero;
#else
        rigid.velocity = Vector2.zero;
#endif
    }

    void LateUpdate()
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    // �� ����: Bullet �±� �˻� ����, ��� TakeDamage �Լ��� ó��
    public void TakeDamage(float damage)
    {
        if (!isLive) return;

        health -= damage;

        if (health > 0)
        {
            // �ǰ� �ִϸ��̼�, ����Ʈ �� �߰� ����
        }
        else
        {
            Dead();
        }
    }

    void Dead()
    {
        isLive = false;
        gameObject.SetActive(false);
    }
}