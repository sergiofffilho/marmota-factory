using UnityEngine;
using System.Collections;

public class Cobra : MonoBehaviour {
	public float velocidade;
	public bool esquerda;
	private Vidas vida;

	// Use this for initialization
	void Start () {
		velocidade = 1;
		esquerda = true;
	}
	
	// Update is called once per frame
	void Update () {
		Movimentar();
	}

	void Movimentar () 
	{


		if(esquerda == true){
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
			//esquerda = false;
		}else{
			if(esquerda == false){
				transform.Translate(Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 0);
				//esquerda = true;
			}
		}

	}

	void trocarLado(){
		if(esquerda){
			esquerda = false;
		}else{
			esquerda = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "colisorCobra") {
			trocarLado();
		}
	}

/*	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "perdido") {
			vida = GameObject.FindGameObjectWithTag("Vidas").GetComponent<Vidas>() as Vidas;

			if (vida.ExcluirVida()){
				Destroy(gameObject);
			}
		}
	}*/

}
