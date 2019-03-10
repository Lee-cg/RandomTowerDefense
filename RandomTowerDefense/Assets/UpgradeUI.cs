using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour {

	public GameObject All;
	public void Upgrade(){
		Debug.Log ("Upgrade");
		Destroy (All);
	}
}
