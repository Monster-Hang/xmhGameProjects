using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform Player1;
    public Transform Player2;
    public Transform AI1;
    public Transform AI2;
    public GameObject wintext;

    private Vector3 offset;//确定偏移
    private Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
        if (Player1 == null && Player2 == null)
            offset = transform.position - (AI1.position + AI2.position) / 2;
        else if (Player2 == null)
        {
            offset = transform.position - Player1.position;
        }
        else if (Player1 == null)
        {
            offset = transform.position - Player2.position;
        }
        else if (Player1 != null && Player2 != null)
            offset = transform.position - (Player1.position + Player2.position) / 2;//相机初始位置 - 中心位置 = 初始偏移
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1 == null && Player2 == null)
            wintext.SetActive(true);
        else if (Player2 == null)
        {
            transform.position = Player1.position + offset;
            camera.orthographicSize = 24f;
        }
        else if (Player1 == null)
        {
            transform.position = Player2.position + offset;
            camera.orthographicSize = 24f;
        }
        else if (Player1 != null && Player2 != null)
        {
            transform.position = (Player1.position + Player2.position) / 2 + offset;//保持偏移（中心 + 偏移 = 相机位置）
            float distance = Vector3.Distance(Player1.position, Player2.position);
            float size = distance * 0.92f;
            camera.orthographicSize = size;
        }
        if (AI1==null&&AI2==null)
        {
            wintext.SetActive(true);
        }
     
    }
}
