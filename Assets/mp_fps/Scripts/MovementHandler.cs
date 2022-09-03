using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    Vector2 moveVector; 
    public float moveSpeed = 5;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void SetMoveVector(Vector2 vec) {
        moveVector = vec;
    }

    void Update()
    {
        Move();
    }

    void Move() {
        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y);
        controller.Move(move * (moveSpeed * Time.deltaTime));
    }
}

