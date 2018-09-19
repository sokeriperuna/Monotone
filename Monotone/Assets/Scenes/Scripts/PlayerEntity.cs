using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour {

    private Rigidbody2D rb;

    public float jumpForce;
    public float movementSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Move(float hInput)
    {
        rb.MovePosition(rb.position + Vector2.right * hInput * movementSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void StopVerticalMomemtum()
    {
        Vector2 v = rb.velocity;
        rb.velocity = new Vector2(v.x, 0f);
    }
}
