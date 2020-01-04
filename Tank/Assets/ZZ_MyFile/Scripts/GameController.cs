using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    public int addEnemyCount = 1;
    public int enemyCount = 0;      //当前enemy个数；
    public int maxEnemyCount = 32;  //场上最多能同时存在的最大enemy个数（不包括Boss）
    private bool isAddEnemy = true;
    public Transform[] enemyPoss;
    public GameObject Boss;
    public GameObject win;
    public GameObject laserGun;
    public bool bossIsDie = false;
    public GameObject enemyCountGO;
    public GameObject player;
    public float timer = 3;
    private float time;
    public GameObject isReadyAddEnemy;
    public GameObject playerHP_UI;
    public GameObject btnStart_UI;
    public GameObject skill_UI;
    public GameObject showBossHP_UI;
    public GameObject[] buildings;
    public GameObject btnReStart_UI;
    public GameObject shellParent;
    public GameObject enemyParent;
    public GameObject setPlayerHP_UI;

    public bool playerIsDie = false;
    private int remainEnemy = 0;

    // Use this for initialization
    void Start()
    {
        GameObject.Instantiate(shellParent);
        GameObject.Instantiate(enemyParent);
        enemyCountGO.SetActive(true);
        playerHP_UI.SetActive(true);
        isReadyAddEnemy.SetActive(true);
        player.SetActive(true);
        btnStart_UI.SetActive(false);
        skill_UI.SetActive(true);
        time = timer;
    }

    // Update is called once per frame
    void Update()
    {
        //管理员权限：
        if(Input.GetKey(KeyCode.Q) && Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.E))
        {
            Transform[] transfs = GameObject.Find("EnemyParent(Clone)").GetComponentsInChildren<Transform>();
            for (int i = 0; i < transfs.Length; i++)
            {
                if(transfs[i].GetComponent<HP>() != null)
                    transfs[i].GetComponent<HP>().hp = 0;
            }
        }
        if(time >= -1)
            time -= Time.deltaTime;
        if (isAddEnemy && addEnemyCount <= maxEnemyCount)
        {
            isAddEnemy = false;
            Invoke("AddEnemy", 2.9f);
        }
        if (enemyCount == remainEnemy && time <= 0 && addEnemyCount <= maxEnemyCount) //生成敌人倒计时
        {
            isReadyAddEnemy.SetActive(true);
            isAddEnemy = true;
            time = timer;
        }

        //失败；
        if (playerIsDie)
        {
            GameObject.Destroy(GameObject.Find("EnemyParent(Clone)"));
            Boss.GetComponentInChildren<BossShoot>().enabled = false;
            playerIsDie = false;
            GameObject.Destroy(GameObject.Find("ShellParent(Clone)"));
            laserGun.SetActive(false);
            enemyCountGO.SetActive(false);
            Boss.transform.Find("ShellExplosion").gameObject.SetActive(false);
            skill_UI.SetActive(false);
            btnReStart_UI.SetActive(true);
        }
        //Win;
        else if(enemyCount == 0 && bossIsDie)
        {
            win.SetActive(true);
            GameObject.Destroy(GameObject.Find("ShellParent(Clone)"));
            GameObject.Destroy(GameObject.Find("EnemyParent(Clone)"));
            laserGun.SetActive(false);
            enemyCountGO.SetActive(false);
            player.SetActive(false);
            skill_UI.SetActive(false);
            btnReStart_UI.SetActive(true);
        }
    }

    private void AddEnemy()
    {
        isAddEnemy = false;
        for (int i = 0; i < addEnemyCount; i++)
        {
            
            GameObject enemyGo = GameObject.Instantiate(Enemy, enemyPoss[i].position, transform.rotation);
            enemyGo.transform.SetParent(GameObject.Find("EnemyParent(Clone)").transform);
        }
        enemyCount += addEnemyCount;
        if (addEnemyCount == maxEnemyCount)  //Boss
        {
            Boss.tag = "Boss";
            Boss.GetComponent<BossHP>().enabled = true;
            Boss.GetComponentInChildren<BossShoot>().enabled = true;
            Boss.transform.Find("ShellExplosion").gameObject.SetActive(true);
            showBossHP_UI.SetActive(true);
            enemyCount++;
        }
        if (addEnemyCount == 4)  //炮台
        {
            laserGun.SetActive(true);
            laserGun.GetComponentInParent<HP>().enabled = true;
            enemyCount++;
            remainEnemy++;
        }
        addEnemyCount *= 2;    //每下一次敌人翻倍，最高32；
    }
    /// <summary>
    /// 重新开始游戏
    /// </summary>
    public void ReStart()
    {   //tank. buildings. boss. lasergunparent. shellparent. enemyparent.
        GameObject.Instantiate(shellParent);
        GameObject.Instantiate(enemyParent);
        player.SetActive(true);
        player.GetComponent<HP>().hp = 100;
        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].SetActive(true);
        }
        Boss.SetActive(true);
        Boss.GetComponent<MeshRenderer>().materials[1].color = Color.white;
        laserGun.transform.parent.gameObject.SetActive(true);

        //gameUI
        btnReStart_UI.SetActive(false);
        enemyCountGO.SetActive(true);
        playerHP_UI.SetActive(true);
        skill_UI.SetActive(true);
        isReadyAddEnemy.SetActive(true);
        win.SetActive(false);
        Boss.GetComponent<BossHP>().hp = 1000;
        Boss.GetComponent<BossHP>().enabled = false;
        Boss.tag = "Building";
        showBossHP_UI.SetActive(false);

        setPlayerHP_UI.GetComponent<Text>().text = "我的HP：0";
        setPlayerHP_UI.GetComponent<RectTransform>().localPosition = new Vector3(354.3f, 367);
        setPlayerHP_UI.GetComponent<RectTransform>().sizeDelta = new Vector2(216.39f, 48.5f);
        setPlayerHP_UI.GetComponent<Text>().fontSize = 20;

        //其他标志位
        addEnemyCount = 1;
        enemyCount = 0;
        isAddEnemy = true;
        bossIsDie = false;
        playerIsDie = false;
        remainEnemy = 0;
        time = timer;

        //tank回到起始位置
        player.transform.position = new Vector3(0.78f, 0, -38.17f);
    }
}
