using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {

    public GameObject enemy;
    public float time = 10;
    private float timer = 10;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer -= time;
            CreateEnemyFun();
        }
	}

    void CreateEnemyFun()
    {
        GameObject.Instantiate(enemy, transform.position, transform.rotation);
    }
}
