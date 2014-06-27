#pragma strict
var velocidadePedra : float;


function Start () {

velocidadePedra = 400 * Time.deltaTime;
//transform.Translate(velocidadePedra, 0, 0);

}
function Update() {
	transform.Translate(Vector2.right * velocidadePedra * Time.deltaTime);
	transform.eulerAngles = new Vector2 (0, 180);
}

function OnCollisionEnter(collision: Collision)
{
	Destroy(gameObject);

}