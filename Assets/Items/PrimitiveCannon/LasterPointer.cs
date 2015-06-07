using UnityEngine;
using System.Collections;

public class LasterPointer : MonoBehaviour {

	public LineRenderer lineRenderer;
	public Transform originTransform;

	RaycastHit rayCastHit;
	Ray ray;

	Vector3 endPoint;
	
	// Update is called once per frame
	void Update () 
	{
		lineRenderer.SetPosition(0, originTransform.position);
		
		if (Physics.Raycast (originTransform.position, this.transform.forward, out rayCastHit, 50.0f)) {
			endPoint = rayCastHit.point;
			//Debug.DrawLine(originTransform.position, rayCastHit.point);
		} else {
			endPoint = originTransform.position + this.transform.forward * 50.0f;
		}

		lineRenderer.SetPosition (1, endPoint);

	}
}
