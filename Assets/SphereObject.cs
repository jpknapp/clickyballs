using UnityEngine;
using System.Collections;

public class SphereObject : MonoBehaviour {

	float growthFactor = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float currentScale = transform.localScale.x;
		Color newColor = new Color(1 - currentScale/20, currentScale/20, currentScale/25);

		renderer.material.color = newColor;
	}

	void OnMouseDown(){
		Debug.Log("sphere clicked");
		float currentScale = transform.localScale.x;
		currentScale += Scene.growthFactor;
		transform.localScale = new Vector3(currentScale, currentScale, currentScale);
	}
}
