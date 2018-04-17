using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minMaxZoomscript : MonoBehaviour {
	public float maxScale;
	public float minScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = this.transform.localPosition;
		Vector3 localScale = this.transform.localScale;
		//Debug.Log(localScale);
		if(localScale.x > maxScale){
			Vector3 newScaleMax = new Vector3(maxScale,maxScale,maxScale);
			this.transform.localScale = newScaleMax;
		}
		if(localScale.x < minScale){
			Vector3 newScaleMin = new Vector3(minScale,minScale,minScale);
			this.transform.localScale = newScaleMin;
		}
		this.transform.localPosition = currentPos;
	}
}
