using System.Collections.Generic;
using UnityEngine;

namespace Mechanik
{
	public class RepairControls : MonoBehaviour
	{
		//=============GENERAL PROPERTIES====================
		public static RepairControls Instance;

		private Camera cam;
		[SerializeField] private Transform car;

		//=============TOOLS PROPERTIES====================
		private GameObject toolStrenghtApplier;
		private GameObject tool;
		private int moneyCost;

		private const float DENSITYOFTOOL = 0.1f;
		private float densityTimer = 0f;

		private LineRenderer toolRender;
		private int toolPointId;

		//==============================================
		public GameObject ToolStrenghtApplier { set => toolStrenghtApplier = value; }
		public GameObject Tool { set => tool = value; }
		public int MoneyCost { set => moneyCost = value; }

		//=============UNITY METHODS====================
		private void Awake()
		{
			Instance = this;
			cam = Camera.main;
		}

		private void Update()
		{
			if (Input.touchCount > 0)
			{
				densityTimer += Time.deltaTime;
				Touch touch = Input.GetTouch(0);
				
				if (Physics.Raycast(cam.ScreenPointToRay(touch.position), out RaycastHit hit, 1000, 1 << 6))
				{
					if (touch.phase == TouchPhase.Began)
					{
						if (GameManager.Instance.Money > 0)
						{
							GameObject toolCast = Instantiate(tool, car);
							toolRender = toolCast.GetComponent<LineRenderer>();
							toolPointId = 0;
						}
					}
					if (touch.phase == TouchPhase.Moved && densityTimer > DENSITYOFTOOL)
					{
						if (GameManager.Instance.Money > 0)
						{
							GameManager.Instance.Money -= moneyCost;
							UIManager.Instance.ChangeMoney();

							Transform toolCast = Instantiate(toolStrenghtApplier).transform;
							toolCast.position = hit.point;
							toolCast.rotation = Quaternion.LookRotation(hit.normal);
							toolRender.positionCount = toolRender.positionCount + 1;
							toolRender.SetPosition(toolPointId, car.InverseTransformPoint(hit.point));
							
							toolPointId++;					
							
							densityTimer = 0f;
						}
					}
					if (touch.phase == TouchPhase.Ended)
					{
						if (GameManager.Instance.Money > 0)
						{
							Vector3[] positions = new Vector3[toolRender.positionCount];
							toolRender.GetPositions(positions);
							GameManager.Instance.ToolsOfCar.Add(new Tool(tool, positions));
						}
					}
				}
			}
			else
			{
				densityTimer = 0f;
			}
		}
	}
}