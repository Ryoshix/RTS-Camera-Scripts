using UnityEngine;

public sealed class CameraZoom : MonoBehaviour
{
    [SerializeField] private Transform _cameraHolderTransform;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _smoothing = 5f;
    [SerializeField] private Vector2 _boundsRange = new Vector2(20f, 70f);

    private Vector3 _targetPosition;
    private float _input;
    
    private Vector3 _cameraDirection => transform.InverseTransformDirection(_cameraHolderTransform.forward);

    private void Awake()
    {
        _targetPosition = _cameraHolderTransform.localPosition;
    }

    private void Update()
    {
        HandleInput();
        TryToZoom();
    }

    void TryToZoom()
    {
        Vector3 nextTargetPosition = _targetPosition + _cameraDirection * (_input * _speed);
        
        if (IsInBounds(nextTargetPosition))
            _targetPosition = nextTargetPosition;

        _cameraHolderTransform.localPosition = Vector3.Lerp
        (
            a: _cameraHolderTransform.localPosition, 
            b: _targetPosition, 
            t: Time.deltaTime * _smoothing
        );
    }

    bool IsInBounds(Vector3 position)
    {
        return position.magnitude > _boundsRange.x &&
               position.magnitude < _boundsRange.y;
    }
    
    public void HandleInput()
    {
        _input = Input.GetAxisRaw(InputAxis.MouseScrollWheel);
    }
}
