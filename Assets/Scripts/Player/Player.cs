using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rig2D;

    [Header("Atributes")]
    public float speed;
    public float speedRun;
    public float forceJump;
    public float friction;

    private float _currentSpeed;

    private void Update() {
        HandleJumping();
        HandleMovement();
    }

    private void HandleMovement() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            _currentSpeed = speedRun;
        } else {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rig2D.velocity = new Vector2(-_currentSpeed, rig2D.velocity.y);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            rig2D.velocity = new Vector2(_currentSpeed, rig2D.velocity.y);
        }

        if (rig2D.velocity.x > 0) {
            rig2D.velocity -= new Vector2(friction, 0);
        } else if (rig2D.velocity.x < 0) {
            rig2D.velocity += new Vector2(friction, 0);
        }
    }

    private void HandleJumping() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig2D.velocity = Vector2.up * forceJump;
        }
    }
}
