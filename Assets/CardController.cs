using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {
	
	public GameObject cardPrefab;
	
	void Awake() {
		var iter = 0;
		var materials = Resources.LoadAll (string.Empty); // load all resources in subdir that are materials.
		// linq.where(o => o is Material);
		foreach (var material in materials) {
			GameObject card = Instantiate (cardPrefab, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			card.renderer.material = (material as Material);
			card.transform.rotation = Quaternion.Euler (new Vector3 (270, 0, 0));
			var currPositionValue = iter++ / 10.0f;
			card.transform.position = new Vector3 (currPositionValue-5f, currPositionValue-1.5f, currPositionValue);
			card.AddComponent<BoxCollider> ();
			card.AddComponent<CardScript> ();
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
