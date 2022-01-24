using UnityEngine;

namespace Mechanik
{
    public class WearOfPart : MonoBehaviour
    {
		[SerializeField] private bool isWheel;
		[SerializeField] private WheelCollider wheel;
		private FixedJoint joint;

		[SerializeField] private float noiseStrenght;

		private void Start()
		{
			TryGetComponent(out FixedJoint j);
			joint = j;
		}

		private void Update()
		{
			if (joint)
			{			
				float wears = Time.deltaTime;
				joint.breakForce -= wears;
				joint.breakTorque -= wears;
			}
			else
			{
				if (isWheel)
				{
					gameObject.GetComponent<MeshCollider>().enabled = true;
					Destroy(wheel);
				}
				GameManager.Instance.controller.NoiseStrenght += noiseStrenght;
				GameManager.Instance.controller.Health -= noiseStrenght;
				RaceUIManager.Instance.SetHealth(GameManager.Instance.controller.Health);

				Destroy(this);
			}
		}
    }
}
