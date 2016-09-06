using System.Collections;

using UnityEngine;

public class BallController : MonoBehaviour
{
	public float Speed;

	private Vector3 initialVelocity;

	public Vector3 InitialVelocity
	{
		get
		{
			return this.initialVelocity;
		}
	}

	// Use this for initialization
	void Start()
	{
		var randonVelocityX = Random.Range(-5, 5);
		this.initialVelocity = new Vector3(randonVelocityX, 10f, 0);
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
