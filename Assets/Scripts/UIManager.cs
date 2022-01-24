using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mechanik
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

		[SerializeField] private Slider[] powersOfParts;
		[SerializeField] private TextMeshProUGUI MoneyText;

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			ChangeMoney();
		}

		public void ChangeMoney()
		{
			MoneyText.text = GameManager.Instance.Money.ToString();
		}

		public void ChangePower(PartOfCar part, float strenght)
		{
			switch (part)
			{
				case PartOfCar.HOOD:
					powersOfParts[0].value += strenght;
					break;
				case PartOfCar.TRUNK:
					powersOfParts[1].value += strenght;
					break;
				case PartOfCar.SPOILER:
					powersOfParts[1].value += strenght;
					break;
				case PartOfCar.GLASS_L:
					powersOfParts[2].value += strenght;
					break;
				case PartOfCar.GLASS_R:
					powersOfParts[3].value += strenght;
					break;
				case PartOfCar.DOOR_L:
					powersOfParts[2].value += strenght;
					break;
				case PartOfCar.DOOR_R:
					powersOfParts[3].value += strenght;
					break;
				case PartOfCar.WHEEL_FL:
					powersOfParts[4].value += strenght;
					break;
				case PartOfCar.WHEEL_BL:
					powersOfParts[5].value += strenght;;
					break;
				case PartOfCar.WHEEL_FR:
					powersOfParts[6].value += strenght;
					break;
				case PartOfCar.WHEEL_BR:
					powersOfParts[7].value += strenght;
					break;
			}
		}
    }
}
