using UnityEngine;
using System.Collections;

public class PopulateFood : MonoBehaviour {

	public Transform food;

	void Start() {
		float x = -7f;
		for (int i = 0; i < 12; i++) {
			float y = -4.5f;
			x = Mathf.Clamp (x + Random.Range(0f,2.5f), -7f, 7f);
			for (int e = 0; e < 4; e++) {
				y = Mathf.Clamp (y + Random.Range(0f,4.5f), -4.5f, 4.5f);
				Instantiate (food, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}
	}
}
