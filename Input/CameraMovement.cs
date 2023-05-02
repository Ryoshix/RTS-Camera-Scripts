using UnityEngine;

public sealed class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _smoothing = 5f;
    [SerializeField] private Vector2 _boundsRange = new Vector2(100f, 100f);
    
    private Vector3 _targetPosition;
    private Vector3 _input;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(_boundsRange.x * 2f, 0f, _boundsRange.y * 2f));
    }

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        HandleInput();
        TryToMove();
    }

    void TryToMove()
    {
        Vector3 nextTargetPosition = _targetPosition + _input * _speed;

        if (IsInBounds(nextTargetPosition))
            _targetPosition = nextTargetPosition;

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _smoothing);
    }

    bool IsInBounds(Vector3 position)
    {
        return position.x > -_boundsRange.x &&
               position.x < _boundsRange.x &&
               position.z > -_boundsRange.y &&
               position.z < _boundsRange.y;
    }
    
    public void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw(InputAxis.Horizontal);
        float verticalInput = Input.GetAxisRaw(InputAxis.Vertical);

        Vector3 rightVector = transform.right * horizontalInput;
        Vector3 forwardVector = transform.forward * verticalInput;

        _input = (forwardVector + rightVector).normalized;
    }
}
