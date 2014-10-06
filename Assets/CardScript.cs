using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour {

	private bool isCardFlipped;
	private float initialZPosition;
	private Vector3 startingRotation;
	public Vector3 targetRotation;
	private float _rotationSpeed = 7f;

	// Use this for initialization
	void Start () {
		initialZPosition = this.transform.position.z;
		startingRotation = transform.rotation.eulerAngles;
		targetRotation = transform.rotation.eulerAngles;
	}

	void Update() {
		// takes me from current to destination
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * _rotationSpeed);
	}

	void OnMouseUp() {
		if (!isCardFlipped) {
			startingRotation = transform.rotation.eulerAngles;

			targetRotation = new Vector3(270f, 180f, transform.rotation.z);

			transform.position = new Vector3(transform.position.x, transform.position.y, 0.2f);

			isCardFlipped = true;
		}
		else {
			startingRotation = transform.rotation.eulerAngles;

			targetRotation = new Vector3(270f, 0f, transform.rotation.z);

			transform.position = new Vector3(transform.position.x, transform.position.y, initialZPosition);

			isCardFlipped = false;
		}
	}
}
