using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[] points;  //클래스 배열 points 선언
    
    void Awake() 
    {
        points = new Transform[transform.childCount]; // 자식의 수를 인덱스값으로 가지는 Transform 클래스 배열 
        
        for (int i = 0; i < points.Length; i++) // points의 자식 초기화
        {
            points[i] = transform.GetChild(i);

        }

    }
}