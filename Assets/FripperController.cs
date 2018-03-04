using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {


	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;

	private float flickAngle = -20;

//発展課題
	private int left_ID = -9;
	private int right_id = -9;

	// Use this for initialization
	void Start () {

		this.myHingeJoint = GetComponent<HingeJoint>();

		SetAngle(this.defaultAngle);

	}
	
	// Update is called once per frame
	void Update () {




		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}


		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}


//発展課題
		foreach (Touch t in Input.touches) {
			if (t.position.x <= (Screen.width / 2)) {
				if (t.phase == TouchPhase.Began && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
					left_ID = t.fingerId;
//					Debug.Log (Screen.width);

				}

				if (t.phase == TouchPhase.Ended && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
					left_ID = -9;
				}					

//右・左のタップ時にIDを取得、反対画面に移動判定でIDを判定して下ろす
				if (t.phase == TouchPhase.Moved) {
					if(right_id == t.fingerId){
						SetAngle (this.defaultAngle);
						right_id = -9;
				//	Debug.Log (t.fingerId);
					}
				}
			}

			if (t.position.x > (Screen.width / 2)) {
				if (t.phase == TouchPhase.Began && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
					right_id = t.fingerId;
				}

				if (t.phase == TouchPhase.Ended && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
					right_id = -9;
				}

				//タッチのしたまま、画面右側に移動したら、フリップを下す
				if (t.phase == TouchPhase.Moved) {
					if(left_ID == t.fingerId){
						SetAngle (this.defaultAngle);
						left_ID = -9;
						//	Debug.Log (t.fingerId);
					}
				}
			
			}
		}
	}


	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
		
	}
}
