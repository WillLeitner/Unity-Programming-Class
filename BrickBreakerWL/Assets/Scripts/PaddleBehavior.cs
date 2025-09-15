using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
 public float Speed = 5.0f;

    public KeyCode RightDirection;
    public KeyCode LeftDirection;
    public GameObject PaddleObject;
    public Transform PaddleTransform; 
    void Start()
    {
        PaddleObject = GameObject.Find("Paddle");
    }

    void Update()
    {
        float movement = 0.0f;
        
        PaddleTransform = PaddleObject.GetComponent<Transform>();

        if (Input.GetKey(RightDirection) && ((PaddleTransform.position.x) <= 9.47))
        {
            movement += Speed;
        }

        if (Input.GetKey(LeftDirection) && ((PaddleTransform.position.x) >= -9.47))
        {
            movement -= Speed;
        }

        transform.position += new Vector3(movement * Time.deltaTime, 0.0f, 0.0f);

        Debug.Log(PaddleTransform.position.x);
    }
}
