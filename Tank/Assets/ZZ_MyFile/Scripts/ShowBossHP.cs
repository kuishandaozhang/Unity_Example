using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBossHP : MonoBehaviour {

    public BossHP bossHP;
    private float bossHPTatal;
    private Text text;
    public Slider showBossHP_UI;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        bossHPTatal = bossHP.hp;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = bossHP.hp.ToString() + "/1000";
        showBossHP_UI.value = bossHP.hp / bossHPTatal;
	}
}
