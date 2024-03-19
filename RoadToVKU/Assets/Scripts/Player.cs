using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Public Feilds
    public float speed = 2;

    //Private Fields
    Rigidbody2D rb;
    float horizontalValue;
    bool facingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lưu trữ giá trị ngang
        horizontalValue = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalValue);
    }

    void FixedUpdate()
    {
        Move(horizontalValue);
    }

    void Move(float dir)
    {
        //Đặt giá trị của x bằng dir và speed
        float xVal = dir * speed * 100 * Time.deltaTime;
        // Tạo Vec2 cho vận tốc
        Vector2 targetVelocity = new Vector2(xVal,rb.velocity.y);
        //Đặt vận tốc của người chơi
        rb.velocity = targetVelocity;

        //Nếu look phải mà click trái (flip sang trái)
        if(facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        //Nếu look trái mà click phải (flip sang phải)
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight =true;
        }
    }
}
