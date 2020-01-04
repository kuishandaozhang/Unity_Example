using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject shell;
    public GameObject airplaneSkill;
    public GameObject bigShellSkill;

    public bool isAirplaneSkill = false;
    public bool isBigShellSkill = false;

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Instantiate(shell, this.transform.position, transform.rotation);
        }
        if(isAirplaneSkill)
        {
            GameObject.Instantiate(airplaneSkill, this.transform.position, transform.rotation);
            isAirplaneSkill = false;
        }
        if(isBigShellSkill)
        {
            GameObject.Instantiate(bigShellSkill, this.transform.position + transform.forward, transform.rotation);
            isBigShellSkill = false;
        }
		
	}
}
