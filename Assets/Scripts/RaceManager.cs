using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanik
{
    public class RaceManager : MonoBehaviour
    {
        public static RaceManager Instance;

		private int checkpoint = 0;

		public int Checkpoint { get => checkpoint; set => checkpoint = value; }

		private void Awake()
		{
			Instance = this;
		}

		private void Update()
		{
			if (checkpoint == 5)
			{
				SceneManager.LoadScene(0);
			}
		}
    }
}
