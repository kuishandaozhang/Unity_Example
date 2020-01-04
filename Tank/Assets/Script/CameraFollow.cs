using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset;
    private Transform player;
    // Use this for initialization

    private void Awake()
    {
        player = GameObject.Find("Tank").gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, 1f);
        //transform.position = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);
        //gameObject.transform.Translate(player.transform.position + offset);
    }
}
