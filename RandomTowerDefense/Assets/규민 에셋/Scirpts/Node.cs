using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

	public Vector3 positionOffset;



	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isCombind = false;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown() // 마우스 클릭시
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null) // 터렛이 이미 있으면
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return; // 터렛을 지을 수 없으면 함수를 빠져나옴

		BuildTurret(buildManager.GetTurretToBuild()); // 그 노드에 터렛 생성
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost) // 돈이 부족하면 문자 출력후 함수 빠져나옴
		{
			Debug.Log("터렛을 지을 돈이 부족합니다.");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret; // Node스크립트에 Optional 터렛 추가

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); // 빌딩 파티클 생성
		Destroy(effect, 5f);

		Debug.Log("터렛 완성!");
	}

	public void CombindTurret()
	{
		
		if (PlayerStats.Money < turretBlueprint.combindCost) // 돈이 부족하면 문자 출력후 함수 빠져나옴
		{
			Debug.Log("Not enough Gold to combind that!");
			return;
		}

		PlayerStats.Money -= turretBlueprint.combindCost;


		Destroy(turret); // 이미 지어진 터렛 삭제


		// 새로 지을 터렛 생성
		GameObject _turret = (GameObject)Instantiate(turretBlueprint.combindPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); // 빌딩 파티클 생성
		Destroy(effect, 5f);

		isCombind = true;

		Debug.Log("조합 성공!!!");
	}

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity); // 빌딩 파티클 생성


        Destroy(turret);
        turretBlueprint = null;

    }

}


