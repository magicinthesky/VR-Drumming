using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem{

	public class InnerStrike : MonoBehaviour {

		public Material Light;
		public Material Default;

		AudioSource[] tomsound;
		AudioSource sound1;
		AudioSource sound2;
		AudioSource temp1;
		AudioSource temp2;
		public GameObject lefthand;
		public GameObject righthand;
		public CommonButton triggerButton;
		public CommonButton triggerButton2;
		public Vector3 velocityl;
		public Vector3 velocityr;
		bool boolean = false;
		public bool bassState = false;
		public bool bassStateStrong = false;

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

			if (triggerButton.GetPressDown()) {
				if (!bassState) {
					GameObject.FindWithTag ("27").GetComponent<Renderer> ().material = Light;
					temp1 = GameObject.FindWithTag ("27").GetComponent<AudioSource> ();
					temp1.volume = 0.3f;
					temp1.Play ();
					bassState = true;
					Invoke ("goBack", 0.1f);
				}
			}
			if (triggerButton.GetPressUp ()) {
				bassState = false;
				}

			if (triggerButton2.GetPressDown()) {
				if (!bassStateStrong) {
					GameObject.FindWithTag ("27").GetComponent<Renderer> ().material = Light;
					temp2 = GameObject.FindWithTag ("27").GetComponent<AudioSource> ();
					temp2.volume = 1.0f;
					temp2.Play ();
					bassStateStrong = true;
					Invoke ("goBack", 0.1f);
				}
			}
			if (triggerButton2.GetPressUp ()) {
				bassStateStrong = false;
			}

		}

		void OnCollisionEnter(Collision col){
			/*
			if (col.gameObject.tag == "right") {
				tomsound.volume = velocityr.magnitude / 3;
				Light.SetFloat ("_InnerColorPower", tomsound.volume);
			}
			if (col.gameObject.tag == "left") {
				tomsound.volume = velocityl.magnitude / 3;
				Light.SetFloat ("_InnerColorPower", tomsound.volume);
			}
			tomsound.Play ();
			*/

			if (boolean) {
				if (col.gameObject.tag == "right" && velocityr.y <= 0) {
					sound1.volume = velocityr.magnitude / 3;
					Light.SetFloat ("_InnerColorPower", sound1.volume);
					sound1.Play ();
					GetComponent<Renderer> ().material = Light;
					Invoke ("goBack", 0.1f);
                    boolean = !boolean;

                }
                if (col.gameObject.tag == "left" && velocityl.y <= 0) {
					sound1.volume = velocityl.magnitude / 3;
					Light.SetFloat ("_InnerColorPower", sound1.volume);
					sound1.Play ();
					GetComponent<Renderer> ().material = Light;
					Invoke ("goBack", 0.1f);
                    boolean = !boolean;

                }

            } 
			else {
				if (col.gameObject.tag == "right" && velocityr.y <= 0) {
					sound2.volume = velocityr.magnitude / 3;
					Light.SetFloat ("_InnerColorPower", sound2.volume);
					sound2.Play ();
					GetComponent<Renderer> ().material = Light;
					Invoke ("goBack", 0.1f);
                    boolean = !boolean;

                }
                if (col.gameObject.tag == "left" && velocityl.y <= 0) {
					sound2.volume = velocityl.magnitude / 3;
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
