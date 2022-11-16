using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    GameObject bullet;
    public bool isMove = true;

    public bool isShooting = false;

    public bool isShootingPlayer = false;

    public static Shoot instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(ShotBullet());

    }
    IEnumerator ShotBullet()
    {
        if(isMove)
        {
                bullet = PoolingManager.instance.SendBullet();
                bullet.transform.position = PlayerMovement.instance.transform.position;
                bullet.tag = "playerBullet";
                bullet.GetComponent<Rigidbody>().velocity = (transform.forward * 50);
                StartCoroutine(AddBullet(bullet));

                int x = PlayerMovement.instance.withMe.Count;
                for (int i = 0; i < x; i++)
                {
                    bullet = PoolingManager.instance.SendBullet();
                    bullet.transform.position = PlayerMovement.instance.withMe[i].transform.position;
                    bullet.tag = "playerBullet";
                    bullet.GetComponent<Rigidbody>().velocity = (transform.forward * 50);
                    StartCoroutine(AddBullet(bullet));
                }
            
            
                for (int i = 0; i < 4; i++)
                {
                    bullet = PoolingManager.instance.SendBullet();
                    bullet.transform.position = EnemyParentMovement.instance.gameObject.transform.GetChild(i).position;
                    bullet.tag = "enemyBullet";
                    bullet.GetComponent<Rigidbody>().velocity = (-transform.forward * 50);
                    StartCoroutine(AddBullet(bullet));
                }
            
            
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator AddBullet(GameObject _bullet)
    {
        yield return new WaitForSeconds(1);
        PoolingManager.instance.AddPool(_bullet);
    }
}
