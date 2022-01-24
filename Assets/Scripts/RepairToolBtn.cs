using UnityEngine;

namespace Mechanik
{
    public class RepairToolBtn : MonoBehaviour
    {
		[SerializeField] private GameObject toolStrenghtApllier;
		[SerializeField] private GameObject tool;
		[SerializeField] private int money;

        public void OnToolBtn()
        {
            RepairControls.Instance.ToolStrenghtApplier = toolStrenghtApllier;
			RepairControls.Instance.Tool = tool;
			RepairControls.Instance.MoneyCost = money;
        }
    }
}
