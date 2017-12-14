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

// Public enumeration of the types of element collider shapes
public enum ElementShape {
	Box,
	Sphere,
	Capsule,
	Mesh,
	Wheel,
	Terrain,
	ExistingColliders
};

[RequireComponent(typeof(Rigidbody))]
public class Element : MonoBehaviour {

	// Members available in the Inspector
	public ElementShape shape;

	// Physics-related members
	public new Rigidbody rigidbody { get; protected set; }
	public Vector3 position { get; protected set; }
	public Vector3 velocity { get; protected set; }
	public Quaternion rotation { get; protected set; }
	public Vector3 angularVelocity { get; protected set; }

	// Private state-related variables
	protected Collider addedCollider;

	// Called at the start of the program initialization
	void Awake () {

		// Get the local rigidbody
		rigidbody = GetComponent<Rigidbody>();
		// Get initial position
		Vector3 newPosition;
		newPosition.x = transform.position.x;
		newPosition.y = transform.position.y;
		newPosition.z = transform.position.z;
		position = newPosition;
		// Set the initial velocity 
		velocity = new Vector3 ();
		// Get initial rotation
		Quaternion newRotation = Quaternion.Inverse(transform.rotation);
		rotation = Quaternion.Inverse (newRotation);
		// Set the initial angularVelocity
		angularVelocity = new Vector3 ();
	}

	// Called at the end of the program initialization
	protected virtual void Start () {

		// Call update to set the appropriate settings
		Update ();
	}
		
	// Called every graphical frame
	protected virtual void Update () {

		// Update collider shape
		UpdateColliderShape ();
		// Update behavior
		UpdateBehaviors ();
		// Update physics
		UpdatePhysics ();
	}

	// Updates the collider shape of the element
	protected void UpdateColliderShape () {

		// If an added collider should exist
		if (shape != ElementShape.ExistingColliders) {

			// If an added collider does exist
			if (addedCollider != null) {

				// If the shape and added collider do not match
				if ((shape == ElementShape.Box && !(addedCollider is BoxCollider)) ||
					(shape == ElementShape.Sphere && !(addedCollider is SphereCollider)) ||
					(shape == ElementShape.Capsule && !(addedCollider is CapsuleCollider)) ||
					(shape == ElementShape.Mesh && !(addedCollider is MeshCollider)) ||
					(shape == ElementShape.Wheel && !(addedCollider is WheelCollider)) ||
					(shape == ElementShape.Terrain && !(addedCollider is TerrainCollider))) {
					// Destroy the added collider
					DestroyImmediate (addedCollider);
				}
			}

			// If an added collider does not exist
			if (addedCollider == null) {

				// If the shape is a box
				if (shape == ElementShape.Box) {
					// Add a box collider
					addedCollider = gameObject.AddComponent<BoxCollider> ();
				}

				// If the shape is a sphere
				else if (shape == ElementShape.Sphere) {
					// Add a sphere collider
					addedCollider = gameObject.AddComponent<SphereCollider> ();
				}

				// If the shape is a capsule
				else if (shape == ElementShape.Capsule) {
					// Add a capsule collider
					addedCollider = gameObject.AddComponent<CapsuleCollider> ();
				}

				// If the shape is a mesh
				else if (shape == ElementShape.Mesh) {
					// Mesh colliders by default are non-convex. However, Unity 5 does not allow non-convex 
					// mesh colliders to be added to non-kinematic objects. Hence, we have to temporarily set 
					// the isKinematic property, add the mesh collider, set it to convex, and then revert
					bool isKinematic = rigidbody.isKinematic;
					rigidbody.isKinematic = true;
					// Add a mesh collider
					addedCollider = gameObject.AddComponent<MeshCollider> ();
					// Set mesh to be convex if the isKinematic property is not set
					if (!isKinematic) {
						(addedCollider as MeshCollider).convex = true;
					}
					// Revert the kinematics
					rigidbody.isKinematic = isKinematic;
				}

				// If the shape is a wheel
				else if (shape == ElementShape.Wheel) {
					// Add a wheel collider
					addedCollider = gameObject.AddComponent<WheelCollider> ();
				}

				// If the shape is a terrain
				else if (shape == ElementShape.Terrain) {
					// Add a terrain collider
					addedCollider = gameObject.AddComponent<TerrainCollider> ();
				}
			}
		}

		// If the element will use the pre-existing colliders
		else if (shape == ElementShape.ExistingColliders) {
			// Destroy the added collider
			DestroyImmediate (addedCollider);
		}
	}

	// Updates the behaviors of the element's rigidbody and colliders
	protected virtual void UpdateBehaviors () {

		// Update behaviors here
	}

	// Updates the physics-related members of the element
	protected void UpdatePhysics () {

		// Update velocity
		velocity = (transform.position - position) / Time.deltaTime;
		// Update position
		Vector3 newPosition;
		newPosition.x = transform.position.x;
		newPosition.y = transform.position.y;
		newPosition.z = transform.position.z;
		position = newPosition;
		// Update angular velocity
		angularVelocity = (transform.rotation * Quaternion.Inverse (rotation)).eulerAngles / Time.deltaTime;
		// Update rotation
		Quaternion newRotation = Quaternion.Inverse (transform.rotation);
		rotation = Quaternion.Inverse (newRotation);
	}
}
