using UnityEngine;
using System.Collections;

public class CameraFllow : MonoBehaviour
{

    private Transform player;

    public float smoothing = 3;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraPos = player.position + new Vector3(0, 5, -6);
        transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing * Time.deltaTime);
    }
}