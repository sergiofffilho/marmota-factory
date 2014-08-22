using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour {

	public Texture2D[] vidaAtual;
	public int controladorvidas;
	public int contador;
	public int vidas = 3;

	void Start () {
	
		guiTexture.texture = vidaAtual [0];
		controladorvidas = vidaAtual.Length;

	}
	
	// Update is called once per frame
	void Update () {
	

	}

	public bool ExcluirVida(){

		if (controladorvidas < 0) {
			vidas -= 1;
			return false;

		}
		if (contador < controladorvidas - 1) {
			contador += 1;
			vidas -= 1;
		
			guiTexture.texture = vidaAtual [contador];
			return true;
		
		} else {
			vidas -= 1;
			return false;
		}

	}
}
