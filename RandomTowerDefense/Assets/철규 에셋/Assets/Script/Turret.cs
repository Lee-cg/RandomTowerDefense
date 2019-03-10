using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float firCountdown = 0f;

    [Header("Use Raser")]

    public bool useLaser = false;
    public int damageOverTime = 30;

    public LineRenderer lineRenderer;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform PartToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

	// Use this for initialization
	void Start () {

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	
	}
	
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distantToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distantToEnemy < shortestDistance)
            {
                shortestDistance = distantToEnemy;
                nearestEnemy = enemy;

            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null; // no more enemy reset target
        }
    }

	// Update is called once per frame
	void Update () {
        if (target == null) // 적이 터렛 범위에서 사라지면
        {
            if (useLaser) // 레이저 터렛이면
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false; // 레이저 제거
            }
            return; 
        }
           

        LockOneTarget(); // 타겟 고정

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (firCountdown <= 0f)
            {
                Shoot();
                firCountdown = 1f / fireRate;
            }

            firCountdown -= Time.deltaTime;
        }    
	}

    void LockOneTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // re-target enemy, natural motion
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser() // 레이저의 길이는
    {
        targetEnemy.TakeDamage(damageOverTime *Time.deltaTime);

        if (!lineRenderer.enabled) // 레이저 사용이 false로 돼있으면
            lineRenderer.enabled = true; // 레이저 사용을 true로 변경

        lineRenderer.SetPosition(0, firePoint.position); // 레이저 터렛의 총구에서
        lineRenderer.SetPosition(1, target.position); // 적의 위치까지

    }

    void Shoot()
    {
       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
