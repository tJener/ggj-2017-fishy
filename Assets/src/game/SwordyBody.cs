using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordyBody : MonoBehaviour {
    public List<SkinnedMeshRenderer> collidableGeo;
    public float skinWidth = 0.01f;

    void Start() {
        foreach (var smr in collidableGeo) {
            MeshCollider collider = smr.gameObject.AddComponent<MeshCollider>();
            collider.convex = true;
            collider.inflateMesh = true;
            collider.skinWidth = skinWidth;
            collider.sharedMesh = smr.sharedMesh;
        }
    }
}
