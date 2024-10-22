using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.position += (Vector3)movement * speed * Time.deltaTime;
    }
}
