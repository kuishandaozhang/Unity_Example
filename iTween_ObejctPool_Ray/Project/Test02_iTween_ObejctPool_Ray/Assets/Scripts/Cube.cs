using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// [脚本] 该脚本用于控制Cube的动画播放
/// </summary>
public class Cube : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// 移动到指定位置
    /// </summary>
    /// <param name="targetPos">目标位置：目的地</param>
    public void Move(Vector3 targetPos)
    {
        //开启协程 [MoveIE()]
        StartCoroutine(MoveIE(targetPos));
    }
    IEnumerator MoveIE(Vector3 targetPos)
    {
        //先将物体的缩放调整为（0， 0， 0）,在下面缩放动画中恢复至原样
        transform.localScale = Vector3.zero;
        //缩放 [iTween插件] [ScaleTo缩放至] 传入3个参数：1.对哪个物体进行操作 2.变化的最终值 3.变化到最终值的时间
        // [gameObject]: 这个对应该脚本挂载的物体（Cube）  结果：将gameObject在0.3秒里放大到(1, 1, 0.2f)
        iTween.ScaleTo(gameObject, new Vector3(1, 1, 0.2f), 0.3f);
        //移动 [MoveTo移动至] 同上
        // [targetPos]: 后面的时候有很多Cube，每个Cube的 [targetPos目标位置] 不同，所以以传参数的方式实现移动到不同的位置上
        iTween.MoveTo(gameObject, targetPos, 0.3f);
        yield return new WaitForSeconds(0.3f);//等待0.3秒
        //旋转 [RotateTo旋转至] 同上
        iTween.RotateTo(gameObject, new Vector3(0, -180, 0), 1f);
    }
    /// <summary>
    /// 回收的动画
    /// </summary>
    public void Recovery()
    {
        //将该物体从CubeList列表里移除
        GameController.instance.cubeList.Remove(this);
        //开启协程 [RecoveryIE()]
        StartCoroutine(RecoveryIE());
    }
    IEnumerator RecoveryIE()
    {
        //缩放
        iTween.ScaleTo(gameObject, new Vector3(1.2f, 1.2f, 0.2f), 0.3f);
        yield return new WaitForSeconds(0.3f);
        //移动
        iTween.MoveTo(gameObject, Vector3.zero, 0.3f);
        //旋转
        iTween.ScaleTo(gameObject, Vector3.zero, 0.3f);
        yield return new WaitForSeconds(0.3f);
        //Destroy(gameObject);//回收的动画结束后删除该物体
        ObjectPool.GetInstance().RecycleObj(gameObject);
    }
}
