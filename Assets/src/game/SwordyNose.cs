using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordyNose : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        var firstContact = collision.contacts[0];
        float contactDot = Vector3.Dot(transform.forward, -firstContact.normal);

        if (0.7f <= contactDot) {
            print("Stab");
        } else if(0.0f <= contactDot) {
            print("Slice");
        } else {
            print("Bump");
        }
    }
}
