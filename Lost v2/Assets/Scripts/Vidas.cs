using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour {

	public Texture2D[] vidaAtual;
	private int vidas;
	private int contador;

	void Start () {
	
		guiTexture.texture = vidaAtual [0];
		vidas = vidaAtual.Length;

	}
	
	// Update is called once per frame
	void Update () {
	

	}

	public bool ExcluirVida(){
		if (vidas < 0) {
			return false;
		}
		if (contador < vidas - 1) {
			contador += 1;
			guiTexture.texture = vidaAtual [contador];
			return true;
		
		} else {
			return false;
		}

	}
}
