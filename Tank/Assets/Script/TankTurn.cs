using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurn : MonoBehaviour {

    public float roationSpeed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        if (Mathf.Abs(h) > 0.5f)
        {
            Quaternion newRoation = Quaternion.LookRotation(new Vector3(h, 0, 0), Vector3.up);           
            transform.rotation = Quaternion.Lerp(transform.rotation, newRoation, Time.deltaTime * roationSpeed);
        }
	}
}
