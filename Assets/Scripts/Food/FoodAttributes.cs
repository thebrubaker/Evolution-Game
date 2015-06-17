using UnityEngine;
using System.Collections;

public class FoodAttributes : MonoBehaviour {

	public float energy;
	public float growth;
	public float mass;
	public float size;
	
	// Use this for initialization
	void Start () {
		growth = Random.Range (0.01f, 0.03f);
		mass = Random.Range(0.5f, 3f);
		energy = mass;
		size = mass / 100f;

		GetComponent<Rigidbody2D> ().mass = mass;
		transform.localScale = new Vector3 (
			size,
			size,
			transform.localScale.z
			);
	}
	
	// Update is called once per frame
	void Update () {
		energy += growth * Time.deltaTime;
		mass = energy;
		size = mass / 100f;
		transform.localScale = new Vector3 (
			size,
			size,
			transform.localScale.z
			);
	}
}
