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

public class Stationary : Element {

	// Collision-related members
	public bool collisionEntered { get; protected set; }
	public bool collisionOngoing { get; protected set; }
	public bool collisionExited { get; protected set; }
	public List<Collision> enteredCollisions { get; protected set; }
	public List<Collision> ongoingCollisions { get; protected set; }
	public List<Collision> exitedCollisions { get; protected set; }

	// Private state-related variables
	protected bool onCollision;

	// Called at the end of the program initialization
	protected override void Start () {

		// Create collision states
		onCollision = collisionEntered = collisionOngoing = collisionExited = false;
		// Create collision lists
		enteredCollisions = new List<Collision> ();
		ongoingCollisions = new List<Collision> ();
		exitedCollisions = new List<Collision> ();

		// Call update to set the appropriate settings
		Update ();
	}

	// Updates the behaviors of the element's rigidbody and colliders
	protected override void UpdateBehaviors () {

		// Ensure physics do not control the rigidbody
		rigidbody.isKinematic = true;

		// Ensure all the colliders are set for collisions
		Collider[] colliders = gameObject.GetComponents<Collider> ();
		for (int i = 0; i < colliders.Length; i++) {
			colliders [i].isTrigger = false;
		}
	}

	// FixedUpdate is not called every graphical frame but rather every physics frame
	protected virtual void FixedUpdate () {

		// OnCollision state has not been reset yet because FixedUpdate occurs first
		onCollision = false;
	}

	// Called first by every OnCollision function
	protected virtual void OnCollisionUpdate () {

		// If an OnCollision function has not already been called this physics frame
		if (!onCollision) {
			// One has now been called
			onCollision = true;
			// Reset collision states
			collisionEntered = collisionOngoing = collisionExited = false;
			// Clear previous collisions entered
			enteredCollisions.Clear();
			// Clear previous collisions ongoing
			ongoingCollisions.Clear();
			// Clear previous collisions exited
			exitedCollisions.Clear();
		}
	}

	// Called when a collider has begun touching another collider
	protected virtual void OnCollisionEnter (Collision collision) {

		// Update all the states
		OnCollisionUpdate ();
		// Update the current state value
		collisionEntered = true;
		// Keep track of the current collision
		enteredCollisions.Add(collision);
	}

	// Called once per frame for every collider touching another collider
	protected virtual void OnCollisionStay (Collision collision) {

		// Update all the states
		OnCollisionUpdate ();
		// Update the current state value
		collisionOngoing = true;
		// Keep track of the current collision
		ongoingCollisions.Add(collision);
	}

	// Called when a collider has stopped touching another collider
	protected virtual void OnCollisionExit (Collision collision) {

		// Update all the states
		OnCollisionUpdate ();
		// Update the current state value
		collisionExited = true;
		// Keep track of the current collision
		exitedCollisions.Add(collision);
	}
}
