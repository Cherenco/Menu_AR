using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArController : MonoBehaviour {
	[SerializeField]
	GameObject OrderCanvas;
	[SerializeField]
	GameObject warning;
	[SerializeField]
	GameObject foodPrefab;
	[SerializeField]
	GameObject content;
	/// <summary>
	/// ピザ
	/// エビフライ
	/// </summary>
	int[] foodArray = new int[]{ 0, 0, 0 };
	[SerializeField]
	Text calText;
	[SerializeField]
	GameObject calCanvas;
	bool isWarning = false;

	public void DeleteFood(int n){
		foodArray [n]--;
		foreach (Transform child in content.transform) {
			GameObject.Destroy (child.gameObject);
		}
		switch (n) {
		case 0:
			Parameter.eatCal -= 1000;
			break;
		case 1:
			Parameter.eatCal -= 250;
			break;
		case 2:
			Parameter.eatCal -= 300;
			break;
		default:
			break;
		}
		if (Parameter.cal > Parameter.eatCal) {
			isWarning = false;
			warning.SetActive (false);
		}
		OrderListClick ();
	}

	public void AddClick(int food){
		foodArray [food]++;
		switch (food) {
		case 0:
			Parameter.eatCal += 1000;
			break;
		case 1:
			Parameter.eatCal += 250;
			break;
		case 2:
			Parameter.eatCal += 300;
			break;
		default:
			break;
		}
		if (Parameter.cal < Parameter.eatCal) {
			isWarning = true;
			warning.SetActive (true);
			StartCoroutine (Blink ());
		}
	}
		
	IEnumerator Blink(){
		while (isWarning) {
			warning.SetActive (!warning.activeSelf);
			yield return new WaitForSeconds (1f);
		}
	}


	public void OrderListClick(){
		calText.text = Parameter.eatCal.ToString () + "kcal";
		OrderCanvas.SetActive (true);
		calCanvas.SetActive (true);
		int tmpCount = 0;
		for (int i = 0; i < foodArray.Length; i++) {
			for (int j = 0; j < foodArray [i]; j++) {
				tmpCount++;
			}
		}
		RectTransform rectContent = this.content.GetComponent<RectTransform> ();
		float foodSpace = rectContent.GetComponent<VerticalLayoutGroup> ().spacing;
		float foodHeight = foodPrefab.GetComponent<LayoutElement> ().preferredHeight;
		rectContent.sizeDelta = new Vector2 (0, (foodHeight + foodSpace) * tmpCount);
		for (int i = 0; i < foodArray.Length; i++) {
			for (int j = 0; j < foodArray [i]; j++) {
				GameObject tmpFood = (GameObject)Instantiate (foodPrefab);
				int tmpI = i;
				tmpFood.transform.SetParent (rectContent, false);
				tmpFood.transform.GetComponentInChildren<Button> ().onClick.AddListener (() => DeleteFood (tmpI));
				switch (i) {
				case 0:
					tmpFood.GetComponentInChildren<Text> ().text = "ピザ";
					break;
				case 1:
					tmpFood.GetComponentInChildren<Text> ().text = "エビフライ";
					break;
				case 2:
					tmpFood.GetComponentInChildren<Text> ().text = "ハンバーガー";
					break;
				default:
					Debug.Log ("content error");
					break;
				}
			}
		}
	}
	public void CloseOrderCanvas(){
		foreach (Transform child in content.transform) {
			GameObject.Destroy (child.gameObject);
		}
		OrderCanvas.SetActive (false);
		calCanvas.SetActive (false);
	}
}
