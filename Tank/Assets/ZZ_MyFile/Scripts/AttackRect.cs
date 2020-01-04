using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRect : MonoBehaviour {

    public float attack = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Building")
        {
            Debug.Log("building");
            GameObject.Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<HP>().isHurt = true;
            col.gameObject.GetComponent<HP>().meshRenderer.materials[0].color = Color.red;
            col.gameObject.GetComponent<HP>().hp -= attack;
        }
    }
}
