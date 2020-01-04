using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Vector3 target;
    public GameObject effective;
	// Use this for initialization
	public void SetTarget(Vector3 _target)
    {
       
        target = _target;
    }
    void Update()
    {
        if (target == null) return;
        transform.LookAt(target);        
        transform.Translate(Vector3.forward* Time.deltaTime*5);      
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag!="Player")
        {
            GameObject effect = GameObject.Instantiate(effective, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(effect, 1);
        }
        
    }
}
