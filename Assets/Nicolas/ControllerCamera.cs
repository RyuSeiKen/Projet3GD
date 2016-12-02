using UnityEngine;
using System.Collections;

public class ControllerCamera : MonoBehaviour {

    public GameObject Player;

    Camera _camera;

    public float _maxCameraSensivity;
    float CameraSensivity;
    float _hMove;
    float _vMove;

    public Vector3 _cameraOffset;

    // Use this for initialization
    void Start () {
        CameraSensivity = _maxCameraSensivity;
        _camera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
       
        _hMove = Input.GetAxis("Camera Horizontal");
        _vMove = Input.GetAxis("Camera Vertical");

        gameObject.transform.position = Player.transform.position + _cameraOffset;
        gameObject.transform.Rotate(0, _hMove * CameraSensivity * Time.deltaTime, 0);
        _camera.transform.RotateAround(gameObject.transform.position, gameObject.transform.right, _vMove * CameraSensivity * Time.deltaTime);
        _camera.transform.LookAt(gameObject.transform);
    }
} 