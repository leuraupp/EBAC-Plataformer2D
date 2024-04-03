using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{

    public List<SpriteRenderer> spriteRenderes;
    public Color color = Color.red;
    public float duration = .1f;

    private Tween _currentTween;

    private void OnValidate() {
        spriteRenderes = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>()) {
            spriteRenderes.Add(child);
        }
    }

    public void Flash() {

        if (_currentTween != null) {
            _currentTween.Kill();
            spriteRenderes.ForEach(i => i.color = Color.white);
        }

        foreach (var s in spriteRenderes) {
            s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
