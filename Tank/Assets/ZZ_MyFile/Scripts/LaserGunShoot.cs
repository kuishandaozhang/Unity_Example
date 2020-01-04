using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunShoot : MonoBehaviour {

    public Transform player;
    private LineRenderer lineRenderer;
    public float timer = 5;
    private float time;
    public float lerpSpeed = 10;
    private Vector3 playerPos;
    public GameObject light;
    public GameObject attackRect;
    private bool isAttack = true;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        time = timer;
        playerPos = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30)); ;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        lineRenderer.SetPosition(0, transform.position);
        if (time > 1)       //追踪
        {
            if (player != null)
                playerPos = Vector3.Lerp(playerPos, player.position, Time.deltaTime);
            lineRenderer.SetPosition(1, playerPos);
        }
        else if(time <= 0)      //重置
        {
            time = timer;
            isAttack = true;
        }
        else if(time-1 <= 0 && isAttack)  //攻击
        {
            isAttack = false;
            lineRenderer.widthMultiplier = 3;
            light.SetActive(true);
            attackRect.SetActive(true);
            attackRect.transform.position = playerPos;
            Invoke("CloseEffects", 0.1f);
        }
        lineRenderer.widthMultiplier = Mathf.Lerp(lineRenderer.widthMultiplier, 0.1f, Time.deltaTime * lerpSpeed);
    }

    private void CloseEffects()
    {
        light.SetActive(false);
        attackRect.SetActive(false);
    }
}
