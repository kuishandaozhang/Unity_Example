using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour {

    public float timer = 5;
    private float time;
    private bool isKeyDown = false;
    public KeyCode key = KeyCode.Space;
    public Shoot shoot = null;
    private GameObject player;

    private Slider slider;

	// Use this for initialization
	void Start () {
        time = timer;
        slider = GetComponent<Slider>();
        player = GameObject.Find("Tank");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key) && time == timer)
        {
            isKeyDown = true;

            if(shoot != null && key == KeyCode.E)
            {
                shoot.isAirplaneSkill = true;
            }
            else if (shoot != null && key == KeyCode.F)
            {
                shoot.isBigShellSkill = true;
            }
            else if(key == KeyCode.Space)
            {
                player.GetComponent<TankMove>().flag = true;
                Invoke("StopAccelerate", 3);
            }
        }
        if (isKeyDown)
        {
            time -= Time.deltaTime;
            slider.value = time / timer;
            if (time <= 0)
            {
                isKeyDown = false;
                time = timer;
            }
        }
	}

    private void StopAccelerate()
    {
        player.GetComponent<TankMove>().flag = false;
    }
}
