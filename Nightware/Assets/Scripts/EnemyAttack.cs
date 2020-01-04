using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    public int attack = 5;
    public float attackTime = 1;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = attackTime;
	}

    public void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player")
        {
            timer += Time.deltaTime;
            if (timer >= attackTime)
            {
                timer -= attackTime;
                coll.GetComponent<PlayerHP>().Hurt(attack);
            }
        }
    }
}
