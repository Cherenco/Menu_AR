using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	[SerializeField]
	public int foodCal;
	[SerializeField]
	public string name;
	//getter
	public int getFoodCal(){
		return this.foodCal;
	}
	public string getFoodName(){
		return this.name;
	}

	public float getExercise(int exercise){
		float tmpExercise = -1.0f;

		if (exercise == 0) {
			tmpExercise = 3.0f;
		} else if (exercise == 1) {
			tmpExercise = 8.3f;
		}

		return (this.foodCal / (1.05f * tmpExercise * Parameter.weight));
	}
}
