using UnityEngine;

namespace Player
{
	public class Headbob : MonoBehaviour
	{
		Vector3 startPostion;
		public float amplitude = .08f;
		public float times = .1f;
		public float amplitudeBreath = .08f;
		public float timesBreath = .5f;

		void Start()
		{
			startPostion = transform.localPosition;
		}

		// Update is called once per frame
		void Update()
		{
			float bobUp = Time.timeSinceLevelLoad / times;
			float spotUp = amplitude * Mathf.Sin(bobUp);

			float breath = Time.timeSinceLevelLoad / timesBreath;
			float spot = amplitudeBreath * Mathf.Sin(breath);
			transform.localPosition = startPostion + Vector3.up * spot;

			if (Input.GetKey(KeyCode.W))
			{
				transform.localPosition = startPostion + Vector3.up * spotUp;
			}
			if (Input.GetKey(KeyCode.S))
			{
				transform.localPosition = startPostion + Vector3.up * spotUp;
			}
			if (Input.GetKey(KeyCode.A))
			{
				transform.localPosition = startPostion + Vector3.up * spotUp;
			}
			if (Input.GetKey(KeyCode.D))
			{
				transform.localPosition = startPostion + Vector3.up * spotUp;
			}


		}
	}
}
