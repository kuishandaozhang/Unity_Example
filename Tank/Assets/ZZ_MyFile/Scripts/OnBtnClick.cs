using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBtnClick : MonoBehaviour {

    public GameObject gameController;

	public void OnBtnStartClick()
    {
        gameController.SetActive(true);
    }
    public void OnBtnReStartClick()
    {
        gameController.GetComponent<GameController>().ReStart();
    }
}
