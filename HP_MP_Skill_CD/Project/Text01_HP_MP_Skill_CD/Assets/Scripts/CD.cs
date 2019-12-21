using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 该脚本处理技能冷却，处理技能是否可以使用
/// </summary>
public class CD : MonoBehaviour
{

    private Image cd_Img;//[图片]: 与技能图片相同，当技能被禁用时，实现恢复的过程
    private Button btn;//[技能按钮]：控制按钮禁用和启用
    private Text mp_Text;//技能需要消耗的蓝量

    public float cdTimer = 3;//技能冷却时间,可根据情况修改
    private float cdTime;//技能当前还剩的冷却时间

    private bool isCD = false;//当前技能是否为冷却状态

    public bool btnType = true;//用于确定是哪个按钮 true:加血 false：受伤


    void Start()
    {
        //获取对应的引用
        cd_Img = GetComponent<Image>();
        btn = transform.parent.GetComponent<Button>();
    }

    void Update()
    {
        if (isCD)//当技能需要冷却时，实现冷却效果
        {
            cdTime += Time.deltaTime;//已经冷却的时间,当增加到 [cdTimer] 时，冷却结束，恢复技能使用
            cd_Img.fillAmount = cdTime / cdTimer;//实时显示冷却进度
            if (cd_Img.fillAmount >= 1) //冷却结束，恢复技能使用； [cd_Img.fillAmount] 的范围：0~1
            {
                cd_Img.fillAmount = 0;//隐藏实现冷却效果的图片
                btn.interactable = true;//启用按钮（技能）
                isCD = false;//冷却结束
            }
        }
    }
    /// <summary>
    /// 进入冷却状态
    /// </summary>
    public void OnCD()
    {
        cdTime = 0;//已经冷却的时间重置为0
        btn.interactable = false;//禁用按钮（技能）
        isCD = true;//标志为冷却状态
    }
}
