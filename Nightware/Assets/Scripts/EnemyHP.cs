using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

    public int HP = 100;

    private Animator animator;
    private NavMeshAgent navMA;
    private CapsuleCollider capsuleCollider;
    private EnemyMove move;
    private EnemyAttack attack;
    private AudioSource audioSource;
    private Transform cTransform;
    private ParticleSystem particleSystem;
    public AudioClip DeathAudio;

	void Start () {
        animator = this.GetComponent<Animator>();
        navMA = this.GetComponent<NavMeshAgent>();
        capsuleCollider = this.GetComponent<CapsuleCollider>();
        move = this.GetComponent<EnemyMove>();
        attack = this.GetComponent<EnemyAttack>();
        audioSource = this.GetComponent<AudioSource>();
        cTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Hurt(int hurt, Vector3 hitPoint)
    {
        if (HP <= 0) return;
        audioSource.Play();
        particleSystem.transform.position = hitPoint;
        particleSystem.Play(); 
        HP -= hurt;
        if (HP <= 0)
        {
            Death();   
        }
    }

    void Death()
    {
        AudioSource.PlayClipAtPoint(DeathAudio, cTransform.position, 1f);
        move.enabled = false;
        attack.enabled = false;
        navMA.enabled = false;
        animator.SetBool("Death", true);
        capsuleCollider.enabled = false;
        GameObject.Destroy(this.gameObject, 1.2f);
    }
}
