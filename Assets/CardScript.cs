using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour {

	private bool isCardFlipped;
	private Vector3 initialPosition;
	private Vector3 startingRotation;
	public Vector3 targetRotation;
	public Vector3 targetPosition;
	private float _rotationSpeed = 7f;

	private Vector3 prevPos;
	private bool hoverEntered = false;

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

			float x = -5f + (CardController.ActiveCardsCount() * 2);
			//float z = CardController.ActiveCardsCount() * -.1f;

			targetPosition = new Vector3(x,2f,0f);
			CardController.IncrementActiveCards();

			StartCoroutine(SwitchCardFlippedBool());
		}
		else {
			startingRotation = transform.rotation.eulerAngles;

			targetRotation = new Vector3(270f, 0f, transform.rotation.z);
			CardController.DecrementActiveCards();

			targetPosition = initialPosition;

			StartCoroutine(SwitchCardFlippedBool());
		}
	}

	void OnMouseEnter() 
	{
		if (isCardFlipped && !hoverEntered) {
			prevPos = transform.position;
			targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
			hoverEntered = true;
		}
	}

	void OnMouseExit() {
		if (isCardFlipped && hoverEntered) {
			//targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
			targetPosition = prevPos;
			hoverEntered = false;
		}
	}

	private IEnumerator SwitchCardFlippedBool() {
		yield return new WaitForSeconds (1);
		isCardFlipped = !isCardFlipped;
	}
}
