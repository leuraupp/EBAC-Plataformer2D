using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [Header("Projectile Config")]
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoots = .1f;
    public Transform playerSideReference;

    private Coroutine _currentCoroutine;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            if (_currentCoroutine != null) {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot() {
        while (true) {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    public void Shoot() {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
