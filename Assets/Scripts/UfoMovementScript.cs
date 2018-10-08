using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoMovementScript : MonoBehaviour {

    public GameObject ufoModel;
    public GameObject ufoRaycastPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float maxUfoRotation = 13.0f;
        float moveSpeed = 5;

        if (horizontalInput != 0 || verticalInput != 0)
        {
            ufoModel.transform.localRotation = Quaternion.Euler(-verticalInput*maxUfoRotation, 0, -horizontalInput * maxUfoRotation);
            transform.position = transform.position + new Vector3(horizontalInput * Time.deltaTime * moveSpeed, 0, -verticalInput * Time.deltaTime * moveSpeed);
        }
        //Raycast down
        Vector3 directionDown = -ufoRaycastPoint.transform.up;

        float moveUpDownSpeed = 10;

        if(Physics.Raycast(ufoRaycastPoint.transform.position, directionDown, 1.75f))
        {
            transform.position = transform.position + new Vector3(0, moveUpDownSpeed * Time.deltaTime,0);
        }
        else if(Physics.Raycast(ufoRaycastPoint.transform.position, directionDown, 2.0f))
        {
           
        }
        else
        {
            transform.position = transform.position + new Vector3(0, -moveUpDownSpeed/5 * Time.deltaTime, 0);
        }
    }

    
}
