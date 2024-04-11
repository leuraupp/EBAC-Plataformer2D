using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemCollactableApple : ItemCollactableBase 
{
    protected override void Collect() {
        base.Collect();
        //gameObject.transform.DOScaleX(-1, .3f).SetLoops(2, LoopType.Yoyo).OnComplete(() => Destroy(gameObject));
    }

    protected override void OnCollect() {
        base.OnCollect();
        ItemManager.Instance.AddApple();
        Destroy(gameObject);
    }
}
