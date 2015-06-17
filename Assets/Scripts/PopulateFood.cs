using UnityEngine;
using System.Collections;

public class PopulateFood : MonoBehaviour {

	public Transform food;
	public GameObject background;

	public float seedX;
	public float seedY;

	private Vector3 bounds;

	void Start() {
		bounds = background.GetComponent<Renderer> ().bounds.extents;
		Vector3 min = new Vector3 (-bounds.x, -bounds.y, bounds.z);
		Vector3 max = new Vector3 (bounds.x, bounds.y, bounds.z);
		for (float x = min.x; x < max.x; x = Mathf.Clamp (x + Random.Range(0.2f, seedX), min.x, max.x)) {
			for (float y = min.y; y < max.y; y = Mathf.Clamp (y + Random.Range(0.2f, seedY), min.y, max.y)) {
				Instantiate (food, new Vector3 (x, y, 0.0f), Quaternion.identity);
			}
		}
	}
}
