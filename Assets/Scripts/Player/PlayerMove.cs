using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 100.0F;
	
	void Start() {

	}

	void FixedUpdate() {
		float y = Input.GetAxis("Vertical") * speed;
		float x = Input.GetAxis("Horizontal") * speed;
		y *= Time.deltaTime;
		x *= Time.deltaTime;
		Rigidbody2D playerBody = GetComponent<Rigidbody2D>();
		playerBody.AddForce(new Vector2(x,y));
	}


}
