using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rig2D;

    [Header("Atributes")]
    public float speed;
    public float forceJump;

    private void Update() {
        HandleJumping();
        HandleMovement();
    }

    private void HandleMovement() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rig2D.velocity = new Vector2(-speed, rig2D.velocity.y);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            rig2D.velocity = new Vector2(speed, rig2D.velocity.y);
        }
    }

    private void HandleJumping() {

    }
}
