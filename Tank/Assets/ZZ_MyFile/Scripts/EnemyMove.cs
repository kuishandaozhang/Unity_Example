using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   //导航需引入此空间

/// <summary>
/// 控制敌人移动与攻击
/// </summary>
public class EnemyMove : MonoBehaviour {

    private NavMeshAgent navMA;
    private Transform player;
    private Transform enemy;

    private float timer = 3;        //时间控制器
    private float time = 6;
    private bool isShoot = false;   //射击时刻

    public Transform shootPos;      //从该位置发射炮弹
    public GameObject shell;        //炮弹

    void Start()
    {
        navMA = this.GetComponent<NavMeshAgent>();
        enemy = this.GetComponent<Transform>();
        player = GameObject.Find("Tank").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //活跃周期
        if (time >= timer)    //移动
        {
            navMA.SetDestination(player.position);  //追杀主角
            isShoot = true;
        }
        else if(isShoot && time <= timer)      //停止并射击
        {
            navMA.enabled = false;
            GameObject.Instantiate(shell, shootPos.position, shootPos.rotation);
            isShoot = false;
        }
        else if(time < 0)               //休眠期
        {
            navMA.enabled = true;
            time = 2*timer;
        }
        time -= Time.deltaTime;
    }
}
