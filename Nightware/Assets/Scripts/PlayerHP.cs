using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour {

    public int hp = 100;
    public float smoothing = 5;
    public AudioClip deathAudio;

    private AudioSource audioSource;
    private Animator anim;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;
    private SkinnedMeshRenderer bodyRenderer;
    private Transform cTransform;

	// Use this for initialization
	void Start () {
	    anim = this.GetComponent<Animator>();
        playerMove = this.GetComponent<PlayerMove>();
        playerShoot = this.GetComponentInChildren<PlayerShoot>();
        bodyRenderer = transform.FindChild("Player").gameObject.GetComponent<SkinnedMeshRenderer>();
        audioSource = this.GetComponent<AudioSource>();
        cTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
	}

    public void Hurt(int attack)
    {
        if (hp <= 0) return;
        bodyRenderer.material.color = Color.red;
        audioSource.Play();
        this.hp -= attack;
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(deathAudio, cTransform.position, 1f);
            anim.SetBool("Death", true);
            playerMove.enabled = false;
            playerShoot.enabled = false;
        }
    }
}
