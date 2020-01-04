using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    private NavMeshAgent navMA;
    private Transform player;
    private Transform enemy;
    private Animator animator;
    public float distance = 1.5f;

	void Start () {
	    navMA = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        enemy = this.GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Vector3.Distance(transform.position, player.position) < distance)
        {
            animator.SetBool("Move", false);
        }
        else
        {
            navMA.SetDestination(player.position);
            animator.SetBool("Move", true);
        }
	}
}
