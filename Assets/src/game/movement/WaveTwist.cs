using UnityEngine;

public class WaveTwist : MonoBehaviour {
  public WaveInput input;

  void Update() {
    transform.localEulerAngles = new Vector3(0, input.direction * 7, 0);
  }
}
