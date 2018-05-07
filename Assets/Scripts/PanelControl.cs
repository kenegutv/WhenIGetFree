using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour {
    public Light linktoLight;
    public bool lightControl;


	// Use this for initialization
	void Start () {
        //if (lightControl == false)
        // linktoLight.enabled = false;
        ControlLight();
    }
	
	// Update is called once per frame
	void Update () {
        ControlLight();
	}
    void ControlLight() {
        /*
        if (lightControl == false)
            linktoLight.enabled = false;
            */
            
        linktoLight.enabled = lightControl;
    }
    void OnTriggerEnter(Collider other)   
    {
        Debug.Log("object enter panel trigger");
        linktoLight.enabled = lightControl;
        if (lightControl == true)
        {

            lightControl = false;
        }
        else
        {
            //if (myBool == true){
            lightControl = true;
        }
    }
    }
