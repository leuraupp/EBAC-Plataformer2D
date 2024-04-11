using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rig2D;
    public HealthBase health;

    public SOPlayer soPlayer;

    private float _currentSpeed;
    private bool _groundedAnimating = false;
    private Animator _currentPlayer;

    private void Awake() {
        if (health != null) {
            health.OnKill += PlayerKill;
        }

        _currentPlayer = Instantiate(soPlayer.player, transform);
    }

    private void Update() {
        HandleJumping();
        HandleMovement();
    }

    private void HandleMovement() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            _currentSpeed = soPlayer.speedRun;
            _currentPlayer.speed = 2;
        } else {
            _currentSpeed = soPlayer.speed;
            _currentPlayer.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rig2D.velocity = new Vector2(-_currentSpeed, rig2D.velocity.y);
            rig2D.transform.DOScaleX(-1, soPlayer.playerSwipeDuration);
            _currentPlayer.SetBool(soPlayer.boolRun, true);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            rig2D.velocity = new Vector2(_currentSpeed, rig2D.velocity.y);
            rig2D.transform.DOScaleX(1, soPlayer.playerSwipeDuration);
            _currentPlayer.SetBool(soPlayer.boolRun, true);
        } else {
            _currentPlayer.SetBool(soPlayer.boolRun, false);
        }

        if (rig2D.velocity.x > 0) {
            rig2D.velocity -= soPlayer.friction;
        } else if (rig2D.velocity.x < 0) {
            rig2D.velocity += soPlayer.friction;
        }
    }

    private void HandleJumping() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig2D.velocity = Vector2.up * soPlayer.forceJump;
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
        _currentPlayer.SetBool(soPlayer.boolJump, true);
        _currentPlayer.SetBool(soPlayer.boolRun, false);
    }

    private void HandleScaleGrounded() {
        //rig2D.transform.DOScaleY(groundedScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        //rig2D.transform.DOScaleX(groundedScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        _currentPlayer.SetBool(soPlayer.boolJump, false);
    }

    public void PlayerKill() {
        health.OnKill -= PlayerKill;
        _currentPlayer.SetTrigger(soPlayer.triggerDeath);
    }

    public void DestroyMe() {
        Destroy(gameObject);
    }
}
