using UnityEngine;
using System.Collections;

public class BlobbOnLore : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player.transform.position = this.transform.position;
	}
}
