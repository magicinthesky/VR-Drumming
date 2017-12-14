using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem{

	public class Sounds : MonoBehaviour {

		AudioSource tomsound;
		public GameObject lefthand;
		public GameObject righthand;
		public Vector3 velocityl;
		public Vector3 velocityr;


		// Use this for initialization
		void Start () {
			tomsound = GetComponent<AudioSource> ();
		}

		// Update is called once per frame
		void Update () {
			velocityl = lefthand.GetComponent<VelocityEstimator>().speed;
			velocityr = righthand.GetComponent<VelocityEstimator>().speed;

		}

		void OnCollisionEnter(Collision col){
			if (col.gameObject.tag == "right") {
				tomsound.volume = velocityr.magnitude / 2;
			}
			if (col.gameObject.tag == "left") {
				tomsound.volume = velocityl.magnitude / 2;
			}
			tomsound.Play ();
		}
	}
}
