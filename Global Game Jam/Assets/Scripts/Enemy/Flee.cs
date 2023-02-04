using UnityEngine;

public class Flee : SteeringBehaviour
{

[SerializeField] GameObject player;

	public override Vector3 UpdateBehaviour(SteeringAgent steeringAgent)
	{
		// Get the desired velocity for seek and limit to maxSpeed
		desiredVelocity = Vector3.Normalize(transform.position - player.transform.position) * steeringAgent.MaxCurrentSpeed;

		// Calculate steering velocity
		steeringVelocity = desiredVelocity - steeringAgent.CurrentVelocity;
		return steeringVelocity;
	}
}
