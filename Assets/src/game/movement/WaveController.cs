using UnityEngine;

public class WaveController : MonoBehaviour {
  public WaveInput input;

  public float drag;
  public float perpendicularDrag;

  float[] speed;
  float angle;

  void FixedUpdate() {
    if (speed == null || speed.Length == 0) {
      speed = new float[2] {0, 0};
    }

    var tSquared = Mathf.Pow(Time.fixedDeltaTime, 2);
    var accelSquared = input.accel * tSquared * 10;

    var lastSpeedMagnitude = Mathf.Sqrt(speed[0] * speed[0] + speed[1] * speed[1]);

    // Turn the character
    angle += input.direction * 10 * (
      lastSpeedMagnitude * tSquared * 2 +
      input.accel * tSquared
    );

    // Apply acceleration to speed of character
    speed[0] += accelSquared * 10 * 2 * Mathf.Cos(angle);
    speed[1] += accelSquared * 10 * 2 * Mathf.Sin(angle);
    var speedAngle = Vector2.Angle(
      new Vector2(speed[0], speed[1]),
      new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))
    );

    // Apply drag to speed
    speed[0] *= (1 - drag);
    speed[1] *= (1 - drag);

    // Project speed against angle so that speed not in the facing direction of
    // the character is dragged off.
    var speedMag = Mathf.Sqrt(speed[0] * speed[0] + speed[1] * speed[1]);
    // Project: |a| * ((a * b) / (|a| * |b|)) * b / |b|
    // We can drop |a| and |b| parts of this formula. |b| causes its always 1.
    // |a| because without |b| we can see they'll become |a| / |a|.
    var component = speed[0] * Mathf.Cos(angle) + speed[1] * Mathf.Sin(angle);
    speed[0] = speed[0] * (1 - perpendicularDrag) +
      component * Mathf.Cos(angle) * perpendicularDrag;
    speed[1] = speed[1] * (1 - perpendicularDrag) +
      component * Mathf.Sin(angle) * perpendicularDrag;

    transform.position += new Vector3(speed[0], speed[1], 0) * Time.fixedDeltaTime;
    transform.eulerAngles = new Vector3(0, 0, angle / Mathf.PI * 180);
  }
}
