using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NopeScript : MonoBehaviour {

    public float nopeForce;

    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.GetComponent<Rigidbody2D>().AddForce(Vector2.left * nopeForce, ForceMode2D.Impulse);
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        collider.GetComponent<Rigidbody2D>().AddForce(Vector2.left * nopeForce, ForceMode2D.Force);
    }
}
