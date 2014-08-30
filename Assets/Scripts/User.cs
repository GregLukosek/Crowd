using UnityEngine;
using System.Collections;

public class User : MonoBehaviour 
{
	public float speed = 5f;
	public float rotationSensitivity = 60f;

	void Update()
	{
		transform.localPosition += (transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
		transform.Rotate(Vector3.up * Time.deltaTime * Input.GetAxis("Horizontal") * rotationSensitivity, Space.World);

	}


}
