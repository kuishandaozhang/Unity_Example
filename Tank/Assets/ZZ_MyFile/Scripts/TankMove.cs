using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour {

    public float MoveSpeed = 5f; //移动加成
    public float RunSpeed = 3f;  //加速加成
    public float RoateSpeed = 9;
    public bool flag = false;   //是否加速

    private Rigidbody rig;

    // Use this for initialization
    void Start()
    {
        rig = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取速度.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 nowvelocity = rig.velocity;

        if (Mathf.Abs(h) > 0.5f || Mathf.Abs(v) > 0.5f)
        {
            if (flag)
                this.rig.velocity = new Vector3(h * MoveSpeed * RunSpeed, nowvelocity.y, v * MoveSpeed * RunSpeed);
            else
                this.rig.velocity = new Vector3(h * MoveSpeed, nowvelocity.y, v * MoveSpeed);
            //transform.LookAt(new Vector3(h, 0, v) + gameObject.transform.position);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(h, 0, v), Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * RoateSpeed);
        }
    }
}
