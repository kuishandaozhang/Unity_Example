using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossHP : MonoBehaviour
{

    public float hp = 100;

    public bool isHurt = false;     //是否受到攻击
    private float hurtTimer = 1f;
    private float hurtTime = 1f;

    public MeshRenderer meshRenderer;
    private Color bodyColor;

    public GameObject BustedBoss;   //死亡模型

    void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        bodyColor = meshRenderer.materials[1].color;
    }

    void Update()
    {
        if (hp <= 0 || transform.position.y <= -3)
        {
            GameObject.Find("GameController").GetComponent<GameController>().bossIsDie = true;
            GameObject.Find("GameController").GetComponent<GameController>().enemyCount--;
            GameObject.Instantiate(BustedBoss, transform.position, Quaternion.identity);
            this.GetComponent<BossHP>().enabled = false;
            this.GetComponentInChildren<BossShoot>().enabled = false;
            this.transform.Find("ShellExplosion").gameObject.SetActive(false);
            GameObject.Find("ShowBossHP").SetActive(false);
            this.gameObject.SetActive(false);
        }
        if (isHurt && hurtTime > 0)
        {
            meshRenderer.materials[1].color = Color.Lerp(meshRenderer.materials[1].color, bodyColor, Time.deltaTime * 5); //被攻击时变红
        }
        else
        {
            isHurt = false;
            hurtTime = hurtTimer;
        }
    }
}
