using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour {

	private bool isCardFlipped;
	private Vector3 initialPosition;
	private Vector3 startingRotation;
	public Vector3 targetRotation;
	public Vector3 targetPosition;
	private float _rotationSpeed = 7f;

	// Use this for initialization
	void Start () {
		initialPosition = this.transform.position;
		targetPosition = this.transform.position;
		startingRotation = transform.rotation.eulerAngles;
		targetRotation = transform.rotation.eulerAngles;
	}

	void Update() {
		// takes me from current to destination
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * _rotationSpeed);
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * _rotationSpeed);
	}

	void OnMouseUp() {
		if (!isCardFlipped) {
			startingRotation = transform.rotation.eulerAngles;

			targetRotation = new Vector3(270f, 180f, transform.rotation.z);

			targetPosition = new Vector3(0f,0f,0f);

			isCardFlipped = true;
		}
		else {
			startingRotation = transform.rotation.eulerAngles;

			targetRotation = new Vector3(270f, 0f, transform.rotation.z);

			targetPosition = initialPosition;

			isCardFlipped = false;
		}
	}
}
