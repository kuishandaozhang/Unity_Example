using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{

    public float position_Y;

    // Use this for initialization
    void Start()
    {
        position_Y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        transform.LookAt(new Vector3(hit.point.x, position_Y, hit.point.z));
    }
}
