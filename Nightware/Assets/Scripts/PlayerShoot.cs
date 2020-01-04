using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public float shootRate = 2;
    public int attack = 30;
    private float timer = 0;
    private ParticleSystem particleSystem;
    private LineRenderer lineRenderer;
    private AudioSource shootAudio;
    private EnemyHP enemyHP;

    private Light light;

	// Use this for initialization
	void Start () {
	    light = this.GetComponent<Light>();
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
        lineRenderer = this.GetComponent<LineRenderer>();
        shootAudio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1 / shootRate)
        {
            timer -= 1 / shootRate;
            Shoot();
        }
	}

    void Shoot()
    {
        light.enabled = true;
        particleSystem.Play();
        this.lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            lineRenderer.SetPosition(1, hitInfo.point);
            //射击敌人.
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.GetComponent<EnemyHP>().Hurt(attack, hitInfo.point);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }
        shootAudio.Play();

        

        Invoke("ClearEffect", 0.05f);
    }

    void ClearEffect()
    {
        light.enabled = false;
        lineRenderer.enabled = false;
    }
}
