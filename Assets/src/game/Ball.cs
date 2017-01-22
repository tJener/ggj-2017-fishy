using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
  public AudioSource source;

  void OnCollisionEnter(Collision c) {
    if (source != null) {
      source.Play();
    }
  }
}
