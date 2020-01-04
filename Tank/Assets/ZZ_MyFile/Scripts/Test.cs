using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject TE_GameObject;
    public GameObject Enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.H))
        {
            GameObject.Instantiate(TE_GameObject, Vector3.up, Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Instantiate(Enemy, transform.position, Quaternion.identity);
        }
	}
}
