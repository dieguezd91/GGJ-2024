using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider _leftCollider;
    [SerializeField] private BoxCollider _topCollider;
    [SerializeField] private BoxCollider _rightCollider;
    [SerializeField] private BoxCollider _bottomCollider;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        if (!_camera.orthographic)
        {
            Debug.LogError("Make sure your camera is set to orthographic");
            return;
        }

        SetCameraEdges();
    }

    private void SetCameraEdges()
    {
        float halfHeight = _camera.orthographicSize;
        float halfWidth = _camera.orthographicSize * _camera.aspect;

        _leftCollider.center = new Vector3(-halfWidth - _leftCollider.size.x * 0.5f, 0f, 10f);
        _leftCollider.size = new Vector3(_leftCollider.size.x, halfHeight * 2f, 20f);

        _topCollider.center = new Vector3(0f, halfHeight + _topCollider.size.y * 0.5f, 10f);
        _topCollider.size = new Vector3(halfWidth * 2f + _topCollider.size.y * 2f, _topCollider.size.y, 20f);

        _rightCollider.center = new Vector3(_leftCollider.center.x * -1f, _leftCollider.center.y, _leftCollider.center.z);
        _rightCollider.size = _leftCollider.size;

        _bottomCollider.center = new Vector3(_topCollider.center.x, _topCollider.center.y * -1f, _topCollider.center.z);
        _bottomCollider.size = _topCollider.size;
    }
}