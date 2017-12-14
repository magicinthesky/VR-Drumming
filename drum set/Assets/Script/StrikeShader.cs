using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem{
	
	public class StrikeShader : MonoBehaviour {

		public Material Light;
		public Material Default;
	
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
	
		}
	
		void OnCollisionEnter(Collision col){
			GetComponent<Renderer> ().material = Light;
			Invoke ("goBack", 0.1f);
		}
	
		void goBack(){
			GetComponent<Renderer> ().material = Default;
		}
	}
}
