using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	//得点表示するテキスト
	private GameObject ScoreText;

	//得点加算用変数
	public int ScoreCount;

	// Use this for initialization
	void Start () {

		//シーンのScoreTextオブジェクトを取得
		this.ScoreText = GameObject.Find("ScoreText");

}
	
	// Update is called once per frame
	void Update () {



	}

		//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision collision) {

		// タグによって得点を変える
		if (collision.gameObject.tag == "SmallStarTag") {
			ScoreCount = ScoreCount + 10;
		} else if (collision.gameObject.tag == "LargeStarTag") {
			ScoreCount = ScoreCount + 30;
		} else if (collision.gameObject.tag == "SmallCloudTag") {
			ScoreCount = ScoreCount + 20;
		} else if (collision.gameObject.tag == "LargeCloudTag") {
			ScoreCount = ScoreCount + 50;
		}

		//得点を表示
		this.ScoreText.GetComponent<Text> ().text = ScoreCount.ToString();	
	}

}
