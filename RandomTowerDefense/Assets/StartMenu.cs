using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public string gameStart = "1.Game";
	public GameObject Helper;
	public GameObject tower;

	public void Play()
	{
		SceneManager.LoadScene (gameStart);
	}
	public void Help(){
		Helper.SetActive (true);
		Destroy (tower);
	}
	public void Quit()
	{
        Debug.Log("게임을 종료합니다.");
		Application.Quit ();
	}
}
