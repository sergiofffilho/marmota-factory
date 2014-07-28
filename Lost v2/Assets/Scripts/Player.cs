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

	void Start () {

		animator = player.GetComponent<Animator> ();

	}
	
	void Update () {
		Movimentar();

	}

	void Movimentar(){

		isChao = Physics2D.Linecast(this.transform.position, chao.position, 1<<LayerMask.NameToLayer("Frente"));

		animator.SetFloat("andar", Mathf.Abs(Input.GetAxis("Horizontal")));
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

		if (Input.GetButtonDown ("Jump") && isChao && !pulando) {
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
}
