using UnityEngine;

public class MouseWaveInput : WaveInput {
  float lastValue;
  public override float GetAxis() {
    var newValue = Input.GetAxis("Horizontal") + lastValue;
    lastValue = newValue;
    return newValue;
  }
}
