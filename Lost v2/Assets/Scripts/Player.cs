using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float velocidade;

	public Transform player;
	private Animator animator;

	public bool isChao;
	public float forca = 250;

	public float tempoPulo;
	public float puloDelay = 0.5f;
	public bool pulando;
	public Transform chao;

	public Transform Elevador;
	public bool Cipo = false;
	public bool Pendurado = false;
	public bool fixado = false;

	void Start () {

		animator = player.GetComponent<Animator> ();

	}
	
	void Update () {
		Movimentar();

	}

	void Movimentar(){

		isChao = Physics2D.Linecast(this.transform.position, chao.position, 1<<LayerMask.NameToLayer("Frente"));


		if (isChao) {
			animator.SetFloat("andar", Mathf.Abs(Input.GetAxis("Horizontal")));
		}else if(Pendurado) {
			
		}
		//animator.SetFloat("pulo", Mathf.Abs(Input.GetAxis("Vertical")));
		if(rigidbody2D.velocity.y < 0){
				animator.SetBool("pulo", true);
		}else{
			animator.SetBool("pulo", false);
		}
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
					transform.Translate (Vector2.right * (velocidade+0.5f) * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 0);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			transform.Translate (Vector2.right * (velocidade+0.5f) * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 180);
		}

		if (Input.GetAxisRaw ("Vertical") > 0 && Cipo && fixado) {
			Elevador.Translate (Vector2.up *velocidade * Time.deltaTime);
		}
		
		if (Input.GetAxisRaw ("Vertical") < 0 && Cipo && fixado) {
			Elevador.Translate (-Vector2.up * 2.5f * Time.deltaTime);
		}

		if (Input.GetButtonDown ("Jump") && isChao && !pulando) {
			rigidbody2D.AddForce(transform.up * forca);
			tempoPulo = puloDelay;
			animator.SetTrigger("pular");
			pulando = true;
		}else if (Input.GetButtonDown ("Jump") && Pendurado && !pulando) {
			rigidbody2D.AddForce(transform.up * forca);
			tempoPulo = puloDelay;
			animator.SetTrigger("pular");
			pulando = true; 
		}

		tempoPulo -= Time.deltaTime;

		if (tempoPulo <= 0 && isChao && pulando) {
			animator.SetTrigger("chao");
			pulando = false;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Cipo") {
			Cipo = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if ( Cipo ) {
			if (Input.GetAxisRaw ("Vertical") > 0) {
				Pendurado = true;
				if ( fixado==false ) {
					Elevador.position = transform.position;
					Elevador.Translate(-Vector2.up);
					Elevador.collider2D.isTrigger = false;
					fixado = true;
					
				}
			}
		} else {
			Cipo = false;
			Pendurado = false;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Cipo") {
			Cipo = false;
			Pendurado=false;
			Elevador.collider2D.isTrigger = true;
			fixado = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Elevador")
			pulando= false;
		
	}
}
