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
	public bool podeAtirar=true;
	public GameObject projetil;
	public Transform soin;
	private Animator animator;
	private float tempoTiro;
	public float time = 0;

	private Vidas vida;

	// Use this for initialization
	void Start () {

		animator = soin.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time % 2 != 0) {
			podeAtirar=true;
		}

	}
				
	IEnumerator OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.tag == "perdido") {
			//Debug.Log(time);
			if(time > 7){
				//Debug.Log("entrou");
				animator.SetBool("atirando",true);
				time = 0;
				yield return new WaitForSeconds(0.5f);
				Instantiate(projetil, transform.position, transform.rotation);

				podeAtirar=false;
			}
			//animator.SetTrigger("atirando2");
			time+=Time.deltaTime;


		}
	}
}
