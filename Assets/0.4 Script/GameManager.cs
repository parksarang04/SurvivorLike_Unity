using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    // static = 정적으로 사용 키워드, 바로 메모리에 얹어버린다.
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;                   //인스턴스 변수를 자기자신 this로 초기화
    }   
}
