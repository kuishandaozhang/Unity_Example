using System.Collections;
using UnityEngine;

/// <summary>
/// 产品控制
/// </summary>
public class Product : MonoBehaviour {

    private float speed = 10;
    private bool isMove = false;
    private const float stopPos_Z = -10.7252f;

    private GameController gameController;
    private Rigidbody rig;

    private float time = 0;

    void Start () {
        gameController = GameObject.Find("Holder/Hand/Claw").GetComponent<GameController>();
        rig = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (gameController.isProductMove && !isMove)
        {
            StartCoroutine(IEMove());
        }
        if (isMove)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
            if (transform.position.z > stopPos_Z)
            {
                isMove = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, stopPos_Z);
                StopAllCoroutines();
            }
        }
        //超过时间自动回收
        time += Time.deltaTime;
        if (time >= 10)
        {
            StopAllCoroutines();
            ObjectPool.GetInstance().RecycleObj(gameObject);
        }
    }
    IEnumerator IEMove()
    {
        isMove = true;
        yield return new WaitForSeconds(0.2f);
        gameController.isProductMove = false;
        yield return new WaitForSeconds(0.5f);
        isMove = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Box")
        {
            StopAllCoroutines();
            ObjectPool.GetInstance().RecycleObj(gameObject);
        }
    }

    public void Init(Transform point)
    {
        time = 0;
        transform.position = point.position;
        transform.rotation = point.rotation;
    }
}
