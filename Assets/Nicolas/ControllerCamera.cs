using UnityEngine;
using System.Collections;

public class ControllerCamera : MonoBehaviour {

	public GameObject Player;
    public GameObject _gravityCenter;

    Camera _camera;

    public float _maxCameraSensivity;
    float CameraSensivity;
    float _hMove;
    float _vMove;

	public Vector3 _cameraOffset;
    public Vector3 _pivotRotation;

    // Use this for initialization
    void Start () {
        CameraSensivity = _maxCameraSensivity;
        _camera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
       
        _hMove = Input.GetAxis("Camera Horizontal");
        _vMove = Input.GetAxis("Camera Vertical");

		_pivotRotation = new Vector3(0, _hMove * CameraSensivity * Time.deltaTime, 0);

        gameObject.transform.position = Player.transform.position + _cameraOffset;
		gameObject.transform.Rotate(_pivotRotation, Space.Self);
		_gravityCenter.transform.Rotate(_pivotRotation, Space.Self);
        _camera.transform.RotateAround(gameObject.transform.position, gameObject.transform.right, _vMove * CameraSensivity * Time.deltaTime);
        _camera.transform.LookAt(gameObject.transform);


    }

	void FixedUpdate()
	{
		
	}


} 