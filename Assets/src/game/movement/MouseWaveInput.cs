using UnityEngine;

public class MouseWaveInput : WaveInput {
  float lastValue;
  public override float GetAxis() {
    // Joystick Sensitvity.
    // Add the joystick to the last value making it a second (overall third)
    // order movement control. Then map the linear values to a sin curve.
    var newValue = lastValue;
    if (Input.GetAxis("Horizontal") != 0) {
      newValue = Mathf.Clamp(Input.GetAxis("Horizontal") * Time.deltaTime * 2 + lastValue, -1, 1);
    }
    else if (Input.GetAxis("Horizontal") < 0) {
      newValue = Input.GetAxis("Horizontal") * Time.deltaTime * 5 + lastValue;
    }
    else {
      newValue = 0 + lastValue / 2;
    }
    lastValue = newValue;
    return Mathf.Sin(newValue * Mathf.PI / 2) * 250;

    // // Mouse Sensitvity.
    // // Add the mouse delta to the last value and clamp between the min and
    // // max.
    // var newValue = Mathf.Clamp(Input.GetAxis("Horizontal") + lastValue, -250, 250);
    // lastValue = newValue;
    // return newValue;
  }
}
