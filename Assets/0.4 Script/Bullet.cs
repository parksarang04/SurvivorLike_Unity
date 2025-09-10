using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per; // 관통 횟수 (-1이면 무한 관통)

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        if (per > -1)
        {
#if UNITY_6000_0_OR_NEWER
            rigid.linearVelocity = dir * 15;
#else
            rigid.velocity = dir * 15;
#endif
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;

        // ★ 수정: Enemy 스크립트에 데미지 주기
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // ★ 수정: 무한 관통(-1)은 per 감소 안 함
        if (per != -1)
        {
            per--;
            if (per < 0)
            {
#if UNITY_6000_0_OR_NEWER
                rigid.linearVelocity = Vector2.zero;
#else
                rigid.velocity = Vector2.zero;
#endif
                gameObject.SetActive(false);
            }
        }
    }
}