using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public delegate void GoalCallback();
    public event GoalCallback callback;

    public AudioSource source;

    void OnTriggerEnter(Collider other) {
        var b = other.gameObject.GetComponent<Ball>();
        if (b == null) {
            b = other.gameObject.GetComponentInChildren<Ball>();
        }
        if (b == null) {
            b = other.gameObject.GetComponentInParent<Ball>();
        }
        if (b != null) {
            print("Goal!");
            if (source != null) {
              source.Play();
            }
            if (callback != null) {
                callback();
            }
        }
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
