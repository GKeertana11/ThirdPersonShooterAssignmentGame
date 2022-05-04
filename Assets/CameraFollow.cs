using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 newtrans;
    // Start is called before the first frame update
    void Start()
    {

        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        offset.z = transform.position.y - player.transform.position.z;
        newtrans = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        newtrans.x = player.transform.position.x + offset.x;
        newtrans.y = player.transform.position.y + offset.y;
        newtrans.z = player.transform.position.y + offset.z;
        transform.position = newtrans;
    }
}
