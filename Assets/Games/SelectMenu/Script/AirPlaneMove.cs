using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneMove : MonoBehaviour
{
    Animator airPlane;
    public bool isMove = false;

    public float speed = 0.7f; //　移動スピード
    public float moveY = 0.2f; // 移動値
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        isMove = false;
        airPlane = GetComponent<Animator>();
        airPlane.enabled = false;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.position;
        transform.position = new Vector3(p.x, pos.y + Mathf.Sin(Time.time * speed) * moveY, p.z);

        if (isMove)
        {
            airPlane.enabled = true;
        }
    }
}
