using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour {

    public GameObject bossShell;

    public float timer = 3;
    private float time;

	// Use this for initialization
	void Start () {
        time = timer;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            GameObject.Instantiate(bossShell, transform.position, transform.rotation);
            time = timer;
        }
	}
}
