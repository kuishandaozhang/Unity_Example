using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 机爪抓取控制器
/// </summary>
public class Hand : MonoBehaviour {

    private const float movePos_X = 8f;             //[移动]至收集箱的位置
    private const float preScale_Y = 0.8f;          //[伸缩]前缩放
    private const float scaled_Y = 1.77324f;        //[伸缩]后缩放
    private const float preScalePos_Y = -1.111503f; //[伸缩]前位置
    private const float scaledPos_Y = -2.0847f;     //[伸缩]后位置
    private const float fingerRotateAngle = -15;    //[旋转]手指松开的角度

    private float moveSpeed = 20;
    private float scaleSpeed = 10;
    private float pickupSpeed = 100;

    private bool isMove = false;
    private bool isMoveToLeft = false;
    private bool isScale = false;
    private bool isScaleShort = false;
    private bool isPickup = false;
    private bool isLoosen = false;//松开
    public  bool isReady = true;

    private Transform scalePipe;
    private Transform claw;
    private Transform leftFinger;
    private Transform rightFinger;

    private Transform product;
    private GameController gameController;

    private float timer = 1.7f;
    private float time = 0;
    private bool isTime = false;

    void Start () {
        scalePipe = transform.Find("ScalePipe");
        claw = transform.Find("Claw");
        leftFinger = transform.Find("Claw/Left/Finger");
        rightFinger = transform.Find("Claw/Right/Finger");
        gameController = transform.Find("Claw").GetComponent<GameController>();
    }

    void Update () {
        if (isMove)
        {
            Move();
        }
        else if (isScale)
        {
            Scale();
        }
        else if (isPickup)
        {
            Pickup();
        }

        //出错修正
        if (isTime)
        {
            time += Time.deltaTime;
            if(time >= timer)
            {
                gameController.NextProduct();
                time = 0;
            }
        }
    }
    /// <summary>
    /// 移动
    /// </summary>
    private void Move()
    {
        if (isMoveToLeft)//往左移动
        {
            transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
            if (transform.localPosition.x <= 0)//到达左边
            {
                transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
                isMoveToLeft = false;
                isMove = false;
            }
        }
        else//往右移动
        {
            transform.Translate(transform.right * moveSpeed * Time.deltaTime);
            if (transform.localPosition.x >= movePos_X)//到达右边
            {
                transform.localPosition = new Vector3(movePos_X, transform.localPosition.y, transform.localPosition.z);
                isMoveToLeft = true;
                isMove = false;
            }
        }
    }
    /// <summary>
    /// 伸缩
    /// </summary>
    private void Scale()
    {
        if (isScaleShort)//缩短
        {
            //缩放
            float tempY = scalePipe.localScale.y - scaleSpeed * Time.deltaTime;
            scalePipe.localScale = new Vector3(scalePipe.localScale.x, tempY, scalePipe.localScale.z);
            //位置
            float tempPosY = (scalePipe.localScale.y - preScale_Y) / (scaled_Y - preScale_Y) * (scaledPos_Y - preScalePos_Y) + preScalePos_Y;
            scalePipe.localPosition = new Vector3(scalePipe.localPosition.x, tempPosY, scalePipe.localPosition.z);
            if (scalePipe.localScale.y <= preScale_Y)//到达最短
            {
                scalePipe.localScale = new Vector3(scalePipe.localScale.x, preScale_Y, scalePipe.localScale.z);
                scalePipe.localPosition = new Vector3(scalePipe.localPosition.x, preScalePos_Y, scalePipe.localPosition.z);
                isScaleShort = false;
                isScale = false;
            }
        }
        else//伸长
        {
            //缩放
            float tempY = scalePipe.localScale.y + scaleSpeed * Time.deltaTime;
            scalePipe.localScale = new Vector3(scalePipe.localScale.x, tempY, scalePipe.localScale.z);
            //位置
            float tempPosY = (scalePipe.localScale.y - preScale_Y) / (scaled_Y - preScale_Y) * (scaledPos_Y - preScalePos_Y) + preScalePos_Y;
            scalePipe.localPosition = new Vector3(scalePipe.localPosition.x, tempPosY, scalePipe.localPosition.z);
            if (scalePipe.localScale.y >= scaled_Y)//到达最长
            {
                scalePipe.localScale = new Vector3(scalePipe.localScale.x, scaled_Y, scalePipe.localScale.z);
                scalePipe.localPosition = new Vector3(scalePipe.localPosition.x, scaledPos_Y, scalePipe.localPosition.z);
                isScaleShort = true;
                isScale = false;
            }
        }
        //Claw爪子位置
        float clawPosY = scalePipe.localPosition.y - scalePipe.localScale.y;
        claw.localPosition = new Vector3(claw.localPosition.x, clawPosY, claw.localPosition.z);
    }
    /// <summary>
    /// 抓取
    /// </summary>
    private void Pickup()
    {
        if (isLoosen)
        {
            leftFinger.Rotate(-new Vector3(0, 0, pickupSpeed) * Time.deltaTime);
            rightFinger.Rotate(new Vector3(0, 0, pickupSpeed) * Time.deltaTime);
            if (rightFinger.localEulerAngles.z >= -fingerRotateAngle)
            {
                leftFinger.localEulerAngles = new Vector3(leftFinger.localEulerAngles.x, leftFinger.localEulerAngles.y, fingerRotateAngle);
                rightFinger.localEulerAngles = new Vector3(rightFinger.localEulerAngles.x, rightFinger.localEulerAngles.y, -fingerRotateAngle);
                isLoosen = false;
                isPickup = false;
            }
        }
        else
        {
            leftFinger.Rotate(new Vector3(0, 0, pickupSpeed) * Time.deltaTime);
            rightFinger.Rotate(-new Vector3(0, 0, pickupSpeed) * Time.deltaTime);
            if (rightFinger.localEulerAngles.z >= 350)//350并不是特殊值 本来：值<=0 不存在负角度(0~360) 改为 值>=350
            {
                leftFinger.localEulerAngles = new Vector3(leftFinger.localEulerAngles.x, leftFinger.localEulerAngles.y, 0);
                rightFinger.localEulerAngles = new Vector3(rightFinger.localEulerAngles.x, rightFinger.localEulerAngles.y, 0);
                isLoosen = true;
                isPickup = false;
            }
        }
    }
    /// <summary>
    /// 运作
    /// </summary>
    public void Work()
    {
        StartCoroutine(TimeController());
    }
    /// <summary>
    /// 时间控制器
    /// </summary>
    IEnumerator TimeController()
    {
        isReady = false;
        //出错修正
        time = 0;
        isTime = false;

        isScale = true; //1. 伸长
        yield return new WaitForSeconds(0.2f);
        isPickup = true;//2. 抓取
        Ray ray = new Ray(claw.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Product")
            {
                product = hit.transform;
                product.parent = claw;
            }
        }
        yield return new WaitForSeconds(0.2f);
        isScale = true; //3. 缩短
        yield return new WaitForSeconds(0.2f);
        isMove = true;  //4. 右移
        yield return new WaitForSeconds(0.033f);
        gameController.NextProduct();
        yield return new WaitForSeconds(0.367f);
        isPickup = true;//5. 松开
        if (product != null)
        {
            Rigidbody rig = product.GetComponent<Rigidbody>();
            rig.isKinematic = false;
            product.parent = null;
        }
        yield return new WaitForSeconds(0.3f);
        isMove = true;  //6. 左移
        yield return new WaitForSeconds(0.333f);//1.7
        isReady = true;

        //出错修正
        isTime = true;
    }
}