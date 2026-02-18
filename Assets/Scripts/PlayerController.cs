using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction _moveAction;
    private float _moveSpeed = 5;
    
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();

        transform.Translate(new Vector3(moveValue.x, 0, 0) * _moveSpeed * Time.deltaTime);
    }
}
