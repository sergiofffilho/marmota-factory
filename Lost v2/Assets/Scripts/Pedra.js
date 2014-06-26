#pragma strict
var velocidadePedra : float;

function Start () {
velocidadePedra = 60 * Time.deltaTime;
transform.Translate(0, 0, velocidadePedra);

}

function OnCollisionEnter(collision: Collision)
{
	Destroy(gameObject);

}