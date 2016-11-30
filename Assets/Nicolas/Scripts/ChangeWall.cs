using UnityEngine;
using System.Collections;

public class ChangeWall : MonoBehaviour {

    public GameObject bas;
    public GameObject WallPieces;
    Vector3 _hitPoint;

    void Update()
    {
        if (bas == null)
        {
            GameObject brokenWall = Instantiate(WallPieces);
            brokenWall.transform.position = transform.position;
            brokenWall.transform.parent = transform.parent;

            Destroy(gameObject);
        }
    }

	void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Player")
        {
            ContactPoint contact = player.contacts[0];
            _hitPoint = contact.point;
            GameObject brokenWall = Instantiate(WallPieces);
            brokenWall.transform.position = transform.position;
            brokenWall.transform.parent = transform.parent;
            Explode explosionPoint = brokenWall.GetComponent<Explode>();
            explosionPoint.explosionCenter = _hitPoint;
            //Debug.Log(_hitPoint);
            
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Debug.Log(_hitPoint);
        Gizmos.DrawSphere(_hitPoint, 0.1f);
    }
}
