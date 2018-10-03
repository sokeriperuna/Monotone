using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerEntity playerEntity;

    private float hInput;
    private float jumpStopTime;

    public bool jumping = false;
    public bool verticalMomentumStopped = false;

    public float jumpStopInterval;

    void Awake()
    {
        playerEntity = GetComponent<PlayerEntity>();
    }

	void FixedUpdate ()
    {
        hInput = GetHorizontalInput();
        if (hInput != 0)
            playerEntity.Move(hInput);

        if (!jumping && Input.GetKey(KeyCode.Space))
        {
            jumping = true;
            jumpStopTime = jumpStopInterval + Time.time;
            playerEntity.Jump();
        }
        else if(jumping && jumpStopTime < Time.time && !Input.GetKey(KeyCode.Space) && !verticalMomentumStopped)
        {
            verticalMomentumStopped = true;
            playerEntity.StopVerticalMomemtum();
        }
        else if(jumpStopTime > Time.time && jumping && Input.GetKeyUp(KeyCode.Space))
        {
            verticalMomentumStopped = true;
        }
	}

    float GetHorizontalInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Ground"))
        {
            verticalMomentumStopped = false;
            jumping = false;
        }

        Debug.Log("Not jumping.");
    }
}
