using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HP : MonoBehaviour {

    public float hp = 3;

    public bool isHurt = false;     //是否受到攻击
    private float hurtTimer = 1f;
    private float hurtTime = 1f;

    public MeshRenderer meshRenderer = null;
    private Color bodyColor;

    public GameObject BustedTank;   //死亡模型
    private Transform enemyParent;
    public GameObject laserGun = null;

    void Start()
    {
        if(this.gameObject.tag != "LaserGun")
            bodyColor = meshRenderer.materials[0].color;
        enemyParent = GameObject.Find("EnemyParent(Clone)").GetComponent<Transform>();
    }

	void Update () {
		if(hp <= 0 || transform.position.y <= -3)
        {
            if(this.gameObject.tag == "Enemy" || this.gameObject.tag == "LaserGun")
                GameObject.Find("GameController").GetComponent<GameController>().enemyCount--;
            GameObject go = GameObject.Instantiate(BustedTank, transform.position, Quaternion.identity);
            go.transform.SetParent(enemyParent);
            if (this.gameObject.tag == "Player")
                this.gameObject.SetActive(false);
            else if(this.gameObject.tag == "LaserGun")
            {
                laserGun.SetActive(false);
                hp = 1;
                this.GetComponent<HP>().enabled = false;
                this.gameObject.SetActive(false);
            }
            else
                GameObject.Destroy(this.gameObject);
        }
        if(isHurt && hurtTime > 0)
        {
            meshRenderer.materials[0].color = Color.Lerp(meshRenderer.materials[0].color, bodyColor, Time.deltaTime*5); //被攻击时变红
        }
        else
        {
            isHurt = false;
            hurtTime = hurtTimer;
        }
	}
}
