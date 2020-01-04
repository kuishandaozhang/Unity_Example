using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShellSkill : MonoBehaviour
{

    public float speed = 1f;
    public float attack = 20;

    private Rigidbody rigidbody_k;

    // Use this for initialization
    void Start()
    {
        transform.SetParent(GameObject.Find("ShellParent(Clone)").transform);
        rigidbody_k = this.gameObject.GetComponent<Rigidbody>();
        //GameObject.Instantiate(ShellExplosion, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody_k.MovePosition(transform.position + transform.forward * speed);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<HP>().isHurt = true;
            col.gameObject.GetComponent<HP>().meshRenderer.materials[0].color = Color.red;
            col.gameObject.GetComponent<HP>().hp -= attack;
        }
        else if (col.gameObject.tag == "Boss")
        {
            col.gameObject.GetComponent<BossHP>().isHurt = true;
            col.gameObject.GetComponent<BossHP>().meshRenderer.materials[1].color = Color.red;
            col.gameObject.GetComponent<BossHP>().hp -= attack;
        }
        if (col.gameObject.tag == "Shell")
        {
            GameObject.Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Building" || col.gameObject.tag == "Boss" || col.gameObject.tag == "BigShellSkill" || col.gameObject.tag == "Wall")   //只有撞到场景物体或Boss才会销毁
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
