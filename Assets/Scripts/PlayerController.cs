using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float PlayerSpeed;

	public float PlayerTiltModifier;

	private GameObject playerBall;

	private GameController gameController;
	private Rigidbody playerRigidBody;

	public void Start()
	{
		this.playerBall = GameObject.FindWithTag("Ball");
		var gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		this.gameController = gameControllerObject.GetComponent<GameController>();
		this.playerRigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (this.gameController.IsGameOver)
		{
			return;
		}

		if (this.gameController.IsRunning)
		{
			var horizontalDelta = this.GetHorizontalDeltaFromInput();
			var velocity = new Vector3(horizontalDelta, 0, 0);
			var playerTilt = this.GetPlayerTilt(velocity);

			this.SetRigidBodyRotation(this.playerRigidBody, playerTilt);
			this.SetRigidBodyVelocity(this.playerRigidBody, velocity, this.PlayerSpeed);
		}
		else
		{
			this.WaitForInputToStartTheGame();
		}

	}

	private Quaternion GetPlayerTilt(Vector3 velocity)
	{
		var tiltRotation = Quaternion.Euler(0, 0, velocity.x * -this.PlayerTiltModifier);
		return tiltRotation;
	}

	private void SetRigidBodyRotation(Rigidbody rigidBody, Quaternion rotation)
	{
		rigidBody.rotation = rotation;
	}

	private void SetRigidBodyVelocity(Rigidbody rigidBody, Vector3 velocity, float speed)
	{
		rigidBody.velocity = velocity * speed;
	}

	private void WaitForInputToStartTheGame()
	{
		this.HandlePlayerInputWhileWaitingToStart();

		if (Input.GetKey(KeyCode.Space))
		{
			var ballRigidBody = this.playerBall.GetComponent<Rigidbody>();
			var ballController = this.playerBall.GetComponent<BallController>();
			ballRigidBody.velocity = (ballController.InitialVelocity * ballController.Speed);

			this.gameController.StartGameOnInput();
		}
	}

	private void HandlePlayerInputWhileWaitingToStart()
	{
		var horizontalDelta = this.GetHorizontalDeltaFromInput();
		var movementDelta = new Vector3(horizontalDelta, 0, 0);
		this.SetRigidBodyVelocity(this.playerRigidBody, movementDelta, this.PlayerSpeed);

		var ballRigidBody = this.playerBall.GetComponent<Rigidbody>();
		this.SetRigidBodyVelocity(ballRigidBody, movementDelta, this.PlayerSpeed);
	}

	private float GetHorizontalDeltaFromInput()
	{
		var horizontalDelta = Input.GetAxis("Horizontal");
		return horizontalDelta;
	}
}