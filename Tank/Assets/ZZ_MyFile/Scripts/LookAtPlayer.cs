using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    private Transform player;
    public Transform TankTurret;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Tank").transform;

    }
	
	// Update is called once per frame
	void Update () {
        TankTurret.LookAt(player.position);
    }
}
