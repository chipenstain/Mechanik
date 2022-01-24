using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanik
{
    public class GameManager : MonoBehaviour
    {
		//=============GENERAL PROPERTIES====================
		public static GameManager Instance;

		public CarController controller;
		private List<Tool> toolsOfCar = new List<Tool>();

		private int money = 10000;

		//==============STRENGHT OH THE CAR PARTS================
		private float hoodStrenght;
		private float trunkStrenght;
		private float spoilerStrenght;
		private float[] glassesStrenght = new float[2];
		private float[] doorsStrenght = new float[2];
		private float[] wheelsStrenght = new float[4];

		//=========================================================
		public List<Tool> ToolsOfCar { get => toolsOfCar; set => toolsOfCar = value; }

		public int Money { get => money; set => money = value; }

		public float HoodStrenght { get => hoodStrenght; }
		public float TrunkStrenght { get => trunkStrenght; }
		public float SpoilerStrenght { get => spoilerStrenght; }
		public float[] GlassesStrenght { get => glassesStrenght; }
		public float[] DoorsStrenght { get => doorsStrenght; }
		public float[] WheelsStrenght { get => wheelsStrenght; }

		//=============UNITY METHODS===================
		private void Awake()
		{
			Instance = this;
			DontDestroyOnLoad(this);

			controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CarController>();

			SceneManager.activeSceneChanged += ActivateRaceMode;
		}

		

		//==============CUSTOM METHODS==================
		private void ActivateRaceMode(Scene scene1, Scene scene2)
		{
			if (scene2.buildIndex == 1)
			{
				controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CarController>();
				controller.Activate();
			}
		}

		public void AddStrenghtToPart (PartOfCar part, float strenght)
		{
			UIManager.Instance.ChangePower(part, strenght);
			switch (part)
			{
				case PartOfCar.HOOD:
					hoodStrenght += strenght;
					break;
				case PartOfCar.TRUNK:
					trunkStrenght += strenght;
					break;
				case PartOfCar.SPOILER:
					spoilerStrenght += strenght;
					break;
				case PartOfCar.GLASS_L:
					glassesStrenght[0] += strenght;
					break;
				case PartOfCar.GLASS_R:
					glassesStrenght[1] += strenght;
					break;
				case PartOfCar.DOOR_L:
					doorsStrenght[0] += strenght;
					break;
				case PartOfCar.DOOR_R:
					doorsStrenght[1] += strenght;
					break;
				case PartOfCar.WHEEL_FL:
					wheelsStrenght[0] += strenght;
					break;
				case PartOfCar.WHEEL_BL:
					wheelsStrenght[1] += strenght;
					break;
				case PartOfCar.WHEEL_FR:
					wheelsStrenght[2] += strenght;
					break;
				case PartOfCar.WHEEL_BR:
					wheelsStrenght[3] += strenght;
					break;
			}
		}
    }
}
