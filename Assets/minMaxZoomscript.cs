using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;
using TouchScript.Gestures;

public class minMaxZoomscript : MonoBehaviour {
	public float maxScale;
	public float minScale;
	public float scaleCorrectSpeed;
	private Vector2 pivotPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TransformGesture gesture = this.GetComponent<TransformGesture>();
		var state = gesture.State;
		if(state.Equals(TransformGesture.GestureState.Changed)){
			savePivotPoint(gesture);
		}
		if(state.Equals(TransformGesture.GestureState.Idle)){
			enforceBoundaries();
		}

		
	}
	private void savePivotPoint(TransformGesture t){
		Vector2 screenPos = t.ScreenPosition;
		Vector2 localPos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(this.GetComponent<RectTransform>(),screenPos,Camera.main,out localPos);
		pivotPoint = Rect.PointToNormalized(this.GetComponent<RectTransform>().rect, localPos);
		//this.GetComponent<RectTransform>().pivot = pivotPoint;
		Debug.Log(pivotPoint);
	}

	void enforceBoundaries(){
		Vector3 currentPos = this.transform.localPosition;
		Vector3 localScale = this.transform.localScale;
		Vector3 newScale = new Vector3(minScale,minScale,minScale);
		//Debug.Log(localScale);
		if(localScale.x > maxScale){
			newScale = new Vector3(maxScale,maxScale,maxScale);
			moveToDesiredScale(newScale);
		}
		if(localScale.x < minScale){
			newScale = new Vector3(minScale,minScale,minScale);
			moveToDesiredScale(newScale);
		}
		this.transform.localPosition = currentPos;
	}

	private void moveToDesiredScale(Vector3 desiredScale){
		//Vector2 originalPivot = this.GetComponent<RectTransform>().pivot;
		this.GetComponent<RectTransform>().pivot = pivotPoint;
		//transform.localScale = Vector3.Lerp (transform.localScale, desiredScale, scaleCorrectSpeed * Time.deltaTime);
		transform.localScale = desiredScale;
		//this.GetComponent<RectTransform>().pivot = originalPivot;
	}

	void boundarieCrossingCounteract(){
		
	}
}
