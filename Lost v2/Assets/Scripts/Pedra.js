#pragma strict
var velocidadePedra : float;
var posicaoPerdido;
var posicaoPedra;
var posicao;
var smooth : float = 5.0;



function Start () {

velocidadePedra = 1;
posicaoPerdido = ((GameObject.FindGameObjectWithTag("perdido").transform.position - this.transform.position) * velocidadePedra * Time.deltaTime);
posicaoPedra = (GameObject.FindGameObjectWithTag("perdido").transform.position - this.transform.position);
}

function Update() {
	Tiro();
	//print(GameObject.FindGameObjectWithTag("perdido").transform.position.x - this.transform.position.x);
	if(GameObject.FindGameObjectWithTag("perdido").transform.position.x - this.transform.position.x > 50 || GameObject.FindGameObjectWithTag("perdido").transform.position.x - this.transform.position.x < -50){
		Destroy(this.gameObject);
	}
}

function Tiro(){
	//transform.position = Vector3.Lerp(transform.position, posicaoPerdido, Time.deltaTime * smooth);
	//transform.position = GameObject.FindGameObjectWithTag("perdido").transform.position - this.transform.position;
	transform.Translate(posicaoPerdido, Space.World);
	//transform.Translate(posicaoPerdido);

}

function OnCollisionEnter2D(coll: Collision2D) {
	if (coll.gameObject.tag == "perdido")
		Destroy(this.gameObject);
}

