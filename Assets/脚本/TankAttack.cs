using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{

    private Transform firePosition;
    public GameObject shellPrefab;
    public float shellSpeed = 10;
    public AudioClip shootAudio;

    public KeyCode FireKey = KeyCode.Space;




    // Start is called before the first frame update
    void Start()
    {
        firePosition = transform.Find("FirePosition");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(FireKey))
        {
            AudioSource.PlayClipAtPoint(shootAudio, transform.position);
            GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;

        }
    }
}
