using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustedTank : MonoBehaviour {

    private GameObject TankExplosion;

    // Use this for initialization
    void Start () {
        TankExplosion = transform.Find("TankExplosion").gameObject;
        TankExplosion.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject.Destroy(this.gameObject, 5);
	}
}
