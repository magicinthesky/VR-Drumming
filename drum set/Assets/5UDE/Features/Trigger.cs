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
using System.Collections.Generic;

public class Trigger : Element {

	// Trigger-related members
	public bool triggerEntered { get; protected set; }
	public bool triggerOngoing { get; protected set; }
	public bool triggerExited { get; protected set; }
	public List<Collider> enteredTriggers { get; protected set; }
	public List<Collider> ongoingTriggers { get; protected set; }
	public List<Collider> exitedTriggers { get; protected set; }

	// Private state-related variables
	protected bool onTrigger;

	// Called at the end of the program initialization
	protected override void Start () {

		// Create trigger states
		onTrigger = triggerEntered = triggerOngoing = triggerExited = false;
		// Create trigger lists
		enteredTriggers = new List<Collider> ();
		ongoingTriggers = new List<Collider> ();
		exitedTriggers = new List<Collider> ();

		// Call update to set the appropriate settings
		Update ();
	}

	// Updates the behaviors of the element's rigidbody and colliders
	protected override void UpdateBehaviors () {

		// Ensure physics do not control the rigidbody
		rigidbody.isKinematic = true;

		// Ensure all the colliders are set for triggers
		Collider[] colliders = gameObject.GetComponents<Collider> ();
		for (int i = 0; i < colliders.Length; i++) {
			colliders [i].isTrigger = true;
		}
	}

	// FixedUpdate is not called every graphical frame but rather every physics frame
	protected virtual void FixedUpdate () {

		// OnTrigger state has not been reset yet because FixedUpdate occurs first
		onTrigger = false;
	}
		
	// Called first by every OnTrigger function
	protected virtual void OnTriggerUpdate () {

		// If an OnTrigger function has not already been called this physics frame
		if (!onTrigger) {
			// One has now been called
			onTrigger = true;
			// Reset Trigger states
			triggerEntered = triggerOngoing = triggerExited = false;
			// Clear previous triggers entered
			enteredTriggers.Clear();
			// Clear previous triggers ongoing
			ongoingTriggers.Clear();
			// Clear previous triggers exited
			exitedTriggers.Clear();
		}
	}

	// Called when a collider has begun touching another collider
	protected virtual void OnTriggerEnter (Collider trigger) {

		// Update all the states
		OnTriggerUpdate ();

		// Avoid self triggering
		if (trigger.gameObject != gameObject) {
			// Update the current state value
			triggerEntered = true;
			// Keep track of the current trigger
			enteredTriggers.Add (trigger);
		}
	}

	// Called once per frame for every collider touching another collider
	protected virtual void OnTriggerStay (Collider trigger) {

		// Update all the states
		OnTriggerUpdate ();

		// Avoid self triggering
		if (trigger.gameObject != gameObject) {
			// Update the current state value
			triggerOngoing = true;
			// Keep track of the current trigger
			ongoingTriggers.Add (trigger);
		}
	}

	// Called when a collider has stopped touching another collider
	protected virtual void OnTriggerExit (Collider trigger) {

		// Update all the states
		OnTriggerUpdate ();

		// Avoid self triggering
		if (trigger.gameObject != gameObject) {
			// Update the current state value
			triggerExited = true;
			// Keep track of the current trigger
			exitedTriggers.Add (trigger);
		}
	}
}
