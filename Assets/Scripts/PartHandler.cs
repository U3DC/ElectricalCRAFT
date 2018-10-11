using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartHandler : MonoBehaviour {

	[SerializeField]
	private Part[] parts;
	[SerializeField]
	private Board board;
	private Part selectedPart;
	[SerializeField]
	private CameraController cameraController;
	private Vector3 mouseClickPos;
	private int partID;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && selectedPart != null)
		{
			InteractWithBoard(0);
		}
		else if (Input.GetMouseButtonDown(0) && selectedPart != null)
		{
			InteractWithBoard(0);
		}

		if (Input.GetMouseButton(1))
		{
			InteractWithBoard(1);
		}
	}

	void InteractWithBoard(int action)
	{
		mouseClickPos = Input.mousePosition;
		Ray ray = cameraController.cameraRaycast(mouseClickPos);
		Debug.Log(ray);
		Debug.Log("Hello1");		
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			Debug.Log("Hit True");
			Vector3 gridPosition = board.CalculateGridPosition(hit.point);
			Debug.Log(gridPosition);
			Debug.Log("Hello2");				
			//Make sure cursor isn't over a UI object and a part isn't there either
			if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())	
			{	
				//If left click and there is no part at position, add part
				if (action == 0 && board.CheckForPartAtPosition(gridPosition) == null)
				{
					board.AddPart(selectedPart, gridPosition);
				}

				//Else, if Right click && there is a part,
				//remove part and refund half of cost & update UI
				else if (action == 1 && board.CheckForPartAtPosition(gridPosition) != null)
				{
					partID = board.CheckForPartID(gridPosition);
					board.RemovePart(gridPosition);

				}
			}
		}
	}

	public void EnableBuilder(int part)
	{
		selectedPart = parts[part];
		Debug.Log("Selected part: " + selectedPart.partName);
	}
}
