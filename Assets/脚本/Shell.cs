using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    public GameObject shellExplosionPrefab;

    public AudioClip shellExplosionAudio;
 

    public void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);

        if(collider.tag == "Tank2" || collider.tag == "Tank1"|| collider.tag == "AI001"|| collider.tag == "AI002")
        {
            collider.SendMessage("TakeDamage");
        }
    }

}
