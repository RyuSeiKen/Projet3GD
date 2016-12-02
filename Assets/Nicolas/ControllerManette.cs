using UnityEngine;
using System.Collections;

public class ControllerManette : MonoBehaviour {

    public GameObject _pivot;
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
    
        _hMove = Input.GetAxis("Horizontal");
        _vMove = Input.GetAxis("Vertical");

        _hDisplacment = _camera.transform.right * _hMove;
        _vDisplacment = _pivot.transform.forward * _vMove;

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            IsWalking = false;                        
        }
        else
        {
            IsWalking = true;          
        }

               
        if (Input.GetButton("Fire1"))
        {
            _jumpVelocity = Vector3.up * _jumpSpeed;
        }
    }

    void FixedUpdate()
    {
        //Apply Move
        //_velocity = new Vector3(_hMove, 0, _vMove) * _speed * MoveSensivity;
        _velocity = (_hDisplacment + _vDisplacment) * _speed * MoveSensivity;

        // Apply gravity
        _gravityAccel += _gravityAccelRatio;
        _gravityAccel = Mathf.Clamp(_gravityAccel, 0, 1);
        _gravityVelocity += Gravity * Time.deltaTime * _gravityAccel;
        _velocity += _gravityVelocity;

        // Add jump velocity
        _velocity += _jumpVelocity;

        CollisionFlags cFlags = _character.Move(_velocity * Time.deltaTime);

        if( _velocity.y < 0 &&
            (cFlags & CollisionFlags.Below) != CollisionFlags.None)
        {
            Debug.Log(_velocity);
            // Collided with ground
            _jumpVelocity = Vector3.zero;
            _gravityVelocity = Vector3.zero;
            _gravityAccel = 0;
            
        }


        /*RaycastHit hit;
        Ray find = new Ray(gameObject.transform.position, new Vector3(0, -1, 0));

        if (Physics.Raycast(find, out hit) && Vector3.Distance(gameObject.transform.position, hit.point) < 2)
        {
            gameObject.transform.up = hit.transform.up;
        }*/

        if (IsWalking == true)
        {
            gameObject.transform.forward = new Vector3(_hDisplacment.x +_vDisplacment.x,0, _hDisplacment.z + _vDisplacment.z);
        }
                      
        _velocity = Vector3.zero;
        
       
    }
}
