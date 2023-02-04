using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
	/// <summary>
	/// Shows debug lines in scene view to help debug issues with creating steering behaviours.
	/// NOTE: [field: SerializeField] exposes a C# property to Unity's inspector which is useful to toggle at runtime
	/// </summary>
	[field: SerializeField]
	public bool ShowDebugLines { get; set; } = true;

	protected Vector3 desiredVelocity;
	protected Vector3 steeringVelocity;

	/// <summary>
	/// Do steering behaviour code here. At the end of this the desiredVelocity and steeringVelocity variables should be set
	/// </summary>
	/// <param name="steeringAgent">The agent this component is acting on</param>
	/// <returns>The steeringVelocity should always be returned here</returns>
	public abstract Vector3 UpdateBehaviour(SteeringAgent steeringAgent);

	protected virtual void Start()
	{
		// Annoyingly this is needed for the enabled bool to work in Unity. A MonoBehaviour must now have one of the following
		// to activate this: Start(), Update(), FixedUpdate(), LateUpdate(), OnGUI(), OnDisable(), OnEnabled()
	}
}