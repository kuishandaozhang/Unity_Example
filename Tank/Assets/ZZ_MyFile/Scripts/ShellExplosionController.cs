using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Destroy(this.gameObject, 0.1f);  //播放完特效销毁
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
