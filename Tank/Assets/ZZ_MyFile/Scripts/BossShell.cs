using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShell : MonoBehaviour
{

    public float speed = 1f;
    public float attack = 20;
    private Transform player;
    //public float force = 100;

    private Rigidbody rigidbody_k;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Tank").GetComponent<Transform>();
        transform.SetParent(GameObject.Find("ShellParent(Clone)").transform);
        rigidbody_k = this.gameObject.GetComponent<Rigidbody>();
        //GameObject.Instantiate(ShellExplosion, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody_k.MovePosition(transform.position + transform.forward * speed);
        //rigidbody_k.AddForce(Vector3.up * force, ForceMode.Impulse);
        //transform.Translate(Vector3.forward * speed, Space.Self);
        if(transform.position.y >= 60)
        {
            transform.position = new Vector3(player.position.x + Random.Range(-5, 5), transform.position.y - 10, player.position.z + Random.Range(-5, 5));
            transform.Rotate(Vector3.right, 180);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "plane" || col.gameObject.tag == "Boss" || col.gameObject.tag == "Wall")   //只有撞到地板或Boss才会销毁
        {
            GameObject.Destroy(this.gameObject);    //自毁
        }
        else if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<HP>().isHurt = true;
            col.gameObject.GetComponent<HP>().meshRenderer.materials[0].color = Color.red;
            col.gameObject.GetComponent<HP>().hp -= attack;
        }
        else if(col.gameObject.tag == "LaserGun")
        {
            col.gameObject.GetComponent<HP>().hp -= attack;
        }
        else if (col.gameObject.tag == "Building")  //销毁物体；
        {
            col.gameObject.SetActive(false);
        }
    }
}
