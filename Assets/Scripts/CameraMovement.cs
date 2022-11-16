using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public Vector3 diff;
    public bool stop = false; 

    public static CameraMovement instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        diff = target.transform.position - transform.position;
    }
    private void LateUpdate()
    {
        Following();
    } 
    void Following()
    {
        if(!stop)
        {
            transform.position += diff * Time.deltaTime*5;
        }

    }
}
