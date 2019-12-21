using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用射线检测/选中Cube
/// </summary>
public class RaySelect : MonoBehaviour {

    private GameObject curSelectCube;//当前选中的Cube

	void Start () {
        curSelectCube = null;//初始值为 [null 空]
    }
	
	void Update () {
        // 射线检测
        // [Ray射线] ray = [Camera摄像机].[main主要的].[ScreenPointToRay从屏幕中的一点发射射线]([Input输入].[mousePosition鼠标位置]);
        // 从主摄像机的屏幕中，以鼠标的位置为起点，向世界发射一条射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;//存取射线 [碰撞检测] 后的信息
        if (Physics.Raycast(ray, out hit))// [Physics物理].[Raycast射线投射](ray, out hit): 当射线检测到物体时，将获取到的信息存储到 [hit] 里
        {
            if (curSelectCube != hit.collider.gameObject)//当 [当前选中的物体] 不等于 [当前检测到的物体] 时
            {
                if(curSelectCube != null && curSelectCube.tag == "Cube")// [tag标签]: 区分不同物体的标记
                    CancelSelectCube();//选中状态-->非选中状态
                curSelectCube = hit.collider.gameObject;//将目标物体切换成鼠标指向的物体
                if (hit.collider.tag == "Cube")
                    SelectCube();//非选中状态-->选中状态
            }
            if (Input.GetMouseButtonDown(0) && curSelectCube.tag == "Cube")//点击Cube后将Cube回收
            {
                Cube c = curSelectCube.GetComponent<Cube>();//获取引用
                c.Recovery();//回收
            }
        }
	}
    /// <summary>
    /// [动画] 选中Cube立方体
    /// </summary>
    private void SelectCube()
    {
        //缩放 略微放大
        iTween.ScaleTo(curSelectCube, new Vector3(1.2f, 1.2f, 0.2f), 0.3f);
    }
    /// <summary>
    /// [动画] 取消选中Cube立方体
    /// </summary>
    private void CancelSelectCube()
    {
        //缩放 恢复原始大小
        iTween.ScaleTo(curSelectCube, new Vector3(1, 1, 0.2f), 0.3f);
    }
}
