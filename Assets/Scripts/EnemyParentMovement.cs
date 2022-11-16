using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParentMovement : MonoBehaviour
{
    public static EnemyParentMovement instance;
    private void Awake()
    {
        instance = this;
    }
    public bool kinetic = false;
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if(kinetic==true)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * 10);
        }
    }
    



}
