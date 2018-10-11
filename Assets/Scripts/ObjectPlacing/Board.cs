using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	private Component[,] components = new Component[100,100];

	public void AddComponent(Component component, Vector3 position)
	{
		position.y = position.y + 1;
		components[(int)position.x, (int)position.z] = Instantiate(component, position, Quaternion.identity);
	}

	public Component CheckForComponentAtPosition(Vector3 position)
	{
		return components[(int)position.x, (int)position.z];
	}

	public int CheckForComponentID(Vector3 position)
	{
		return components[(int)position.x, (int)position.z].id;
	}

	public void RemoveComponent(Vector3 position)
	{
		Destroy(components[(int)position.x, (int)position.z].gameObject);
		components[(int)position.x, (int)position.z] = null;
	}
	public Vector3 CalculateGridPosition(Vector3 position)
	{
		return new Vector3(Mathf.Round(position.x), .5f, Mathf.Round(position.z));
	}
}
