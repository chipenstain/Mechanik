using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanik
{
    public class StartBtn : MonoBehaviour
    {
        public void OnStart()
		{
			SceneManager.LoadScene(1);
		}
    }
}
