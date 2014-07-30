using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
	IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(5);
		print(Time.time);
	}
}

public class Soin : MonoBehaviour {
	public GameObject projetil;
	public Transform soin;
	private Animator animator;
	private float tempoTiro;

	private Vidas vida;

	// Use this for initialization
	void Start () {

		animator = soin.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
				
	IEnumerator OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.tag == "perdido") {

			if(Time.time % 2 == 0){
				animator.SetBool("atirando",true);
				yield return new WaitForSeconds(0.5f);
				Instantiate(projetil, transform.position, transform.rotation);
				//animator.SetTrigger("atirando2");
		}


	}
	

}
}
