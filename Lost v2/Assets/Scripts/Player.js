#pragma strict

var velocidade = 0.0;

function Start () {

}

function Update () {
	Movimentar();
}

function Movimentar (){
	if(Input.GetAxisRaw("Horizontal") > 0){
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);
		transform.eulerAngles = Vector2(0,0);
	}
	if(Input.GetAxisRaw("Horizontal") < 0){
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);
		transform.eulerAngles = Vector2(0,180);
	}
	
}