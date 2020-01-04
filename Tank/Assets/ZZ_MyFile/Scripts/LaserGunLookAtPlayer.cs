using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunLookAtPlayer : MonoBehaviour
{
    private Transform player;
    public float timer = 5;
    private float time;
    private Vector3 playerPos;

    // Use this for initialization
    void Start()
    {
        time = timer;
        player = GameObject.Find("Tank").transform;
        playerPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time > 1)
        {
            if (player != null)
                playerPos = Vector3.Lerp(playerPos, player.position, Time.deltaTime);
            transform.LookAt(playerPos);
        }
        else if(time <= 0)
            time = timer;
    }
}
