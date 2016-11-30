using UnityEngine;
using System.Collections;


public class Explode : MonoBehaviour {

    public Vector3 explosionCenter;
    public float explosionRadius;
    
   

	// Use this for initialization
	void Start () {

        Debug.Log(explosionCenter);
        explosionRadius = 1000;
              
        foreach (Transform child in transform)
        {
            
            child.GetComponent<Rigidbody>().AddExplosionForce(3000, explosionCenter, explosionRadius);
            
        }

       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
