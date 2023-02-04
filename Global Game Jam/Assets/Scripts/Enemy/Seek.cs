using UnityEngine;

public class Seek : SteeringBehaviour
{

	
	public override Vector3 UpdateBehaviour(SteeringAgent steeringAgent)
	{
		// Get the desired velocity for seek and limit to maxSpeed
		desiredVelocity = Vector3.Normalize(steeringAgent.player.transform.position - transform.position) * steeringAgent.MaxCurrentSpeed;

		// Calculate steering velocity
		if (steeringAgent.hasAttacked == false)
		{
		steeringVelocity = desiredVelocity - steeringAgent.CurrentVelocity;
		}
		else if (steeringAgent.hasAttacked)
			steeringVelocity = (desiredVelocity - steeringAgent.CurrentVelocity) * -1;
	
		return steeringVelocity;
	}
}
