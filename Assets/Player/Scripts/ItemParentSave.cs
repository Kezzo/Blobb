using UnityEngine;
using System.Collections;

public class ItemParentSave {

	GameObject _itemGameObject;
	public GameObject ItemGameObject
	{
		get
		{
			return _itemGameObject;
		}
		set
		{
			_itemGameObject = value;
		}
	}

	Transform _parent;
	public Transform parent
	{
		get
		{
			return _parent;
		}
		set
		{
			_parent = value;
		}
	}


	public ItemParentSave(GameObject item, Transform parent)
	{
		this._itemGameObject = item;
		this._parent = parent;
	}

}
