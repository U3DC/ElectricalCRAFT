using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	private Part[,] parts = new Part[100,100];

	public void AddPart(Part part, Vector3 position)
	{
		position.y = position.y + 5;
		parts[(int)position.x, (int)position.z] = Instantiate(part, position, Quaternion.identity);
	}

	public Part CheckForPartAtPosition(Vector3 position)
	{
		return parts[(int)position.x, (int)position.z];
	}

	public int CheckForPartID(Vector3 position)
	{
		return parts[(int)position.x, (int)position.z].id;
	}

	public void RemovePart(Vector3 position)
	{
		Destroy(parts[(int)position.x, (int)position.z].gameObject);
		parts[(int)position.x, (int)position.z] = null;
	}
	public Vector3 CalculateGridPosition(Vector3 position)
	{
		return new Vector3(Mathf.Round(position.x), .5f, Mathf.Round(position.z));
	}
}
