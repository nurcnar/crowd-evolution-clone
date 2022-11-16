using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    int age;
    private void Start()
    {
        age = PlayerMovement.instance.age;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemyBullet"))
        {
            PoolingManager.instance.AddPool(other.gameObject);
            age--;
            age = Mathf.Clamp(age, 0, 40);
            PlayerMovement.instance.ageText.text = age.ToString();
        }
    }
}
