#pragma strict
var lookAtCamera:Camera;
var lookOnlyOnAwake:boolean;


function Start () {
	if(!lookAtCamera){
		lookAtCamera = Camera.main;
	}
	if(lookOnlyOnAwake){
		LookAtCamera();
	}
}

function Update () {
	if(!lookOnlyOnAwake){
		LookAtCamera();
	}
}

function LookAtCamera () {
	
	transform.LookAt(lookAtCamera.transform);
	
}