#pragma strict
var projetil 	: GameObject;

function Start () {

}

function Update () {
	Instantiate(projetil, transform.position, transform.rotation);	
}

