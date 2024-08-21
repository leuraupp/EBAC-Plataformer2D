using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake() {
        if (particleSystem != null) {
            particleSystem.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.CompareTag(compareTag)) {
            Collect();
        }
    }

    protected virtual void Collect() {
        OnCollect();
    }

    protected virtual void OnCollect() {
        if (particleSystem != null) {
            particleSystem.Play();
        }
        if (audioSource != null) {
            audioSource.Play();
        }
    }
}
