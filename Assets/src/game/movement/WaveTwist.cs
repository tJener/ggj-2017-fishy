using UnityEngine;

public class WaveTwist : MonoBehaviour {
  public WaveController controller;

  void Update() {
    transform.localEulerAngles = new Vector3(0, controller.input.direction * 7, 0);
  }
}
