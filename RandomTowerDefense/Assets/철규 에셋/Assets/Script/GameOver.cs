using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string gameMenu = "0.Start";


    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // GameOver후 Retry 버튼을 누르면 다시 시작
    }

    public void Menu()
    {
        Debug.Log("Go to Menu.");
        SceneManager.LoadScene(gameMenu); // 메뉴씬으로 가기
    }
}