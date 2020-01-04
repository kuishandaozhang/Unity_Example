using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private Rigidbody rigidbody;
    private Animator anim;
    private Transform player;

    public float speed = 1;

	// Use this for initialization
	void Start () {
        rigidbody = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        player = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //控制移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //播放动画
        if (h != 0 || v != 0)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }

        rigidbody.MovePosition(player.position + new Vector3(h, 0, v) * speed * Time.deltaTime);

        //控制方向
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            player.LookAt(hitInfo.point);
        }
	}
}
