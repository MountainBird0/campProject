using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 15.0f;
    public GameObject target;
    private Vector3 movePos;

    private void Start()
    {
        // 플레이어 찾아서 넣기
    }

    private void Update()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            movePos = new Vector3(target.transform.position.x, target.transform.position.y, -10);
            this.transform.position = Vector3.Lerp(this.transform.position, movePos, speed * Time.deltaTime);
        }
    }
}
