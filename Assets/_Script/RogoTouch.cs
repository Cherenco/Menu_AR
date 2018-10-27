using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RogoTouch : MonoBehaviour {
	
	int touchCount = 0;
	[SerializeField]
	Texture banana;
	[SerializeField]
	Texture shijimi;
	[SerializeField]
	GameObject Rogo;
	[SerializeField]
	GameObject rogoCanvas;


	void Update () {
		if (Touch ()) {
			switch (touchCount) {
			case 0:
				rogoCanvas.SetActive (true);
				touchCount++;
				break;
			case 1:
				break;
				Rogo.GetComponent<RawImage> ().texture = shijimi;
				touchCount++;
			case 2:
				rogoCanvas.SetActive (false);
				touchCount = 0;
				break;
			default:
				break;
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
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	public void Close(){
		Rogo.SetActive (false);
	}
}
