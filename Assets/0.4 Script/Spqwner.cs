using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spqwner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;  //���� Ŭ������ �״�� Ÿ������ Ȱ���Ͽ� �迭 ���� ����

    int level;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();    
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = (Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length -1));     //������ ���ڷ� ������ �ð��� ���� ������ �ö󰡵��� �ۼ�
        // Mathf.FloorToInt = �Ҽ��� �Ʒ��� ������ int������ �ٲٴ� �Լ�

        if (timer > spawnData[level].spawnTime)
        {        
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData  //SpawnDataŬ������ ����ȭ�� �Ǹ鼭 unity ȭ�鿡 �ν����� â���� ���� �� �ִ�.
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}
