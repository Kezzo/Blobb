using UnityEngine;
using System.Collections;

public interface Item {

	void UseOnce();
	void Reload();
	string getType();
}
