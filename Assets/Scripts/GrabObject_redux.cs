using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject_redux : MonoBehaviour
{
    public float mCorrectionForce = 10000.0f;
    public float mPointDistance = 1.2f;
    public float mPointHeight = 0.1f;
    public GameObject heldObject;
    int layerMask;
    bool objectGrabbable;
    bool isHolding;

    private void Start()
    {
        layerMask = 1 << 8;
        layerMask = ~layerMask;
        isHolding = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) TryGrab();
    }
    void FixedUpdate()
    {
        if (objectGrabbable && Input.GetKey(KeyCode.E))
        {
            if (heldObject.GetComponent<Rigidbody>().constraints != RigidbodyConstraints.FreezeRotation)
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            Vector3 targetPoint = transform.position;
            targetPoint += Camera.main.transform.forward * mPointDistance;
            targetPoint += Camera.main.transform.up * mPointHeight;
            Vector3 force = targetPoint - heldObject.transform.position;

            heldObject.GetComponent<Rigidbody>().velocity = force.normalized * heldObject.GetComponent<Rigidbody>().velocity.magnitude;
            heldObject.GetComponent<Rigidbody>().AddForce(force * mCorrectionForce);

            heldObject.GetComponent<Rigidbody>().velocity *= Mathf.Min(1.0f, force.magnitude / 2);
            Vector3 objEuler = transform.rotation.eulerAngles;
            objEuler.x += 90.0f;
            Quaternion objRotation = Quaternion.Euler(objEuler);
            heldObject.transform.rotation = objRotation;
        }
		else
		{
            if (heldObject)
			    heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            objectGrabbable = false;
			heldObject = null; 
		}

	if (objectGrabbable && Input.GetMouseButton(0))
        {
		if (heldObject.GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezeRotation)
                	heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
	
		heldObject.GetComponent<Rigidbody>().AddTorque(Vector3.up * 1000f);

		heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
	}

    }

    void TryGrab()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (hit.rigidbody /*&& hit.rigidbody.gameObject.name == "hammer"*/)
            {
                objectGrabbable = true;
				heldObject = hit.transform.gameObject; 
            }
        }
        else
        {
            objectGrabbable = false;
			heldObject = null; 
        }
    }
}
