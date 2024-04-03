using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Enemy Atribute")]
    public int damage = 0;
    public HealthBase health;

    [Header("Enemy Animator")]
    public Animator animator;
    public string triggerAttack = "Attack";

    private void OnCollisionEnter2D(Collision2D collision) {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null) {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation() {
        animator.SetTrigger(triggerAttack);
    }

    public void Damege(int amount) {
        health.Damage(amount);
    }
}
