using UnityEngine;
using System.Collections;

public class Genius : MonoBehaviour {

	//Variavel que verifica a area de colisao com cada cubo.
	public bool ascender;
	bool maquina = true;

	// Use this for initialization
	void Start () {

	}

	void Update(){

		}

	// Update is called once per frame
	void LoopJogo () {

		if (maquina) {
			maquina = false;
			GameObject.Find ("Pai").SendMessage ("gerarSequencia");

		} else {

			if (ascender) {

				if (Input.GetMouseButtonDown (0)) {	
					GameObject.Find ("Pai").SendMessage ("adicionarTag", gameObject.tag);
					light.intensity = 1;										
					GameObject.Find ("Pai").SendMessage ("print");
					//GameObject.Find("Pai").SendMessage("compararSequencias");
					audio.Play();
					maquina = true;
					StartCoroutine(tempoEspera());						
				}
			}
		}
	}

	void receberTagMaquina(string tag){
		light.intensity = 1;
		audio.Play();
		StartCoroutine (tempoEspera ());
	}

	public void OnMouseEnter(){
		ascender = true;
		
	}
	
	void OnMouseExit(){
		ascender = false;
	}

	IEnumerator tempoEspera(){
		yield return new WaitForSeconds (1f);
		light.intensity = 0;

	}
	
}
