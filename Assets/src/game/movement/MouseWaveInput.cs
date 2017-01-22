using UnityEngine;

public class MouseWaveInput : WaveInput {
  public string axis = "Mouse";
  float lastValue;
  public override float GetAxis() {
    // Mouse Sensitvity.
    // Add the mouse delta to the last value and clamp between the min and
    // max.
    var newValue = Mathf.Clamp(Input.GetAxis(axis) + lastValue, -250, 250);
    lastValue = newValue;
    return newValue;
  }
}
