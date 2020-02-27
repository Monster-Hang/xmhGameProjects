using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp2 : MonoBehaviour
{

    public Transform Player2Hp;
    public Transform Player1Hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //血条跟随 ui：屏幕坐标    坦克：世界坐标
        //坐标转换（世界坐标    ->   屏幕坐标）
        Player2Hp.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 4);
        Player1Hp.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 4);
    }
}
