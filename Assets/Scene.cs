using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scene : MonoBehaviour {

	private List<GameObject> spheres = new List<GameObject>();
	private float decayFactor = 0.1f;
	public static float growthFactor = 2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		List<int> toRemove = new List<int>();
		foreach(GameObject sphere in spheres){
			float currentScale = sphere.transform.localScale.x;
			if(currentScale < 1){
				toRemove.Add(spheres.IndexOf(sphere));
			}else{
				float newScale = currentScale - decayFactor;
				sphere.transform.localScale = new Vector3(newScale, newScale, newScale);
			}
		}
		foreach(int index in toRemove){
			DestroyImmediate(spheres[index]);
			spheres.RemoveAt(index);
		}
	}

	void OnMouseDown() {
		GameObject newSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		float initArea = 30;
		newSphere.transform.localPosition = new Vector3(Random.Range(-initArea, initArea), Random.Range(-initArea, initArea), 50);

		float initScale = 1 + Random.Range(decayFactor * 20, decayFactor * 120);
		newSphere.transform.localScale = new Vector3(initScale, initScale, initScale);
		newSphere.AddComponent<SphereObject>();

		spheres.Add(newSphere);
	}
}
