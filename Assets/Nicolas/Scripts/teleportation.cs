using UnityEngine;
using System.Collections;

public class teleportation : MonoBehaviour {

    public Vector3 porte;
    public Vector3 arrive;
	public GameObject teleportArrive;
	public GameObject cam;
	GameObject info;
    Vector3 rayEnd;
    float parab;

	// Use this for initialization
	void Update () {
        //porte = (gameObject.transform.position + gameObject.transform.forward*10 + new Vector3 (0,2,0));
        //arrive = (porte + new Vector3(0, -5, 0) + gameObject.transform.forward * 3);
        parab = Mathf.Abs(cam.transform.rotation.x * 40);
        parab = Mathf.Clamp(parab, 1, 100);
        Debug.Log(parab);
        

		if (Input.GetKey (KeyCode.Space)) 
		{
            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                {
                    rayEnd = gameObject.transform.position;
                }
                RaycastHit hit;
                Ray distanceTeleport = new Ray(rayEnd, (cam.transform.forward * 3 + new Vector3(0, 3-i, 0)));
                
                Debug.DrawLine(rayEnd, rayEnd + (cam.transform.forward * 3 + new Vector3(0, 3-i, 0)), Color.red);

                rayEnd += cam.transform.forward * 3 + new Vector3(0, 3 - i, 0);
                

                if (Physics.Raycast(distanceTeleport, out hit))
                {
                    
                    if (info == null)
                    {
                        info = Instantiate(teleportArrive);
                        break;
                    }
                    else
                    {
                        if (Vector3.Distance(rayEnd, hit.point) <= 3.0f)
                        {
                            info.transform.position = hit.point;
                            break;
                        }
                            
                                              
                    }

                   
                }

            }
            //RaycastHit hit;
			//Ray teleportCheck = new Ray (porte, gameObject.transform.forward * 3 + new Vector3(0, -3, 0)); 
			//Ray distanceTeleport = new Ray (gameObject.transform.position, (cam.transform.forward * 3 + new Vector3(0, 3, 0)));
            //Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + (cam.transform.forward * 30 + new Vector3(0,3,0)), Color.red);
            



		}

		if (Input.GetKeyUp (KeyCode.Space))
			{
			if (info) 
			{
				gameObject.transform.position = info.transform.position + new Vector3(0,1,0);
				Destroy (info);
			} else
            {
                gameObject.transform.position = gameObject.transform.position;
            }
		}

    }
	
	// Update is called once per frame
	
}
