using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per; // ���� Ƚ�� (-1�̸� ���� ����)

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

        // �� ����: Enemy ��ũ��Ʈ�� ������ �ֱ�
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // �� ����: ���� ����(-1)�� per ���� �� ��
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