using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public Camera _camera;

	public float shakeAmount = 0.6f;
	public float decrease = 1f;

	private Transform initialPos;

	private static float shake;

	void Start ()
	{
		shake = 0f;

        initialPos = _camera.transform;
	}

	void Update ()
	{
		if (shake > 0f)
		{
			_camera.transform.position =  Random.insideUnitCircle * shakeAmount ;
            Vector3 tmp = _camera.transform.position;
            _camera.transform.position = new Vector3(tmp.x, tmp.y, -10f); // the bug was the Z position of camera

			shake -= Time.deltaTime * decrease;
        } else
		{
			shake = 0f;
			_camera.transform.position = new Vector3(0,0,-10f);
		}
	}

	public void Shake (float amount)
	{
		shake = amount;
        Debug.Log("shake");
	}

}
