using UnityEngine;
using System.Collections;

public class Soin : MonoBehaviour {
	public GameObject projetil;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "perdido") {
			if(Time.time % 2 == 0){
				Instantiate(projetil, transform.position, transform.rotation);		
			}

		}
	}
}
