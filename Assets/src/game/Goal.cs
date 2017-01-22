using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public delegate void GoalCallback();
    public event GoalCallback callback;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Ball>()) {
            print("Goal!");
            if (callback != null) {
                callback();
            }
        }
    }
}
