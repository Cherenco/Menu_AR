using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter{
	/// <summary>
	/// 年齢
	/// 0:18 - 29
	/// 1:30 - 49
	/// 2:50 - 69
	/// </summary>
	public static int age = -1;

	/// <summary>
	/// 食事時間
	/// 0:朝
	/// 1:昼
	/// 2:夜
	/// </summary>
	public static int time = -1;

	/// <summary>
	/// 性別
	/// 0:男
	/// 1:女
	/// </summary>
	public static int sex = -1;

	/// <summary>
	/// 上限カロリー
	/// </summary>
	public static int cal = -1;

	public static int eatCal = 0;

	/// <summary>
	/// 言語選択
	/// 0:日本語
	/// 1:英語
	/// </summary>
	public static int language = 0;
	public static float weight = -1.0f;
}
