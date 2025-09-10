using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;


    void Start()
    {
        Init();
    }
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }

        //..Test Code
        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(20, 5);
        }
        
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
        {
            Batch();
        }
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150; //마이너스로 해야 시계 방향으로 돈다.
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Transform bullet;

            if (index < transform.childCount){
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }
                
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            // 각도 회전
            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);

            // 반지름만큼 이동 (부모 기준)
            bullet.Translate(Vector3.up * 1.5f, Space.Self);

            bullet.GetComponent<Bullet>().Init(damage, -1);
        }
    }
}
