using UnityEngine;
using System.Collections;

public class AssembyLineIllusion : MonoBehaviour {
 	Renderer rend;
	public float speed=1.0f;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.fixedTime * speed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));

	
	}
}
