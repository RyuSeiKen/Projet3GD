using UnityEngine;
using System.Collections;

public class ControllerManette : MonoBehaviour {

	public GameObject _pivot;
    public GameObject _gravityCenter;

    GameObject _ground;

    Camera _camera;

    CharacterController _character;

    public float _gravityAccelRatio;
    public float MoveSensivity;
    public float _maxSpeed;
    public float _jumpSpeed;

    float _gravityAccel;
    float _speed;
    float _hMove;
    float _vMove;

    public Vector3 Gravity;

    Vector3 _hDisplacment;
    Vector3 _vDisplacment;
    Vector3 _velocity;
    Vector3 _gravityVelocity;
    Vector3 _jumpVelocity;

    bool IsWalking;

    // Use this for initialization
    void Start () {

        _character = gameObject.GetComponent<CharacterController>();
        _camera = FindObjectOfType<Camera>();
        _speed = _maxSpeed; 

    }
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;

		Ray find = new Ray(gameObject.transform.position, new Vector3(0, -1, 0));

		if (Physics.Raycast (find, out hit) && Vector3.Distance (gameObject.transform.position, hit.point) < 2) {


			if (_ground != hit.transform.gameObject || _ground == null) {
				_gravityCenter.transform.up = hit.transform.up;
				_gravityCenter.transform.Rotate (_pivot.transform.localRotation.eulerAngles);
				_ground = hit.transform.gameObject;
								
			} 

			if (_gravityCenter.transform.up == _pivot.transform.up) 
			{
				_gravityCenter.transform.up = _pivot.transform.up;
				_gravityCenter.transform.right = _pivot.transform.right;
				_gravityCenter.transform.forward = _pivot.transform.forward;
			}


		} else 
		{
			_ground = null;
			_gravityCenter.transform.up = _pivot.transform.up;
			_gravityCenter.transform.right = _pivot.transform.right;
			_gravityCenter.transform.forward = _pivot.transform.forward;
		}

		//Debug.Log (_gravityCenter.transform.up +" "+ hit.transform.up);
		gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, new Vector3(_hDisplacment.x +_vDisplacment.x,0, _hDisplacment.z + _vDisplacment.z), 0.45f);

        _hMove = Input.GetAxis("Horizontal");
        _vMove = Input.GetAxis("Vertical");

        _hDisplacment = _gravityCenter.transform.right * _hMove;
        _vDisplacment = _gravityCenter.transform.forward * _vMove;
		    
		               
        if (Input.GetButton("Jump"))
        {
            _jumpVelocity = Vector3.up * _jumpSpeed;
        }
    }

    void FixedUpdate()
    {
        //Apply Move
        _velocity = (_hDisplacment + _vDisplacment) * _speed * MoveSensivity;

        // Apply gravity
        _gravityAccel += _gravityAccelRatio;
        _gravityAccel = Mathf.Clamp(_gravityAccel, 0, 10);
        _gravityVelocity += Gravity * Time.deltaTime * _gravityAccel;
        _velocity += _gravityVelocity;

        // Add jump velocity
        _velocity += _jumpVelocity;

        CollisionFlags cFlags = _character.Move(_velocity * Time.deltaTime);

        if( _velocity.y < 0 &&
            (cFlags & CollisionFlags.Below) != CollisionFlags.None)
        {
            
            // Collided with ground
            _jumpVelocity = Vector3.zero;
            _gravityVelocity = Vector3.zero;
            _gravityAccel = 0;
            
        }  			                      
        _velocity = Vector3.zero;
               
    }
}
