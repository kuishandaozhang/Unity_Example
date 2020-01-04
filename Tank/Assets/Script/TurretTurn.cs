using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTurn : MonoBehaviour {
   
    public Transform Turret;
    public GameObject bulletPrefab;
    public float timer = 1;
    public float targetTime = 1;
    private int groundLayerIndex = -1;
    // Use this for initialization
    void Awake()
    {
        groundLayerIndex = LayerMask.GetMask("Goround");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,200,groundLayerIndex))
        {
            Vector3 target = hit.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(timer > targetTime)
            {
                timer = 0;
               Shoot();

            }
        }
	}


    private void Shoot()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, Turret.position, Quaternion.identity);
        Ray ray = new Ray(Turret.position,Turret.forward);
        RaycastHit hit;
      
        if(Physics.Raycast(ray,out hit,200))
        {
          
           
            var target = hit.point;
            target.y = Turret.position.y;
          
            bullet.GetComponent<Bullet>().SetTarget(target);
            
        }
       
    }
}
