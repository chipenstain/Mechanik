using UnityEngine;

namespace Mechanik
{
    public class CarController : MonoBehaviour
    {
		//==============GENERAL PROPERTIES================
		private Camera cam;

		private bool active = false;

		private float health = 1;

		//==============MOVING PROPERTIES================
		private float speed = 0f;
		[SerializeField] private float maxSpeed = 600f;
		private float speedTime = 0f;

		private float strenghtOfSteerling;
		private float[] noise = new float[10];
		private float noiseStrenght = 0f;

		//==============JOINTS OF THE PARTS================
		[SerializeField] private FixedJoint hoodJoint;
		[SerializeField] private FixedJoint trunkJoint;
		[SerializeField] private FixedJoint spoilerJoint;
		[SerializeField] private FixedJoint[] glassesJoint;
		[SerializeField] private FixedJoint[] doorsJoint;
		[SerializeField] private FixedJoint[] wheelsJoint;

		//==============WHEEL COLLIDERS================
		[SerializeField] private GameObject[] steersWheels;
		[SerializeField] private WheelCollider[] motorsWheelsCols;
		[SerializeField] private WheelCollider[] steersWheelsCols;
		[SerializeField] private MeshCollider[] wheelsStaticCols;

		//==============================================
		public float NoiseStrenght { get => noiseStrenght; set => noiseStrenght = value; }
		public float Health { get => health; set => health = value; }

		//==============UNITY METHODS================
		private void Awake()
		{
			cam = Camera.main;

			for (int i = 0; i < 10; i++)
			{
				noise[i] = Random.Range(5f, 10f);
			}
		}

		private void Start()
		{
			if (steersWheelsCols[0]) steersWheelsCols[0].steerAngle = 0f;
			if (steersWheelsCols[1]) steersWheelsCols[1].steerAngle = 0f;
			if (steersWheelsCols[0]) steersWheels[0].transform.eulerAngles = Vector3.up * 0f;
			if (steersWheelsCols[1]) steersWheels[1].transform.eulerAngles = Vector3.up * 0f;
		}

		private void Update()
		{
			if (active)
			{
				speedTime += Time.deltaTime / 3f;
				speed = Mathf.Lerp(0, maxSpeed, speedTime);

				if (Input.touchCount > 0)
				{
					Touch touch = Input.GetTouch(0);

					float touchPoint = cam.ScreenToViewportPoint(touch.position).x;

					if (touchPoint > 0.5f) strenghtOfSteerling = touchPoint - 0.5f;
					else strenghtOfSteerling = touchPoint;
					strenghtOfSteerling *= 2f;

					if (touch.phase == TouchPhase.Stationary)
					{
						if (touchPoint <= 0.5f)
						{
							speedTime = 0f;
							float noisePower = noise[Random.Range(0,10)] * noiseStrenght;

							if (steersWheelsCols[0]) steersWheelsCols[0].steerAngle = -35f * (1 - strenghtOfSteerling) + noisePower;
							if (steersWheelsCols[1]) steersWheelsCols[1].steerAngle = -35f * (1 - strenghtOfSteerling) + noisePower;
							if (steersWheelsCols[0]) steersWheels[0].transform.localEulerAngles = Vector3.up * (-35f * (1 - strenghtOfSteerling) + noisePower);
							if (steersWheelsCols[1]) steersWheels[1].transform.localEulerAngles = Vector3.up *(-35f * (1 -strenghtOfSteerling) + noisePower);
						}
						else
						{
							speedTime = 0f;
							float noisePower = noise[Random.Range(0,10)] * noiseStrenght;

							if (steersWheelsCols[0]) steersWheelsCols[0].steerAngle = 35f * strenghtOfSteerling - noisePower;
							if (steersWheelsCols[1]) steersWheelsCols[1].steerAngle = 35f * strenghtOfSteerling - noisePower;
							if (steersWheelsCols[0]) steersWheels[0].transform.localEulerAngles = Vector3.up * (35f * strenghtOfSteerling + noisePower);
							if (steersWheelsCols[1]) steersWheels[1].transform.localEulerAngles = Vector3.up * (35f * strenghtOfSteerling + noisePower);
						}
					}
				}
				else
				{
					if (steersWheelsCols[0]) steersWheelsCols[0].steerAngle = 0f;
					if (steersWheelsCols[1]) steersWheelsCols[1].steerAngle = 0f;
					if (steersWheelsCols[0]) steersWheels[0].transform.localEulerAngles = Vector3.up * 0f;
					if (steersWheelsCols[1]) steersWheels[1].transform.localEulerAngles = Vector3.up * 0f;
				}
			}
		}

		private void FixedUpdate()
		{
			if (active)
			{
				if (motorsWheelsCols[0]) motorsWheelsCols[0].motorTorque = speed;
				if (motorsWheelsCols[1]) motorsWheelsCols[1].motorTorque = speed;
			}
		}

		//==============CUSTOM METHODS================
		public void Activate()
		{
			for (int i = 0; i < GameManager.Instance.ToolsOfCar.Count; i++)
			{
				LineRenderer toolCast = Instantiate(GameManager.Instance.ToolsOfCar[i].render, transform).GetComponent<LineRenderer>();
				toolCast.positionCount = GameManager.Instance.ToolsOfCar[i].positions.Length;
				toolCast.SetPositions(GameManager.Instance.ToolsOfCar[i].positions);
			}

			wheelsStaticCols[0].enabled = false;
			wheelsStaticCols[1].enabled = false;
			wheelsStaticCols[2].enabled = false;
			wheelsStaticCols[3].enabled = false;
			motorsWheelsCols[0].enabled = true;
			motorsWheelsCols[1].enabled = true;
			steersWheelsCols[0].enabled = true;
			steersWheelsCols[1].enabled = true;

			active = true;

			hoodJoint.breakForce = GameManager.Instance.HoodStrenght;
			trunkJoint.breakForce  = GameManager.Instance.TrunkStrenght;
			spoilerJoint.breakForce = GameManager.Instance.SpoilerStrenght;
			glassesJoint[0].breakForce = GameManager.Instance.GlassesStrenght[0];
			glassesJoint[1].breakForce = GameManager.Instance.GlassesStrenght[1];
			doorsJoint[0].breakForce = GameManager.Instance.DoorsStrenght[0];
			doorsJoint[1].breakForce = GameManager.Instance.DoorsStrenght[1];
			wheelsJoint[0].breakForce = GameManager.Instance.WheelsStrenght[0];
			wheelsJoint[1].breakForce = GameManager.Instance.WheelsStrenght[1];
			wheelsJoint[2].breakForce = GameManager.Instance.WheelsStrenght[2];
			wheelsJoint[3].breakForce = GameManager.Instance.WheelsStrenght[3];

			hoodJoint.breakTorque = GameManager.Instance.HoodStrenght;
			trunkJoint.breakTorque  = GameManager.Instance.TrunkStrenght;
			spoilerJoint.breakTorque = GameManager.Instance.SpoilerStrenght;
			glassesJoint[0].breakTorque = GameManager.Instance.GlassesStrenght[0];
			glassesJoint[1].breakTorque = GameManager.Instance.GlassesStrenght[1];
			doorsJoint[0].breakTorque = GameManager.Instance.DoorsStrenght[0];
			doorsJoint[1].breakTorque = GameManager.Instance.DoorsStrenght[1];
			wheelsJoint[0].breakTorque = GameManager.Instance.WheelsStrenght[0];
			wheelsJoint[1].breakTorque = GameManager.Instance.WheelsStrenght[1];
			wheelsJoint[2].breakTorque = GameManager.Instance.WheelsStrenght[2];
			wheelsJoint[3].breakTorque = GameManager.Instance.WheelsStrenght[3];
		}
	}
}
