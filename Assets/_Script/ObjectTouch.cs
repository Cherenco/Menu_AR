using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTouch : MonoBehaviour {

	[SerializeField]
	List<GameObject> canvasList = new List<GameObject> ();
	[SerializeField]
	Text calText;
	[SerializeField]
	GameObject food;
	bool isCanvas = false;

	// Update is called once per frame
	void Update () {
		if (Touch ()) {
			for (int i = 0; i < this.canvasList.Count; i++) {
				canvasList [i].SetActive (isCanvas);
			}
		}
	}

	bool Touch(){
		if (Input.touchCount > 0) {
			for (int i = 0; i < Input.touchCount; i++) {
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began) {
					Ray ray = Camera.main.ScreenPointToRay (touch.position);
					RaycastHit hit = new RaycastHit ();
					if (Physics.Raycast (ray, out hit)) {
						if (hit.collider.gameObject == this.gameObject) {
							isCanvas = !isCanvas;
							calText.text = (food.GetComponent<Food> ().getFoodName () + "\n"
							+ food.GetComponent<Food> ().getFoodCal ().ToString () + " kcal\nwalk: " +
							food.GetComponent<Food> ().getExercise (0).ToString ("F1") + " h\nrun: " +
							food.GetComponent<Food> ().getExercise (1).ToString ("F1") + " h").ToString ();
							return true;
						}
					}
				}
			}
		}
		return false;
	}
}
