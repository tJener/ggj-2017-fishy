using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        var g = other.gameObject.GetComponent<Gibbify>();
        if (g == null) {
            g = other.gameObject.GetComponentInChildren<Gibbify>();
        }
        if (g == null) {
            g = other.gameObject.GetComponentInParent<Gibbify>();
        }
        if (g != null) {
            g.Kill();
        }
    }
}
