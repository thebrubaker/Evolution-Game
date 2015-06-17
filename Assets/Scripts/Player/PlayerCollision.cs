using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {



	void Start () {

	}

	void OnCollisionEnter2D (Collision2D collision) {

		// get collision object
		GameObject collisionObject = collision.gameObject;

		// check if object is food
		if (collisionObject.name == "Food(Clone)") {
			GameObject food = collisionObject;

			float foodEnergy = food.GetComponent<FoodAttributes>().energy;
			float playerEnergy = GetComponent<PlayerAttributes>().energy;

			// add food energy to player
			GetComponent<PlayerAttributes>().energy = playerEnergy + foodEnergy;

			Destroy(food);

		}
	}
	
}
