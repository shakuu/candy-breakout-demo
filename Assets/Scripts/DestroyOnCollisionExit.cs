using System.Collections;

using UnityEngine;

public class DestroyOnCollisionExit : MonoBehaviour
{
	public int PointScoreValue;

	private GameController gameController;

	public void Start()
	{
		if (this.PointScoreValue == 0)
		{
			Debug.Log("PointScoreValue not set.");
		}

		var gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject == null)
		{
			Debug.Log("GameController object not found.");
		}

		this.gameController = gameControllerObject.GetComponent<GameController>();
		if (this.gameController == null)
		{
			Debug.Log("GameController not found.");
		}
	}

	public void OnCollisionExit(Collision collisionInfo)
	{	
		var isPlayerBall = collisionInfo.gameObject.CompareTag("Ball");
		if (isPlayerBall)
		{
			Object.Destroy(this.gameObject);
			this.gameController.AddScore(this.PointScoreValue);
		}
	}
}