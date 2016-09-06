using System.Collections;

using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject PlayerBoard;

	public GameObject PlayerBall;

	private GameObject playerBoardInstance;
	private GameObject playerBallInstance;
	private CandyPatternManager patternFactory;

	private bool isRunning;
	private bool isGameOver;

	private int score;

	public bool IsGameOver
	{
		get
		{
			return this.isGameOver;	
		}

		private	set
		{
			this.isGameOver = value;
		}
	}

	public bool IsRunning
	{
		get
		{
			return this.isRunning;
		}

		private set
		{
			this.isRunning = value;
		}
	}

	public int Score
	{
		get
		{
			return this.score;	
		}

		private set
		{
			this.score = value;
		}
	}

	// Use this for initialization
	public void Start()
	{
		this.isRunning = false;
		this.isGameOver = false;
		this.patternFactory = this.GetComponent<CandyPatternManager>();

		this.SetupTheScene();
	}
	
	// Update is called once per frame
	public void Update()
	{
		if (this.IsGameOver)
		{
			this.HandleGameOver();

			// TODO: 
			// Restart the game for demo purposes
			this.IsGameOver = false;
			this.SetupTheScene();
			return;
		}

		bool allCandyAreDestroyed = this.CheckIfAllCandyAreDestroyed();
		if (allCandyAreDestroyed)
		{
			this.patternFactory.GetNextLevel();
		}
	}

	public void StartGameOnInput()
	{
		this.isRunning = true;
	}

	public void HandleGameBallIsDestroyed()
	{
		this.IsGameOver = true;
	}

	public void AddScore(int score)
	{
		this.Score += score;
	}

	private void HandleGameOver()
	{
		this.patternFactory.DestroyAllCandy();
		Object.Destroy(this.playerBallInstance.gameObject);
		Object.Destroy(this.playerBoardInstance.gameObject);

		this.IsRunning = false;
	}

	private void SetupTheScene()
	{
		this.patternFactory.BuildStandardPattern();
		this.playerBoardInstance = (GameObject)Object.Instantiate(this.PlayerBoard, this.PlayerBoard.transform.position, this.PlayerBoard.transform.rotation);
		this.playerBallInstance = (GameObject)Object.Instantiate(this.PlayerBall, this.PlayerBall.transform.position, this.PlayerBall.transform.rotation);
	}

	private bool CheckIfAllCandyAreDestroyed()
	{
		var existingCandyCount = this.patternFactory.GetExistingCandyCount();
		var areDestroyed = existingCandyCount == 0;
		return areDestroyed;
	}
}
