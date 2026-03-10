using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovable
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(input);
    }

    public void Move(Vector2 direction)
    {
        Vector3 move = transform.up * direction.y * moveSpeed * Time.deltaTime;
        transform.position += move;

        float rotation = -direction.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);
    }
}
