using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {

	public float energy = 5f;
	public float speed = 100f;
	public float metabolism = -1f;
	public float awareness = 2f;
	public float spawnSize = 10f;
	public float fear = 10f;
	public float empathy = 10f;
	
	private float size;
	private float mass;
	private float velocity;
	
	private float maxEnergy = 500f;

	// Use this for initialization
	void Start () {
		updateSizeMass ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 playerVelocity = GetComponent<Rigidbody2D> ().velocity;
		velocity = Mathf.Abs(playerVelocity.x + playerVelocity.y);
		energy = Mathf.Clamp (
			energy + ((metabolism * mass) + (metabolism * awareness) + (metabolism * velocity)) * Time.deltaTime,
			0f,
			maxEnergy
		);
		updateSizeMass ();
	}

	void updateSizeMass() {
		size = energy / maxEnergy;
		mass = energy / 100f;
		transform.localScale = new Vector3 (size, size, transform.localScale.z);
		GetComponent<Rigidbody2D> ().mass = mass;
	}
}
