using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// [脚本] 游戏控制器 控制游戏主要逻辑
/// </summary>
public class GameController : MonoBehaviour
{
    #region 单例
    public static GameController instance;
    #endregion

    private int[,] validPos;//记录有效/无效的位置
    public GameObject cube_Prefab;// [预制体] Cube立方体

    private const float rightTop_X = 7.7f;//右上角的X值
    private const float rightTop_Y = 3.7f;//右上角的Y值

    public List<Cube> cubeList;//存放Cube [List列表<Cube存放的数据类型>] 类似数组，但比数组好用,功能更多

    private GameObject btnObject;//Button按钮物体
    private Text text_UI;

    /// <summary>
    /// [Unity内置函数] 用于初始化/获取引用
    /// </summary>
    void Start()
    {
        #region 单例
        instance = this;
        #endregion

        validPos = new int[,]//1：有方块的地方；0：无方块
           {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
           };
        cubeList = new List<Cube>();

        // [GameObject.Find("Canvas/Button")] 与 [Transform.Find()] 类似，
        // 都是查找物体常用的方法,他们的区别在于:
        // 1.前者获取到的是 [GameObject物体的引用]；后者是获取对应物体的 [Transform组件]（也就是返回值不同）
        // 2.他们查找物体的起点不同：前者是最外层的物体；后者是从该脚本挂载的物体上开始查找
        btnObject = GameObject.Find("Canvas/Button");//获取引用
        text_UI = GameObject.Find("Canvas/Button/Text").GetComponent<Text>();
    }
    /// <summary>
    /// [Unity内置函数] 用于实时变化/检测
    /// </summary>
    void Update()
    {
    }
    /// <summary>
    /// [重载] 重新排布物体
    /// </summary>
    public void ReLoad()
    {
        btnObject.SetActive(false);//设置物体为非激活状态：相当于禁用按钮
        text_UI.text = "重载";//这个其实只需修改一次就行了，不过目前来说不影响
        //开启协程CreateCubesWaitAFewSeconds()
        StartCoroutine(CreateCubesWaitAFewSeconds());
    }
    /// <summary>
    /// 生成所有物体，每个物体生成之间隔0.几秒
    /// </summary>
    IEnumerator CreateCubesWaitAFewSeconds()
    {
        //清场 当场景物体非空时清场
        if (cubeList.Count > 0)
        {
            for (int i = cubeList.Count - 1; i >= 0; i--)
            {
                cubeList[i].Recovery();
            }
            //cubeList.Clear();//清空list列表
            yield return new WaitForSeconds(1f);
        }
        //排布 [validPos.GetLength(0)] 行 [validPos.GetLength(1)] 列: 7行12列
        for (int i = 0; i < validPos.GetLength(0); i++)
        {
            for (int j = 0; j < validPos.GetLength(1); j++)
            {
                if (validPos[i, j] == 0)//为0时该位置留空，不生成方块
                    continue;// [continue继续]：结束本次循环 结果：
                //生成Cube立方体
                //Instantiate[实例化:生成](cube_Prefab[Cube预制体], Vector3.zero[生成物体的位置], Quaternion.identity[无旋转])
                //Cube c = Instantiate(cube_Prefab, Vector3.zero, Quaternion.identity).GetComponent<Cube>();//实例化物体并获取该物体上的Cube脚本
                Cube c = ObjectPool.GetInstance().GetObj("Cube").GetComponent<Cube>();
                float c_Pos_X = -rightTop_X + (2 * rightTop_X / (validPos.GetLength(1) - 1)) * j;//计算目标位置的X值
                float c_Pos_Y = -rightTop_Y + (2 * rightTop_Y / (validPos.GetLength(0) - 1)) * i;//计算目标位置的Y值
                Vector3 c_Pos = new Vector3(c_Pos_X, c_Pos_Y, 0);//目标值
                c.Move(c_Pos);//传入目标位置，播放动画
                cubeList.Add(c);//将Cube添加到list列表里
                yield return new WaitForSeconds(0.1f);//等待0.1秒
            }
        }

        btnObject.SetActive(true);//激活物体：相当于启用按钮
    }
}
