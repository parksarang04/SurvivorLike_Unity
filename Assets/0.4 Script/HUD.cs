using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, time, Health } //열거형 enum으로 선언
    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.instance.level);   //0번째 인자값은 여기에 들어간다{}
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill);   //0번째 인자값은 여기에 들어간다{}
                break;
                
            case InfoType.time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{00:D2}:{1:D2}",min,sec);
                break;
            case InfoType.Health:
                float curHealth = GameManager.instance.health;      // 현재 체력
                float maxHealth = GameManager.instance.maxHealth;   // 최대 체력 (고정값)
                mySlider.value = curHealth / maxHealth;
                break;

        }
    }
}
