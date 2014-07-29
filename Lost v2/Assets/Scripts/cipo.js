#pragma strict
var playerObject : GameObject;
var canClimb = false;
var speed : float = 1;
 
function Start () {
    playerObject = GameObject.FindGameObjectWithTag("perdido");
}
 
 function OnTriggerEnter (other : Collider) {
		if(other.gameObject == playerObject){
        canClimb = true;
    }
	}
 
function OnTriggerExit (other : Collider) {
		if(other.gameObject == playerObject){
        canClimb = false;
    }
	}
	

function Update () {
    if(canClimb){
        if(Input.GetKey(KeyCode.W)){
            playerObject.transform.Translate (Vector3(0,1,0) * Time.deltaTime*speed);
        }
        if(Input.GetKey(KeyCode.S)){
            playerObject.transform.Translate (Vector3(0,-1,0) * Time.deltaTime*speed);
        }
    }
}