using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController  : MonoBehaviour
{

    Time time;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerBullet"))
        {
            PoolingManager.instance.AddPool(other.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Shoot.instance.isMove = false;

        }

    }




}
