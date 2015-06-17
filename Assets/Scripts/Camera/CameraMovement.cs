using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public GameObject player;
	public GameObject background;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	private float minX;
	private float minY;
	private float maxX;
	private float maxY;
	private Vector3 backgroundBounds;
	private float cameraWidth;
	private float cameraHeight;

	private float playerAwareness;

	void Start() {
		playerAwareness = player.GetComponent<PlayerAttributes> ().awareness;
		Camera.main.orthographicSize = playerAwareness;
		cameraHeight = Camera.main.orthographicSize * 2.0f;
		cameraWidth  = cameraHeight * Screen.width / Screen.height;
		backgroundBounds = background.GetComponent<Renderer> ().bounds.extents;
		minX = cameraWidth / 2 - backgroundBounds.x;
		maxX = backgroundBounds.x - cameraWidth / 2;
		minY = cameraHeight / 2 - backgroundBounds.y;
		maxY = backgroundBounds.y - cameraHeight / 2;
	}

	void Update () {
		Vector3 currentLocation = new Vector3 (
			transform.position.x, 
			transform.position.y, 
			transform.position.z
		);
		Vector3 targetLocation = new Vector3 (
			Mathf.Clamp(player.transform.position.x, minX, maxX), 
			Mathf.Clamp(player.transform.position.y, minY, maxY), 
			transform.position.z
		);
		transform.position = Vector3.SmoothDamp(
			currentLocation, 
			targetLocation, 
			ref velocity, 
			smoothTime
		);
		playerAwareness = player.GetComponent<PlayerAttributes> ().awareness;
		Camera.main.orthographicSize = playerAwareness;
	}

}
