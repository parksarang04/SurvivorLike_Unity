using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spqwner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;  //만든 클래스를 그대로 타입으로 활용하여 배열 변수 선언

    int level;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();    
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = (Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length -1));     //적절한 숫자로 나누어 시간에 맞춰 레벨이 올라가도록 작성
        // Mathf.FloorToInt = 소수점 아래는 버리고 int형으로 바꾸는 함수

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
public class SpawnData  //SpawnData클래스는 직렬화가 되면서 unity 화면에 인스펙터 창에서 보일 수 있다.
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}
