using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [生产中心] 负责生产Product产品
/// </summary>
public class Creater : MonoBehaviour {

    private Transform createPoint;          //生成Product的位置

    void Start () {
        createPoint = transform.Find("CreatePoint");
	}

    /// <summary>
    /// 生产Product产品
    /// </summary>
    /// <param name="i">0:红 1:蓝</param>
    public void CreaterProduct(int i)
    {
        GameObject  productPrefab;
        if (i == 0) productPrefab = ObjectPool.GetInstance().GetObj("Product_Red");
        else        productPrefab = ObjectPool.GetInstance().GetObj("Product_Blue");
                    productPrefab.GetComponent<Product>().Init(createPoint);
    }
}
