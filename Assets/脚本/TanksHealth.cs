using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TanksHealth : MonoBehaviour
{
    public Slider healthslider;
    public Slider healthslider0;
    public int hp = 100;//血量

    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;



    // Start is called before the first frame update
    void Start()
    {
       healthslider.value = healthslider.maxValue = hp;
       healthslider0.value = healthslider0.maxValue = hp;
    }
    // Update is called once per frame
    void Update()
    {
        if (healthslider0.value > healthslider.value)
        {
            healthslider0.value -= 0.3f;
        }
    }


    void TakeDamage()
    {
        if (hp <= 0) return;
        hp -=Random.Range(10,20);
        healthslider.value = hp;
        if (hp<=0)       //受到伤害之后 血量为0 控制死亡效果
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio,transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);       //实例化爆炸效果
            GameObject.Destroy(this.gameObject);       //销毁自身
            Destroy(healthslider.gameObject);
            Destroy(healthslider0.gameObject);
        }
    }





}
