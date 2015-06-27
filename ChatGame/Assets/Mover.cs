using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public int hp = 1;
	public int count = 0, frame = 0;
	public Vector3 pos, prevPos, velocity;
	public Quaternion rotation;
	public GameObject owner = null;

	public float Radians (float angle) {
		return angle * Mathf.PI / 180.0f;
	}
    public float Length (Vector3 v) {
        return Mathf.Sqrt (v.x * v.x + v.y * v.y + v.z * v.z);
    }
	public float Constrain (float value, float min, float max) {
		return Mathf.Max (min, Mathf.Min (value, max));
	}
    public Vector3 Normalize (Vector3 v) {
        float leng = Length(v);
        float num = 1 / leng;
        v *= num;
        return v;
    }
	public Vector3 Vertical(Vector3 origin, Vector3 v)
	{
		Vector3 unitV = Normalize(v);
		float vLength = Vector3.Dot(origin, unitV);
		unitV *= vLength;
		return origin - unitV;
	}

    public Vector3 AxisX () { return transform.rotation * Vector3.right; }
    public Vector3 AxisY () { return transform.rotation * Vector3.up; }
    public Vector3 AxisZ () { return transform.rotation * Vector3.forward; }

    public Vector3 Direction () {
        Vector3 v = Vector3.zero;
        if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) { v.y++; }
        if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) { v.y--; }
        if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) { v.x--; }
        if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) { v.x++; }
        return v = v != Vector3.zero ? Normalize (v) : Vector3.zero;
    }
	public 	Vector3 BezierCurve (int count, int f, Vector3 s, Vector3 c1, Vector3 c2, Vector3 e) {
		float t = (float)count / (float)f;
		Vector3 v = (1 - t) * (1 - t) * (1 - t) * s + 3 * (1 - t) * (1 - t) * t * c1 + 3 * (1 - t) * t * t * c2 + t * t * t * e;
		return v;
	}


    public Quaternion RotationX (float angle) {
		return Quaternion.AngleAxis (angle * 360, Vector3.right);
	}
	public Quaternion RotationY (float angle) {
		return Quaternion.AngleAxis (angle * 360, Vector3.up);
	}
	public Quaternion RotationZ (float angle) {
		return Quaternion.AngleAxis (angle * 360, Vector3.forward);
	}
	public Quaternion RotationXYZ (float angle) {
		return RotationX(angle) * RotationY(angle) * RotationZ(angle);
	}

	public void IsDelete () {
		Destroy (gameObject);
	}
}
