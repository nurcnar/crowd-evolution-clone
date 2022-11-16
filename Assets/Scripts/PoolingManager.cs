using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolingManager : MonoBehaviour
{
    public List<GameObject> pool = new List<GameObject>();

    public GameObject bulletPrefab; 
    GameObject clone;

    public static PoolingManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < 20 ; i++)
        {
            clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            clone.SetActive(false); 
            pool.Add(clone);
        }
    }
    public void AddPool(GameObject bullet)
    {
        pool.Add(bullet);
        bullet.SetActive(false);
    }
    public GameObject SendBullet()
    {
        if(pool.Count<1)
        {
            pool.Add(Instantiate(bulletPrefab, transform.position, Quaternion.identity));
        }
        GameObject last = pool.Last();
        pool.Remove(last);
        last.SetActive(true);
        return last;
    }
}