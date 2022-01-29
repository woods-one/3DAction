using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

	float depth = 1f;
	Vector3 rightTop;
    Vector3 leftBottom;
	[SerializeField] private Camera came;

    void Start()
    {
        rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height, Screen.width, depth));
        leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, depth));
    }
    void Update()
	{
        this.transform.position = new Vector3(Screen.height/4, Screen.width/2, 0);
    }
}