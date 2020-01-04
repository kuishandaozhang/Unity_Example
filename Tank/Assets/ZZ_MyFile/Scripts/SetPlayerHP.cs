using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerHP : MonoBehaviour {

    public HP playerHP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = "我的HP：" + (playerHP.hp).ToString();
        if(playerHP.hp <= 0)
        {
            GameObject.Find("GameController").GetComponent<GameController>().playerIsDie = true;
            Text text = this.gameObject.GetComponent<Text>();
            text.text = "You are die!";
            this.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 135);
            text.fontSize = 80;
            //this.enabled = false;
        }
    }
}
