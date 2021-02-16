using UnityEngine;

public class ControlableSphere : MonoBehaviour
{
	[SerializeField, Range(0f, 30f)] float maxSpeed = 5f;
	[SerializeField, Range(0f, 30f)] float maxAcceleration = 10f;
	Vector3 velocity;
	Vector3 desiredVelocity;
	Rigidbody body;

	void Awake () {
		body = GetComponent<Rigidbody>();
	}
	void Update()
	{
		Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		playerInput = Vector2.ClampMagnitude(playerInput, 1f);
		desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
	}

	void FixedUpdate()
	{
		var maxSpeedChange = maxAcceleration * Time.deltaTime;
		velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
		velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
		body.velocity = velocity;
	}

	//     void Jump()
//     {
//         desiredJump = false;
//         if (onGround || jumpPhase < maxAirJumps)
//         {
//             jumpPhase++;
//             var jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
//             if (velocity.y > 0f)
//             {
//                 jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
//             }
//             velocity.y += jumpSpeed;
//         }
//     }
}