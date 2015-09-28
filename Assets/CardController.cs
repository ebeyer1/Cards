using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {
	
	public GameObject cardPrefab;
	private static int activeCards = 0;
	
	void Awake() {
		var iter = 0;
		var materials = Resources.LoadAll (string.Empty); // load all resources in subdir that are materials.
		// linq.where(o => o is Material);
		foreach (var material in materials) {
			GameObject card = Instantiate (cardPrefab, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			card.GetComponent<Renderer>().material = (material as Material);
			card.transform.rotation = Quaternion.Euler (new Vector3 (270, 0, 0));
			var currPositionValue = iter++ / 10.0f;
			card.transform.position = new Vector3 (currPositionValue-5f, currPositionValue-1.5f, currPositionValue);
			card.AddComponent<BoxCollider> ();
			card.AddComponent<CardScript> (); // Add custom script for custom behavior / properties
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void IncrementActiveCards() {
		++activeCards;
	}

	public static void DecrementActiveCards() {
		--activeCards;
	}

	public static int ActiveCardsCount() {
		return activeCards;
	}
}
