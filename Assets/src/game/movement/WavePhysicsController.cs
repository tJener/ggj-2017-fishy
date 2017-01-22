using UnityEngine;

public class WavePhysicsController : MonoBehaviour {
  public WaveInput input;
  public Rigidbody rigidbody;

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

    var lastSpeedMagnitude = rigidbody.velocity.magnitude;

    // Turn the character
    rigidbody.AddTorque(Vector3.down * rigidbody.angularVelocity.y * Time.fixedDeltaTime * 5, ForceMode.Impulse);
    rigidbody.AddTorque(Vector3.down * input.direction * (
      Mathf.Clamp(lastSpeedMagnitude * tSquared * 8, -0.5f, 0.5f) +
      input.accel * tSquared * 80
    ), ForceMode.Impulse);

    // Apply acceleration to speed of character
    rigidbody.AddForce(input.accel * 100 * transform.forward, ForceMode.Acceleration);

    var speedAngle = Vector2.Angle(
      new Vector2(rigidbody.velocity[0], rigidbody.velocity[2]),
      new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))
    );

    // Project speed against angle so that speed not in the facing direction of
    // the character is dragged off.
    var speedMag = rigidbody.velocity.magnitude;
    // Project: |a| * ((a * b) / (|a| * |b|)) * b / |b|
    // We can drop |a| and |b| parts of this formula. |b| causes its always 1.
    // |a| because without |b| we can see they'll become |a| / |a|.
    var component = rigidbody.velocity.x * transform.forward.x + rigidbody.velocity.z * transform.forward.z;
    rigidbody.AddForce(rigidbody.velocity * -perpendicularDrag, ForceMode.VelocityChange);
    rigidbody.AddForce(transform.forward * component * perpendicularDrag, ForceMode.VelocityChange);
  }
}
