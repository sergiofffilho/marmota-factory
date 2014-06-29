using UnityEngine;
using System.Collections;

public class Soin : MonoBehaviour {
	public GameObject projetil;

	public Transform soin;
	private Animator animator;
	// Use this for initialization
	void Start () {

		animator = soin.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

	}
				
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "perdido") {

			if(Time.time % 2 == 0){
				animator.SetBool("atirando2",true);
				//animator.SetTrigger("atirando2");
				Instantiate(projetil, transform.position, transform.rotation);		
			
		}
	}

}
}
