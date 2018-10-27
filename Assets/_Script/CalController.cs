using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class CalController : MonoBehaviour {
	[SerializeField]	//時間帯ごとのカロリーリスト
	List<SexList> maxList = new List<SexList> ();

	[SerializeField]
	List<GameObject> labelList = new List<GameObject> ();
	[SerializeField]
	Text weightText;

	public void StartButton(){
		if (labelList [0].GetComponent<Text> ().text == "性別" || labelList [0].GetComponent<Text> ().text == "年齢" || weightText.text == "") {
			return;
		} else {
			if (labelList [0].GetComponent<Text> ().text == "男性") {
				ReturnSex (0);
			} else {
				ReturnSex (1);
			}

			if (labelList [1].GetComponent<Text> ().text == "10代以下") {
				ReturnAge (20);
			} else if (labelList [1].GetComponent<Text> ().text == "20代") {
				ReturnAge (20);
			} else if (labelList [1].GetComponent<Text> ().text == "30代") {
				ReturnAge (30);
			} else if (labelList [1].GetComponent<Text> ().text == "40代") {
				ReturnAge (40);
			} else if (labelList [1].GetComponent<Text> ().text == "50代") {
				ReturnAge (50);
			} else if (labelList [1].GetComponent<Text> ().text == "60代以上") {
				ReturnAge (60);
			}
			ReturnTime ();
			Parameter.weight = float.Parse (weightText.text);

			Parameter.cal = maxList [Parameter.age].sexList [Parameter.sex].calList [Parameter.time];
		}

		SceneManager.LoadScene ("AR");

		Debug.Log((1000 / (1.05f * 8.3f * Parameter.weight)).ToString());
	}

	public void LanguageButton(int b){
		Parameter.language = b;
	}

	/// <summary>
	/// maxListに返す年齢を判断するメソッド
	/// </summary>
	/// <returns>maxListに入れる数値</returns>
	/// <param name="age">現在の年齢</param>
	int ReturnAge(int age){
		int tmpAge = -1;

		if (age >= 18 && age <= 29) {
			tmpAge = 0;
			Parameter.age = 0;
		} else if (age >= 30 && age <= 49) {
			tmpAge = 1;
			Parameter.age = 1;
		} else if (age >= 50 && age <= 69) {
			tmpAge = 2;
			Parameter.age = 2;
		} else {
			Debug.Log ("Age error");
		}
		return tmpAge;
	}

	/// <summary>
	/// timeListに返す時刻を判断するメソッド
	/// </summary>
	/// <returns>TimeListに入れる数値</returns>
	/// <param name="time">現在の時刻</param>
	void ReturnTime(){
		int tmpTime = -1;
		int nowTime = DateTime.Now.Hour;

		if (nowTime >= 3 && nowTime < 10) {
			tmpTime = 0;
			Parameter.time = 0;
		} else if (nowTime >= 10 && nowTime < 19) {
			tmpTime = 1;
			Parameter.time = 1;
		} else if (nowTime >= 19 && nowTime <= 24) {
			tmpTime = 2;
			Parameter.time = 2;
		} else if (nowTime >= 0 && nowTime < 3) {
			tmpTime = 2;
			Parameter.time = 2;
		} else {
			Debug.Log ("Time error");
		}
	}

	/// <summary>
	/// SexListに入れる数値を判断するメソッド
	/// </summary>
	/// <returns>実際の性別</returns>
	/// <param name="sex">性別</param>
	int ReturnSex(int sex){
		Parameter.sex = sex;
		return sex;
	}
		
}
[System.Serializable]
public class SexList{	//性別
	public List<CalList> sexList = new List<CalList> ();
}
[System.Serializable]
public class CalList{	//カロリー
	public List<int> calList=new List<int>();
}
