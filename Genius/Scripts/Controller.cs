using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	ArrayList sequenciaUsuario = new ArrayList();
	ArrayList sequenciaMaquina = new ArrayList();
	int i = 0;


	void Start () {

		GameObject.Find("Pointamarelo").SendMessage("LoopJogo");
	}

	void Update (){
		Debug.Log (i);
		if (i >= 10) {
			GameObject.Find ("Pointamarelo").SendMessage ("LoopJogo");
			GameObject.Find ("Pointverde").SendMessage ("LoopJogo");
			GameObject.Find ("Pointazul").SendMessage ("LoopJogo");
			GameObject.Find ("Pointvermelho").SendMessage ("LoopJogo");
		}
		i++;


	}

	IEnumerator gerarSequencia(){
		int n = Random.Range (1, 5);
		Debug.Log("AQUI");
		if(n==1){
			sequenciaMaquina.Add("verde");
			for (int i=0; i<sequenciaMaquina.Count; i++) {
				GameObject.Find("Point"+sequenciaMaquina[i]).SendMessage("receberTagMaquina", sequenciaMaquina[i]);
				yield return new WaitForSeconds(1.5f);
			}

		}
		else if (n==2){
			sequenciaMaquina.Add("vermelho");
			for (int i=0; i<sequenciaMaquina.Count; i++) {
				GameObject.Find("Point"+sequenciaMaquina[i]).SendMessage("receberTagMaquina", sequenciaMaquina[i]);
				yield return new WaitForSeconds(1.5f);
			}
		}
		else if (n==3){
			sequenciaMaquina.Add("azul");
			for (int i=0; i<sequenciaMaquina.Count; i++) {
				GameObject.Find("Point"+sequenciaMaquina[i]).SendMessage("receberTagMaquina", sequenciaMaquina[i]);
				yield return new WaitForSeconds(1.5f);
			}
		}
		else if (n==4){
			sequenciaMaquina.Add("amarelo");
			for (int i=0; i<sequenciaMaquina.Count; i++) {
				GameObject.Find("Point"+sequenciaMaquina[i]).SendMessage("receberTagMaquina", sequenciaMaquina[i]);
				yield return new WaitForSeconds(1.5f);
			}
		}

	}

	/*void compararSequencias(){
		for (int i=0; i<sequenciaUsuario.Count; i++) {
			if(sequenciaUsuario[1].Equals(sequenciaMaquina[1])){
				Debug.Log("acertou");
			} else{
				Debug.Log("errou");
			}
		}
	}*/

	void print () {
		if (Input.GetMouseButtonDown (0)) {				
			foreach (string tag in sequenciaUsuario) {
				Debug.Log (tag+" usu");
			}
			foreach (string tag in sequenciaMaquina) {
				Debug.Log (tag+" maq");
			}
		}
	}

	void adicionarTag(string tag){
		sequenciaUsuario.Add (tag);
	}

	IEnumerator tempoEspera(){
		yield return new WaitForSeconds (1.5f);		
	}


}
