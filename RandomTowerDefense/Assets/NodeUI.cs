using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
	public GameObject ui;
	
	private Node target;
	public Text UpgradeText;
	public Button UpgradeButton;

	public void SetTarget(Node _target)
	{
		UpgradeButton.interactable = true;
		this.target = _target;
		transform.position = target.GetBuildPosition ();

		if (target.isCombind) {
			UpgradeText.text = "FULL";
			UpgradeButton.interactable = false;
		} else {
			UpgradeText.text = "Upgrade";
			UpgradeButton.interactable = true;
		}

		ui.SetActive (true);
	
	}
	public void Hide(){
		ui.SetActive (false);
		
	}
	public void Upgrade(){
		Debug.Log ("업그레이드!!");
		target.CombindTurret();
		BuildManager.instance.DeselectNode();
	}

    public void Sell()
    {
        Debug.Log("절반의 가격으로 되팔기!!");
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
