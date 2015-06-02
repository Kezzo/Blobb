using UnityEngine;
using System.Collections;

public class SaveTransform {

	private Vector3 _position;
	public Vector3 position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	private Quaternion _rotation;
	public Quaternion rotation
	{
		get
		{
			return _rotation;
		}
		set
		{
			_rotation = value;
		}
	}

	private Vector3 _scale;
	public Vector3 scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale = value;
		}
	}

	public SaveTransform(Transform transform)
	{
		this.position = transform.position;
		this.rotation = transform.rotation;
		this.scale = transform.localScale;
	}
}
