using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentHandler : MonoBehaviour {

	[SerializeField]
	private Component[] components;
	[SerializeField]
	private Board board;
	private Component selectedComponent;
	[SerializeField]
	private CameraController cameraController;
	private Vector3 mouseClickPos;
	private int componentID;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && selectedComponent != null)
		{
			InteractWithBoard(0);
		}
		else if (Input.GetMouseButtonDown(0) && selectedComponent != null)
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
		// Debug.Log(ray);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			Debug.Log("Hit True");
			Vector3 gridPosition = board.CalculateGridPosition(hit.point);
			Debug.Log(gridPosition);
			//Make sure cursor isn't over a UI object and a component isn't there either
			if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())	
			{	
				//If left click and there is no component at position, add component
				if (action == 0 && board.CheckForComponentAtPosition(gridPosition) == null)
				{
						board.AddComponent(selectedComponent, gridPosition);
				}

				//Else, if Right click && there is a component,
				//remove component and refund half of cost & update UI
				else if (action == 1 && board.CheckForComponentAtPosition(gridPosition) != null)
				{
					componentID = board.CheckForComponentID(gridPosition);
					board.RemoveComponent(gridPosition);
				}
			}
		}
	}

	public void EnableBuilder(int component)
	{
		selectedComponent = components[component];
		Debug.Log("Selected component: " + selectedComponent.componentName);
	}
}
