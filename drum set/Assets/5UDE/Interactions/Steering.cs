/*
Copyright ©2017. The University of Texas at Dallas. All Rights Reserved. 

Permission to use, copy, modify, and distribute this software and its documentation for 
educational, research, and not-for-profit purposes, without fee and without a signed 
licensing agreement, is hereby granted, provided that the above copyright notice, this 
paragraph and the following two paragraphs appear in all copies, modifications, and 
distributions. 

Contact The Office of Technology Commercialization, The University of Texas at Dallas, 
800 W. Campbell Road (AD15), Richardson, Texas 75080-3021, (972) 883-4558, 
otc@utdallas.edu, https://research.utdallas.edu/otc for commercial licensing opportunities.

IN NO EVENT SHALL THE UNIVERSITY OF TEXAS AT DALLAS BE LIABLE TO ANY PARTY FOR DIRECT, 
INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS, ARISING 
OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF THE UNIVERSITY OF TEXAS AT 
DALLAS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

THE UNIVERSITY OF TEXAS AT DALLAS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT 
NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF ANY, PROVIDED HEREUNDER IS 
PROVIDED "AS IS". THE UNIVERSITY OF TEXAS AT DALLAS HAS NO OBLIGATION TO PROVIDE 
MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR MODIFICATIONS.
*/

using UnityEngine;
using System.Collections;

public class Steering : MonoBehaviour {

	// Enumerate the states of steering
	public enum SteeringState {
//		NotSteering,
//		SteeringForward,
//		SteeringBackward,
//		SteeringLeftward,
//		SteeringRightward,

		Standing,
		Sitting
	};
	
    // Inspector parameters
    [Tooltip("The tracking device used to determine absolute direction for steering.")]
    public CommonTracker tracker;

    [Tooltip("The controller joystick used to determine relative direction (forward/backward) and speed.")]
	public CommonAxis joystick;

//	[Tooltip("A button required to be pressed to activate standing.")]
//	public CommonButton button;  

	[Tooltip("A trigger button required to be pressed to activate sitting.")]
	public CommonButton Triggerbutton;

    [Tooltip("A side button required to be pressed to activate standing.")]
    public CommonButton sidebutton;

    [Tooltip("The space that is translated by this interaction. Usually set to the physical tracking space.")]
    public CommonSpace space;

    [Tooltip("The median speed for movement expressed in meters per second.")]
    public float speed = 1.0f;

	// Private interaction variables
	private SteeringState state;

	public Material Light;
	public Material Default;

	// Called at the end of the program initialization
	void Start () {

		// Set initial steering state to not steering
		state = SteeringState.Standing;
	}
		
    // FixedUpdate is not called every graphical frame but rather every physics frame
	void FixedUpdate () {
		
		if (joystick.GetAxis ().x > 0.0f) {
			Invoke ("Activate", 2.0f);
			Invoke ("FreeMode", 36.0f);
		} 
		else if(joystick.GetAxis ().x < 0.0f) {
			GameObject.FindWithTag ("left").GetComponent<Valve.VR.InteractionSystem.Tutorial> ().enabled = false;
			GameObject.FindWithTag ("right").GetComponent<Valve.VR.InteractionSystem.Tutorial> ().enabled = false;
		}

		if(state == SteeringState.Standing){
			if (Triggerbutton.GetPressDown()) {
				Vector3 temp = space.transform.position;
				temp.y -= 0.15f;
				space.transform.position = temp;
				state = SteeringState.Sitting;
			} else {

			}
		}

		if (state == SteeringState.Sitting) {
			
			if (sidebutton.GetPressDown()) {
				Vector3 temp1 = space.transform.position;
				temp1.y += 0.15f;
				space.transform.position = temp1;
				state = SteeringState.Standing;
			} else {

			}
		}
	}

	void Activate(){
		GameObject.FindWithTag ("left").GetComponent<Valve.VR.InteractionSystem.Tutorial> ().enabled = true;
		GameObject.FindWithTag ("right").GetComponent<Valve.VR.InteractionSystem.Tutorial> ().enabled = true;
	}

	void FreeMode(){
		GameObject.FindWithTag("04outer").GetComponent<Valve.VR.InteractionSystem.OuterStrike> ().enabled = true;
		GameObject.FindWithTag("04inner").GetComponent<Valve.VR.InteractionSystem.InnerStrike> ().enabled = true;
		GameObject.FindWithTag("24outer").GetComponent<Valve.VR.InteractionSystem.OuterStrike> ().enabled = true;
		GameObject.FindWithTag("24inner").GetComponent<Valve.VR.InteractionSystem.InnerStrike> ().enabled = true;
		GameObject.FindWithTag("25outer").GetComponent<Valve.VR.InteractionSystem.OuterStrike> ().enabled = true;
		GameObject.FindWithTag("25inner").GetComponent<Valve.VR.InteractionSystem.InnerStrike> ().enabled = true;
		GameObject.FindWithTag("26outer").GetComponent<Valve.VR.InteractionSystem.OuterStrike> ().enabled = true;
		GameObject.FindWithTag("26inner").GetComponent<Valve.VR.InteractionSystem.InnerStrike> ().enabled = true;
		GameObject.FindWithTag("01outer").GetComponent<Valve.VR.InteractionSystem.OuterStrike> ().enabled = true;
		GameObject.FindWithTag("01inner").GetComponent<Valve.VR.InteractionSystem.InnerStrike> ().enabled = true;
		GameObject.FindWithTag("02outer").GetComponent<Valve.VR.InteractionSystem.OuterStrike> ().enabled = true;
		GameObject.FindWithTag("02inner").GetComponent<Valve.VR.InteractionSystem.InnerStrike> ().enabled = true;
		GameObject.FindWithTag("03outer").GetComponent<Valve.VR.InteractionSystem.OuterStrike> ().enabled = true;
		GameObject.FindWithTag("03inner").GetComponent<Valve.VR.InteractionSystem.InnerStrike> ().enabled = true;
	}
}