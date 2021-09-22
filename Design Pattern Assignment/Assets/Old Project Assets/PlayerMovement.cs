using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rigidBody;
	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;

	private bool grounded = false;

	private void Start()
    {
		rigidBody = GetComponent<Rigidbody>();

        rigidBody.freezeRotation = true;
		rigidBody.useGravity = false;
	}
	
	void FixedUpdate()
	{
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = transform.TransformDirection(targetVelocity);
		targetVelocity *= speed;

		Vector3 velocity = rigidBody.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
		
		if (grounded)
		{
			if (canJump && Input.GetButton("Jump"))
			{
				rigidBody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		}

		rigidBody.AddForce(new Vector3(0, -gravity * rigidBody.mass, 0));

		grounded = false;
	}

	void OnCollisionStay(Collision _other)
	{
		if (_other.gameObject.tag == "Floor")
        {
			grounded = true;
        }
	}

    float CalculateJumpVerticalSpeed()
	{
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}
