using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneSkill : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        GameObject.Destroy(this.gameObject, 5.5f);
	}
}
