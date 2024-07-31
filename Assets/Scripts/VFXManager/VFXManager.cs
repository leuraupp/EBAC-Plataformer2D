using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType {
        Jump,
        VFX_2
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayVFXNyType(VFXType vfxType, Vector3 position) {
        foreach (var i in vfxSetup) {
            if (i.vfxType == vfxType) {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item, 5f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup {
    public VFXManager.VFXType vfxType;
    public GameObject prefab;

}
