using UnityEngine;
using Cinemachine;

namespace Mechanik
{
    public class CameraBtn : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cam;
        [SerializeField] private Transform target;

        public void OnCameraBtn()
        {
            cam.Follow = target;
        }
    }
}
