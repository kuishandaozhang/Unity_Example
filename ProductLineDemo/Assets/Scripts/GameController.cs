using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// [生产线控制中心] 游戏控制中心
/// </summary>
public class GameController : MonoBehaviour {

    public float timer = 3;     //2秒一个产品
    private bool isPick = false;//开始抓取
    public bool isProductMove = false;

    private Creater creater;    //获取[生产中心]脚本
    private Hand hand;

    //test
    private float time = 0;
    private int productCount = 0;

	void Start () {
        creater = GameObject.Find("Creater").GetComponent<Creater>();
        hand = transform.parent.GetComponent<Hand>();
        InvokeRepeating("CreateProduct", 1, timer);
	}

    private void Update()
    {
        if (hand.isReady)//抓手准备就绪
        {
            Ray ray = new Ray(transform.position, -transform.up * 4);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Product")
                {
                    if (!isPick)
                    {
                        CancelInvoke();
                        isPick = true;
                    }
                    hand.Work();
                }
            }
        }

        //test
        time += Time.deltaTime;
        //Debug.Log("时间：" + (int)time + "\n产品数：" + productCount);
    }

    public void NextProduct()
    {
        if(isPick)//从第二次准备就绪开始
        {
            CreateProduct();
        }
    }

    private void CreateProduct()
    {
        //得到0或1
        int i = Random.Range(0, 2);
        creater.CreaterProduct(i);
        Invoke("ProductMove", 1);
        productCount++;
    }

    private void ProductMove()
    {
        isProductMove = true;
    }
}
