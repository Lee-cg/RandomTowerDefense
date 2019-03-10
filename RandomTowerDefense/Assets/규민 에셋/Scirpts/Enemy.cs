using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour {

    public float speed = 10f;

    public float startHealth = 100;
    private float health;

    public int value = 50;
	public Transform enemyPrefab;
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private Transform target; // Enemy가 이동할 target
   

    private int waypointIndex = 0;

    void Start ()
    {
        target = Waypoints.points[0]; //시작하면 몬스터가 0번째 waypoint를 타겟으로 잡는다.
        health = startHealth;
    }


    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth; // 체력바 설정 : fillAmount는 0에서 1의 값을 가지므로 startHealth를 나눈다.

        if (health <= 0)
        {
            Die();
        }
      
    }

    void Die()
    {
		switch (WaveSpawner.Round) {
		case 1:
			PlayerStats.Money += 10;
			break;
		case 2:
			PlayerStats.Money += 15;
			break;
		case 3:
			PlayerStats.Money += 55;
			break;
		case 4:
			PlayerStats.Money += 25;
			break;
		case 5:
			PlayerStats.Money += 500;
			break;
		}

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
                
        Destroy(gameObject);
   
    }

    void Update()

    {
        Vector3 dir = target.position - transform.position; // 타겟의 위치 - 자신의 위치 = 이동하고자 하는 방향
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) // Enemy가 target을 만날시 다음 target 전환
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();            
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
		transform.LookAt (target);
    }

    void EndPath()
    {
        Destroy(gameObject); // 마지막 target을 만나면 오브젝트 소멸
        PlayerStats.Lives--;
    }

    }
