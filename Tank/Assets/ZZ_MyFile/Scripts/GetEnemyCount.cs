using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetEnemyCount : MonoBehaviour {

    private GameController enemyCount;

	// Use this for initialization
	void Start () {
        enemyCount = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = "当前敌数：" + (enemyCount.enemyCount).ToString();
    }
}
