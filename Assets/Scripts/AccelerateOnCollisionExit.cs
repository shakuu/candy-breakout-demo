using System.Collections;

using UnityEngine;

public class AccelerateOnCollisionExit : MonoBehaviour
{
	public float Modifier;

	public void OnCollisionExit(Collision collisionInfo)
	{
		if (collisionInfo.rigidbody == null)
		{
			return;
		}

		collisionInfo.rigidbody.velocity *= this.Modifier;
	}
}