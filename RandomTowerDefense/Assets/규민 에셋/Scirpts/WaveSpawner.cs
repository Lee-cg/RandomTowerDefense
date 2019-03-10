using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

	public Transform enemy_lv1;
	public Transform enemy_lv2;
	public Transform enemy_lv3;
	public Transform enemy_lv4;
	public Transform enemy_lv5;
	public Transform spawnPoint;

	public float timebetweenwaves = 1f; // 몬스터 리젠시간
	private float countdown = 1f; // 첫 웨이브 생성 시간
	private float RoundTime = 60f; //내가넣은것

	public Text waveCountdownText;
	public Text RoundNumber; //라운드텍스트

	private int waveIndex = 1;
	public static int Round=1;
	float Timer = 60;
	int Golem = 10;
	int Boss = 2;

	void Update()
	{

		if (Timer >= 20f) {
			if (countdown <= 0f)
			{
				StartCoroutine(SpawnWave());
				//countdown = timebetweenwaves; // 첫 번째 웨이브 생성후, 다음 웨이브 생성 시간 초기화
			}
		}
		else if(Timer<=0f)
		{
			Timer = RoundTime;
			Round++; //round 증가
		//	timebetweenwaves = timebetweenwaves+0.5f;
		}
		countdown -= Time.deltaTime; Timer -= Time.deltaTime; //시간 줄어들기
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); 
		Timer = Mathf.Clamp(Timer, 0f, Mathf.Infinity); //시간줄어들기
		RoundNumber.text ="Round : " + Round.ToString(); //라운드수 표

		waveCountdownText.text = "WaveTimes : " + string.Format("{00:00}", Timer); // 00.00 포맷으로 적용


	}

	IEnumerator SpawnWave()
	{
		// waveIndex++;
		//  PlayerStats.Rounds++;

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy ();
			yield return new WaitForSeconds(1f); 
		}

	}

	void SpawnEnemy () // 적 생성 함수
	{
		switch (Round) {
		case 1:
			Instantiate (enemy_lv1, spawnPoint.position, spawnPoint.rotation);
			countdown = 1f;
			break;
		case 2:
			Instantiate (enemy_lv2, spawnPoint.position, spawnPoint.rotation);
			countdown = 1.3f;
			break;
		case 3:

			if (Golem > 0) {
				Instantiate (enemy_lv3, spawnPoint.position, spawnPoint.rotation);
				Golem--;
				countdown = 4f;
				break;
			} else {
				
				break;
			}
				
		case 4:
			Instantiate (enemy_lv4, spawnPoint.position, spawnPoint.rotation);
			countdown = 2f;
			break;

		case 5:
			
			if (Boss > 0) {
				Instantiate (enemy_lv5, spawnPoint.position, spawnPoint.rotation);
				Boss--;
				countdown = 30;
				break;
			} else {
				
				break;
			}
            



		}
	}
}