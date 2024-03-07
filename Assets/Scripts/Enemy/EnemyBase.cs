using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Enemy Atribute")]
    public int damage = 0;

    private void OnCollisionEnter2D(Collision2D collision) {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null) {
            health.Damage(damage);
        }
    }
}
