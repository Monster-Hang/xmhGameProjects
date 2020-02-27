using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 暂停 : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Continue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button_Enter()
    {
        Time.timeScale = 0;
        Continue.SetActive(true);
        Pause.SetActive(false);
    }
}
