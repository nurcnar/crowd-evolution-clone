using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public List<GameObject> withMe = new List<GameObject>();

    public TextMeshProUGUI ageText;

    public int age = 10;

    public GameObject mom;

    public GameObject prefab;

    float xPos;
    float zPos;

    public bool isLimit=false;

    public static PlayerMovement instance;
    void Awake()
    {
        instance = this;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("people"))
        {
            switch (other.gameObject.GetComponent<Door>().attribute)
            {
                case Door.Attribute.people3:
                    Shoot.instance.isShootingPlayer = true;
                    for (int i = 1; i < 3; i++)
                    {
                        var clone = Instantiate(prefab, new Vector3(transform.position.x + i, transform.position.y, transform.position.z), Quaternion.identity);
                        clone.transform.parent = mom.transform;
                        clone.AddComponent<Shoot>();
                        withMe.Add(clone.gameObject);
                    }
                    for (int i = 1; i < 3; i++)
                    {
                        var clone = Instantiate(prefab, new Vector3(transform.position.x - i, transform.position.y, transform.position.z), Quaternion.identity);
                        clone.transform.parent = mom.transform;
                        clone.AddComponent<Shoot>();
                        withMe.Add(clone.gameObject);
                    }
                    break;

                case Door.Attribute.people5:
                    Shoot.instance.isShootingPlayer = true;
                    for (int i = 0; i < 3; i++)
                    {
                        var clone = Instantiate(prefab, new Vector3(transform.position.x - i + 1, transform.position.y, transform.position.z - 1), Quaternion.identity);
                        clone.transform.parent = mom.transform;
                        clone.AddComponent<Shoot>();
                        withMe.Add(clone.gameObject);
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        var clone = Instantiate(prefab, new Vector3(transform.position.x - i + 0.5f, transform.position.y, transform.position.z - 2), Quaternion.identity);
                        clone.transform.parent = mom.transform;
                        clone.AddComponent<Shoot>();
                        withMe.Add(clone.gameObject);
                    }
                    break;
            }
        }
        else if (other.CompareTag("years"))
        {
            switch (other.gameObject.GetComponent<Door>().attribute)
            {
                case Door.Attribute.years10:
                    age += 10;
                    ageText.text = age.ToString();
                    break;
                case Door.Attribute.years20:
                    age += 20;
                    ageText.text = age.ToString();
                    break;

            }
        }

        else if (other.CompareTag("cube"))
        {
            GetComponent<CapsuleCollider>().isTrigger = false;
            transform.position = new Vector3(-4, 1, 40);
            int x = withMe.Count;
            for (int i = 0; i < x; i++)
            {
                var o = withMe[i];
                o.transform.position = new Vector3(-4 + i + 1, 1, 40);
                o.GetComponent<CapsuleCollider>().isTrigger = false;
            }

            EnemyParentMovement.instance.kinetic = true; //düşman bize doğru gelcek onun için
            CameraMovement.instance.stop = true;
            PlayerParentMovement.instance.isClick = false; //biz artık ileri hareket etmeyelim diye
            isLimit = true;
            //Shoot.instance.isShooting = true;

        }
    }
    private void FixedUpdate()
    {
        Borders();
    }
    public void Borders()
    {
        xPos = Mathf.Clamp(transform.position.x, -5, 5);
        zPos = Mathf.Clamp(transform.position.z, -46, 95);
        
        for (int i = 0; i < withMe.Count; i++)
        {
            if(isLimit==true)
            {
                var o = withMe[i];
                float xPosc = Mathf.Clamp(o.transform.position.x, -5, 5);
                float zPosc = Mathf.Clamp(o.transform.position.z, 38, 42);
                o.transform.position = new Vector3(xPosc, o.transform.position.y, zPosc);
            }
        }
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }

    
}