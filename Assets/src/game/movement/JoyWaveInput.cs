using UnityEngine;

public class JoyWaveInput : WaveInput {
  public string axis = "Joypad0";
  float lastValue;
  public override float GetAxis() {
    // Joystick Sensitvity.
    // Add the joystick to the last value making it a second (overall third)
    // order movement control. Then map the linear values to a sin curve.
    var direction = Mathf.Atan2(-Input.GetAxis(axis + " Vertical"), Input.GetAxis(axis));
    if (Mathf.Abs(Input.GetAxis(axis + " Vertical")) > 0.1 || Mathf.Abs(Input.GetAxis(axis)) > 0.1) {
      if (axis == "Joypad3") {
        // Debug.Log(direction);
        // Debug.Log(-transform.eulerAngles.y / 180 * Mathf.PI + Mathf.PI / 2);
        // Debug.Log(Mathf.DeltaAngle(direction / Mathf.PI * 180, -transform.eulerAngles.y + 90));
      }
      // Debug.DrawRay(transform.position, Quaternion.Euler(0, Mathf.DeltaAngle(direction, transform.eulerAngles.y / 180), 0) * transform.forward);
      return Mathf.Clamp(Mathf.Clamp(Mathf.DeltaAngle(direction / Mathf.PI * 180, -transform.eulerAngles.y + 90) / 180 * Mathf.PI, -Mathf.PI, Mathf.PI) * 250, -250, 250);
    }
    else {
      return 0;
    }
    var newValue = Mathf.Clamp(Input.GetAxis(axis) * Time.deltaTime * 3 + lastValue * (1 - Time.deltaTime), -1, 1);
    if (Mathf.Abs(Input.GetAxis(axis)) < 0.1) {
      newValue = lastValue / 2;
    }
    lastValue = newValue;
    return Mathf.Sin(newValue * Mathf.PI / 2) * 250;
  }
}
