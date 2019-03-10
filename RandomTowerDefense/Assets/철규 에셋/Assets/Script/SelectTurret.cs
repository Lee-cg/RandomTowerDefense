using UnityEngine;

public class SelectTurret : MonoBehaviour
{

    public TurretBlueprint[] randomTurret;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

        buildManager.SelectTurretToBuild(randomTurret[Random.Range(0, randomTurret.Length)]);
    }

    void Update()
    {

        buildManager.SelectTurretToBuild(randomTurret[Random.Range(0, randomTurret.Length)]);  // 게임을 시작하면, randomTurret을 기본 터렛으로 설정
    }
}


