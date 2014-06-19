using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	
	public Transform player;
	public float smooth = 0;
	public Vector2 velocidade;
	
	void Start () {
		velocidade = new Vector2 (0.5f, 0.5f);
	}
	
	void Update () {
		
		Vector2 novaPosicao = Vector2.zero;
		
		novaPosicao.x = Mathf.SmoothDamp (transform.position.x, player.position.x, ref velocidade.x, smooth);
		novaPosicao.y = Mathf.SmoothDamp (transform.position.y, player.position.y, ref velocidade.y, smooth);
		
		Vector3 novaPosicao3d = new Vector3 (novaPosicao.x, novaPosicao.y, transform.position.z);
		
		transform.position = Vector3.Slerp (transform.position, novaPosicao3d, Time.time);
	}
}
