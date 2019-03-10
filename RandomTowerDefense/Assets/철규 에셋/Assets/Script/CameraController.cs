using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f; // 최소 카메라 높이
    public float maxY = 80;  // 최대 카메라 높이
	

	void Update () {                                // 카메라 움직임 함수 

        if (GameManager.GameIsOver) // 게임오버가 활성화 되면 카메라 비활성화 
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // ESC를 누르면 화면 고정
            doMovement = !doMovement;

        if (!doMovement)
            return;
	
        if (Input.GetKey("w") )//|| Input.mousePosition.y >= Screen.height - panBorderThickness)
        {

            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s"))// || Input.mousePosition.y <= panBorderThickness)
        {

            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d"))// || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {

            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a")) //|| Input.mousePosition.x <= panBorderThickness)
        {

            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }


        //마우스휠로 카메라 조정

        float scroll = Input.GetAxis("Mouse ScrollWheel"); 

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
