using UnityEngine;

public sealed class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _smoothing = 5f;

    private float _targetAngle;
    private float _currentAngle;

    private void Awake()
    {
        _targetAngle = transform.eulerAngles.y;
        _currentAngle = _targetAngle;
    }

    private void Update()
    {
        HandleInput();
        Rotate();
    }

    void Rotate()
    {
        _currentAngle = Mathf.Lerp(_currentAngle, _targetAngle, Time.deltaTime * _smoothing);
        transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.up);
    }
    
    public void HandleInput()
    {
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
            _targetAngle += Input.GetAxisRaw(InputAxis.MouseX) * _speed;
        else if (Input.GetAxis(InputAxis.HorizontalQE) != 0)
            _targetAngle += Input.GetAxisRaw(InputAxis.HorizontalQE) * _speed;
    }
}