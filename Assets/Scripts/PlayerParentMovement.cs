using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParentMovement : MonoBehaviour
{

    float amountToMove;

    float xPos;
    float zPos;

    public bool isClick;

    public static PlayerParentMovement instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        isClick = true;
    }
    void Update()
    {
        // if burda mı daha iyi moveda mı
        Move();

        HorizontalMove();
    }

    private void Move()
    {
        if (isClick == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10);

        }
    }
    private void FixedUpdate()
    {
        Borders();
    }

    public void HorizontalMove()
    {
        if (isClick == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                amountToMove = Input.GetAxis("Horizontal") * 10;
                transform.Translate(Vector3.right * amountToMove, Space.Self);
            }
        }
    }

    public void Borders()
    {
        xPos = Mathf.Clamp(transform.position.x, -2, 2);
        zPos = Mathf.Clamp(transform.position.z, -46, 95);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
