using UnityEngine;
using System.Collections;

public class LasterPointer : MonoBehaviour {

	public LineRenderer lineRenderer;
	public Transform originTransform;

	RaycastHit rayCastHit;
	Ray ray;
	
	// Update is called once per frame
	void Update () 
	{
		lineRenderer.SetPosition(0, originTransform.position);

		if(Physics.Raycast(originTransform.position, this.transform.forward, out rayCastHit))
		{
			lineRenderer.SetPosition(1, rayCastHit.point);
			//Debug.DrawLine(originTransform.position, rayCastHit.point);
		}


	}
}
