using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    // static = �������� ��� Ű����, �ٷ� �޸𸮿� ��������.

    public float gameTime;
    public float maxGameTime = 2 * 10f;
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;                   //�ν��Ͻ� ������ �ڱ��ڽ� this�� �ʱ�ȭ
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }

    }
}
