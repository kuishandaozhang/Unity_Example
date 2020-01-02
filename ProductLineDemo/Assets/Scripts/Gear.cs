using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 齿轮
/// </summary>
public class Gear : MonoBehaviour {

    private float speed = 150;

	void Update () {
        transform.Rotate(new Vector3(speed, 0, 0) * Time.deltaTime);
	}
}
