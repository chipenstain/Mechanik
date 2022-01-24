using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Mechanik
{
    public class RaceUIManager : MonoBehaviour
    {
        public static RaceUIManager Instance;

		[SerializeField] private TextMeshProUGUI infoText;
		[SerializeField] private TextMeshProUGUI checkPointText;
		[SerializeField] private Slider health;
		[SerializeField] private GameObject backToGarageBtn;

		private float infoTextTimer = 0f;
		private const float INFOTEXTDURATION = 2f;

		private void Awake()
		{
			Instance = this;
		}

		private void Update()
		{
			infoTextTimer += Time.deltaTime;
			if (infoTextTimer >= INFOTEXTDURATION)
			{
				infoText.gameObject.SetActive(false);
			}
		}

		public void CheckPoint(bool wrong)
		{
			infoTextTimer = 0f;
			infoText.gameObject.SetActive(true);

			if(wrong)
			{
				infoText.text = "!!!! Не туда !!!!";
			}
			else
			{
				checkPointText.text = "Checkpoint : " + RaceManager.Instance.Checkpoint + "/5";
				infoText.text = "Checkpoint : " + RaceManager.Instance.Checkpoint + "/5";
			}
		}

		public void SetHealth(float health)
		{
			this.health.value = health;
			if (health <= 0.1f)
			{
				backToGarageBtn.SetActive(true);
			}
		}

		public void OnBackGarage()
		{
			SceneManager.LoadScene(0);
		}
    }
}
