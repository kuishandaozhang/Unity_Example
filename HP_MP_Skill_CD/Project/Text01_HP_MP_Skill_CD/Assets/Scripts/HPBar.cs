using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    private Image preHP;
    private Image hp;
    private Text hpValue;

    private float totalHP = 100;//总的血量
    private float curHP = 100;//当前剩余的血量

    private bool isHurt = false;  //是否受到伤害

    private AddHPTips addHPTips;//[脚本]: 用于改变并显示HP每次的变化数值

    // Use this for initialization
    void Start () {
        preHP = transform.Find("PreHP").GetComponent<Image>();
        hp = transform.Find("HP").GetComponent<Image>();
        hpValue = transform.Find("HPValue").GetComponent<Text>();

        addHPTips = transform.Find("HP/AddHPTips").GetComponent<AddHPTips>();//获取引用，同上
    }

    // Update is called once per frame
    void Update () {
        if (isHurt)//受到攻击时执行, 触发条件在 [Hurt(int hurtValue)] 里
        {
            //[Lerp插值运算]: 从一个值(我们需要的值)变化到另一个值(目标值)，越接近目标值，变化越慢; 这里实现 [伤害变化过程]
            preHP.fillAmount = Mathf.Lerp(preHP.fillAmount, (float)curHP / totalHP, 4 * Time.deltaTime);
            if (preHP.fillAmount - (float)curHP / totalHP <= 0.001f)//[我们需要的值] 很接近 [目标值] 时, 这里取0.001
                isHurt = false;//[false]: 变为false后不再执行这段代码
        }
    }
    /// <summary>
    /// [技能] 受伤，模拟受到攻击
    /// </summary>
    public void Hurt()
    {
        //血量变化提示
        float tipsPos = (curHP / totalHP) * 431;//确定位置 [431]: 血条的宽度为431像素
        addHPTips.Init(tipsPos, 30, false);//修改位置 提示扣除30血量
        addHPTips.gameObject.SetActive(true);//启用提示

        //修改血条，修改血量数值
        curHP -= 30;//假设每次扣除30血量
        if (curHP < 0) curHP = 0;//避免出现负值
        hp.fillAmount = (float)curHP / totalHP;//修改血条显示
        hpValue.text = curHP + " / 100";//修改血量数值显示
        StartCoroutine(PreHPWaite());//开启协程[PreHPWaite()];
    }
    IEnumerator PreHPWaite()//[IEnumerator协程]: 暂时理解为方法的一种，用StartCoroutine()启用
    {
        yield return new WaitForSeconds(0.2f);//等待0.2秒
        isHurt = true;
    }
}
