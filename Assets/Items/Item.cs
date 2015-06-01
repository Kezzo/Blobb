using UnityEngine;
using System.Collections;

public interface Item {

	void UseOnce();
	void Reload();
	void OnEquip();
	void OnDeequip();
	string getType();
}
