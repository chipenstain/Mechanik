using UnityEngine;

namespace Mechanik
{
    public class ToolConnect : MonoBehaviour
    {
		[SerializeField] private float destroyAfterTime = 0.1f;
		[SerializeField] private float strenght = 0.1f;

		private void Start()
		{
			Destroy(gameObject, destroyAfterTime);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Hood"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.HOOD, strenght);
			}
			if (other.CompareTag("Trunk"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.TRUNK, strenght);
			}
			if (other.CompareTag("Spoiler"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.SPOILER, strenght);
			}
			if (other.CompareTag("Door_Glass_L"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.GLASS_L, strenght);
			}
			if (other.CompareTag("Door_Glass_R"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.GLASS_R, strenght);
			}
			if (other.CompareTag("Door_L"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.DOOR_L, strenght);
			}
			if (other.CompareTag("Door_R"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.DOOR_R, strenght);
			}
			if (other.CompareTag("Wheel_FL"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.WHEEL_FL, strenght);
			}
			if (other.CompareTag("Wheel_BL"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.WHEEL_BL, strenght);
			}
			if (other.CompareTag("Wheel_FR"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.WHEEL_FR, strenght);
			}
			if (other.CompareTag("Wheel_BR"))
			{
				GameManager.Instance.AddStrenghtToPart(PartOfCar.WHEEL_BR, strenght);
			}
		}
    }
}
