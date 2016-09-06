using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CandyPatternManager : MonoBehaviour
{
	public GameObject CandyObject;

	public void GetNextLevel()
	{
		// TODO:
		this.BuildStandardPattern();
	}

	public void BuildStandardPattern()
	{
		for (int row = 18; row <= 30; row += 6)
		{
			for (int col = -24; col <= 24; col += 6)
			{
				var position = new Vector3(col, row, 0);
				var rotation = CandyObject.transform.rotation;
				Object.Instantiate(this.CandyObject, position, rotation);
			}
		}
	}

	public void DestroyAllCandy()
	{
		var allCandy = this.GetAllCandyObjects();
		foreach (var candy in allCandy)
		{
			Object.Destroy(candy.gameObject);
		}
	}

	public int GetExistingCandyCount()
	{
		var allCandy = this.GetAllCandyObjects();
		return allCandy.Count;
	}

	private ICollection<GameObject> GetAllCandyObjects()
	{
		var allCandy = GameObject.FindGameObjectsWithTag("Candy");
		return allCandy;
	}
}
