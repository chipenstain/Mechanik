using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanik
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] private int id;
		[SerializeField] private int bonus;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("PlayerCol"))
			{
				if (id == RaceManager.Instance.Checkpoint + 1)
				{
					GameManager.Instance.Money += bonus;
					RaceManager.Instance.Checkpoint = id;
					RaceUIManager.Instance.CheckPoint(false);
				}
				else
				{
					RaceUIManager.Instance.CheckPoint(true);
				}
			}
		}
    }
}
