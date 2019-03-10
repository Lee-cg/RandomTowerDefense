using UnityEngine;
using System.Collections;


[System.Serializable] // Shop 스크립트에서 Prefab과 Cost의 수치를 조정할 수 있는 코드

public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject combindPrefab;
    public int combindCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
