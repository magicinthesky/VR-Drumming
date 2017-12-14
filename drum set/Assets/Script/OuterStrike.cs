using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem{

	public class OuterStrike : MonoBehaviour {

		public Material Light;
		public Material Default;

		AudioSource[] tomsound;
		AudioSource sound1;
		AudioSource sound2;
		public GameObject lefthand;
		public GameObject righthand;
		public Vector3 velocityl;
		public Vector3 velocityr;
		bool boolean = true;

		// Use this for initialization
		void Start () {
			tomsound = GetComponents<AudioSource> ();
			sound1 = tomsound [0];
			sound2 = tomsound [1];
		}

		// Update is called once per frame
		void Update () {
			velocityl = lefthand.GetComponent<VelocityEstimator>().speed;
			velocityr = righthand.GetComponent<VelocityEstimator>().speed;
		}

		void OnCollisionEnter(Collision col){
			if (boolean) {
				if (col.gameObject.tag == "right" && velocityr.y <= 0) {
					sound1.volume = velocityr.magnitude / 3 + 0.01f;
					Light.SetFloat ("_InnerColorPower", sound1.volume);
					sound1.Play ();
					GetComponent<Renderer> ().material = Light;
					Invoke ("goBack", 0.1f);
					boolean = !boolean;
				}
				if (col.gameObject.tag == "left" && velocityl.y <= 0) {
					sound1.volume = velocityl.magnitude / 3 + 0.01f;
					Light.SetFloat ("_InnerColorPower", sound1.volume);
					sound1.Play ();
					GetComponent<Renderer> ().material = Light;
					Invoke ("goBack", 0.1f);
					boolean = !boolean;
				}
			} 
			else {
				if (col.gameObject.tag == "right" && velocityr.y <= 0) {
					sound2.volume = velocityr.magnitude / 3 + 0.01f;
					Light.SetFloat ("_InnerColorPower", sound2.volume);
					sound2.Play ();
					GetComponent<Renderer> ().material = Light;
					Invoke ("goBack", 0.1f);
					boolean = !boolean;
				}
				if (col.gameObject.tag == "left" && velocityl.y <= 0) {
					sound2.volume = velocityl.magnitude / 3 + 0.01f;
					Light.SetFloat ("_InnerColorPower", sound2.volume);
					sound2.Play ();
					GetComponent<Renderer> ().material = Light;
					Invoke ("goBack", 0.1f);
					boolean = !boolean;
				}
			}
		}

		void goBack(){
			GetComponent<Renderer> ().material = Default;
		}
	}
}
