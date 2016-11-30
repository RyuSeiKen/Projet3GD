using UnityEngine;
using System.Collections;

public class ChangePower : MonoBehaviour {

    public KeyCode teleport;
    public KeyCode destruction;
    public KeyCode dobble;

    public teleportation teleportScript;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(teleport))
        {
            gameObject.tag = "Untagged";
            
            teleportScript.enabled = true;
        }

        if (Input.GetKeyDown(destruction))
        {
            gameObject.tag = "Player";
            
            teleportScript.enabled = false;
        }

        if (Input.GetKeyDown(dobble))
        {
            gameObject.tag = "Player";
            
            teleportScript.enabled = true;
        }


    }
}
