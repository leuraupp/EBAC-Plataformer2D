using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rig2D;
    public HealthBase health;

    [Header("Speed Atributes")]
    public float speed;
    public float speedRun;
    public float forceJump;
    public float friction;

    [Header("Animation Atributes")]
    public float jumpScaleY = 1.1f;
    public float jumpScaleX = 0.7f;
    public float groundedScaleY = 0.8f;
    public float groundedScaleX = 1.2f;
    public float animationDuration = 0.3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;
    public Animator animator;

    private float _currentSpeed;
    private bool _groundedAnimating = false;

    private void Awake() {
        if (health != null) {
            health.OnKill += PlayerKill;
        }
    }

    private void Update() {
        HandleJumping();
        HandleMovement();
    }

    private void HandleMovement() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            _currentSpeed = speedRun;
            animator.speed = 2;
        } else {
            _currentSpeed = speed;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rig2D.velocity = new Vector2(-_currentSpeed, rig2D.velocity.y);
            rig2D.transform.DOScaleX(-1, playerSwipeDuration);
            animator.SetBool(boolRun, true);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            rig2D.velocity = new Vector2(_currentSpeed, rig2D.velocity.y);
            rig2D.transform.DOScaleX(1, playerSwipeDuration);
            animator.SetBool(boolRun, true);
        } else {
            animator.SetBool(boolRun, false);
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
            rig2D.transform.localScale = Vector2.one;

            //DOTween.Kill(rig2D.transform);

            HandleScaleJump();
            _groundedAnimating = false;
        }
        if (rig2D.velocity.y == 0 && !_groundedAnimating) {
            _groundedAnimating = true;
           // DOTween.Kill(rig2D.transform);
            HandleScaleGrounded();
        }
    }

    private void HandleScaleJump() {
        //rig2D.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        //rig2D.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        animator.SetBool(boolJump, true);
        animator.SetBool(boolRun, false);
    }

    private void HandleScaleGrounded() {
        //rig2D.transform.DOScaleY(groundedScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        //rig2D.transform.DOScaleX(groundedScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        animator.SetBool(boolJump, false);
    }

    public void PlayerKill() {
        health.OnKill -= PlayerKill;
        animator.SetTrigger(triggerDeath);
    }

    public void DestroyMe() {
        Destroy(gameObject);
    }
}
