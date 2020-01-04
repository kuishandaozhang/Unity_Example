using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isReadyAddEnemy : MonoBehaviour {

    private float time = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time >= 2)
        {
            this.gameObject.GetComponent<Text>().text = (3).ToString();
        }
        else if (time >= 1)
        {
            this.gameObject.GetComponent<Text>().text = (2).ToString();
        }
        else if (time >= 0)
        {
            this.gameObject.GetComponent<Text>().text = (1).ToString();
        }
        else
        {
            time = 3;
            this.gameObject.SetActive(false);
        }
    }
}
