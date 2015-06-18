using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private GameObject collisionObject;

	private float playerEnergy;
	private float foodEnergy;
	private float playerDrag;

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Trigger Enter");
		// get collision object
		collisionObject = collider.gameObject;

		// check if object is food
		if (collisionObject.name == "Food(Clone)") {
			playerDrag = GetComponent<Rigidbody2D> ().drag;
			Debug.Log(playerDrag);
			GetComponent<Rigidbody2D> ().drag = 10.0f;
			foodEnergy = collisionObject.GetComponent<FoodAttributes> ().energy;
			playerEnergy = GetComponent<PlayerAttributes> ().energy;
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		float transferEnergy = foodEnergy * Time.deltaTime / 4.0f;
		GetComponent<PlayerAttributes> ().energy += transferEnergy;
		collisionObject.GetComponent<FoodAttributes> ().energy += -transferEnergy;
		if (collisionObject.GetComponent<FoodAttributes> ().energy <= 0) {
			Destroy(collisionObject);
		}
	}

	void OnTriggerExit2D() {
		Debug.Log ("Trigger Exit");
		Debug.Log(playerDrag);
		GameObject collisionObject = null;
		foodEnergy = 0f;
		playerEnergy = 0f;
		GetComponent<Rigidbody2D> ().drag = playerDrag;
		playerDrag = 0f;
	}
	
}
