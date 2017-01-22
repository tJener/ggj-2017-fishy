using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MeshBonePair {
    public Mesh sharedMesh;
    public GameObject bone;
}

public class SwordyBody : MonoBehaviour {
    public List<MeshBonePair> meshBonePairs;
    public List<SkinnedMeshRenderer> collidableGeo;
    public WaveInput waveInput;
    public Animation anim;
    public float skinWidth = 0.01f;

    void Start() {
        foreach (var smr in collidableGeo) {
            MeshCollider collider = smr.gameObject.AddComponent<MeshCollider>();
            collider.convex = true;
            collider.inflateMesh = true;
            collider.skinWidth = skinWidth;
            collider.sharedMesh = smr.sharedMesh;
        }

        // foreach (var pair in meshBonePairs) {
        //     GameObject colliderObj = new GameObject("collider");
        //     colliderObj.transform.SetParent(pair.bone.transform, false);
        //     MeshCollider collider = colliderObj.AddComponent<MeshCollider>();
        //     collider.convex = true;
        //     collider.inflateMesh = true;
        //     collider.skinWidth = skinWidth;
        //     collider.sharedMesh = pair.sharedMesh;
        // }
    }

    void Update() {
        float tailPos = 0.5f;
        if (waveInput != null) {
          tailPos = -waveInput.direction / 2.5f + 0.5f;
        }
        anim.clip.SampleAnimation(anim.gameObject, anim.clip.length * Mathf.Clamp(tailPos, 0.0f, 1.0f));
    }
}
