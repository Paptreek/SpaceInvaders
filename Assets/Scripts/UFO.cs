using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * _moveSpeed * Time.deltaTime);
    }
}
