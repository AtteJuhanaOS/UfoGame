using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBeamScript : MonoBehaviour {

    public ConstantForce gravity;
    private float maxBeamableWeight = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter(Collider colliderObject)
    {
        if(colliderObject.gameObject.tag=="BeamableObject")
        {
            ConstantForce forceToApply;
            forceToApply = colliderObject.gameObject.AddComponent<ConstantForce>();
            forceToApply.force = new Vector3(0, colliderObject.gameObject.GetComponent<BeamableObjectScript>().objectWeight*12, 0);
            
        }
    }

    private void OnTriggerExit(Collider colliderObject)
    {
        if (colliderObject.gameObject.tag == "BeamableObject")
        {
            var constantForce = colliderObject.gameObject.GetComponent<ConstantForce>();
            Destroy(constantForce);
            Debug.Log("DESTROY: " + colliderObject);
        }
    } 
}
