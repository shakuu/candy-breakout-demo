using System.Collections;

using UnityEngine;

public class DestroyOnBoundary : MonoBehaviour
{
	private GameController gameController;

	public void Start()
	{
		var gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		this.gameController = gameControllerObject.GetComponent<GameController>();
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Ball"))
		{
			Object.Destroy(other.gameObject);
			this.gameController.HandleGameBallIsDestroyed();
		}
	}
}
