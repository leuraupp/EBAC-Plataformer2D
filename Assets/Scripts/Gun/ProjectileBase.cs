using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [Header("Projetile Atributes")]
    public Vector3 projectileDirection;
    public float timeToDestroy = 1f;
    public float side = 1;
    public int damage = 1;

    private void Awake() {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update() {
        transform.Translate(projectileDirection * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if (enemy != null) {
            enemy.Damege(damage);
            Destroy(gameObject);
        }
    }
}
