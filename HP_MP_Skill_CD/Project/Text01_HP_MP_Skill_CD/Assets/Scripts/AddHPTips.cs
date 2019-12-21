using System.Collections;//~: 波浪号表示暂时不需要了解
using System.Collections.Generic;//~
using UnityEngine;//~
using UnityEngine.UI;//[命名空间]： 也叫 [名称空间]: 这里添加 [UnityEngine.UI命名空间]; 获取场景 [UI] 的引用时需要引入 [UnityEngine.UI命名空间]
/// <summary>
/// 该脚本处理HP数值变化
/// </summary>
public class AddHPTips : MonoBehaviour
{

    private RectTransform rectTran;//[RectTransform组件]：用于修改位置信息
    private Text text;//[文字组件]：显示文字，这里显示数值
    private Vector2 rectTranPos;//用于临时存储位置信息，然后传递给 [rectTran]

    void Start()
    {
        //获取对应引用
        rectTran = GetComponent<RectTransform>();
        text = GetComponent<Text>();
        rectTranPos = new Vector2(0, 65);//初始化位置  65: 测试得出

        gameObject.SetActive(false);//一开始 [隐藏提示]
    }

    void Update()
    {
        //用插值运算实现数字向上飘的效果
        rectTranPos.y = rectTran.anchoredPosition.y;
        rectTranPos.y = Mathf.Lerp(rectTranPos.y, 80, 3 * Time.deltaTime);//x坐标不变，y坐标从65变化至80
        rectTran.anchoredPosition = rectTranPos;
        if (Mathf.Abs(80 - rectTranPos.y) <= 0.002f)//[我们需要的值] 很接近[目标值] 时, 这里取0.002  [Mathf.Abs]: 绝对值
        {
            gameObject.SetActive(false);//隐藏提示
        }
    }
    /// <summary>
    /// 初始化位置
    /// </summary>
    /// <param name="posX">提示开始的位置</param>
    /// <param name="value">数值</param>
    /// <param name="isAdd">是否为增加</param>
    public void Init(float posX, float value, bool isAdd)
    {
        rectTranPos = new Vector2(posX, 65);//提示的位置
        rectTran.anchoredPosition = rectTranPos;//提示的位置设置为血量或蓝量的当前值上方
        if (isAdd)//加
        {
            text.text = "+" + value;
        }
        else//减
        {
            text.text = "-" + value;
        }
    }
}
