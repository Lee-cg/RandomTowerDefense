using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver = false;

    public GameObject gameOverUI;

   void Start()
    {
        GameIsOver = false; // 게임이 시작되면 GameIsOver 비활성화
    }

	void Update () {

        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e")) // 디버그용 게임오버
        {
            EndGame();
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	
	}

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
