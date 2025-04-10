using UnityEngine;

public class ResetPositionOnWorldEnd : MonoBehaviour
{
    Vector3 _startPos;
    Rigidbody _rb;
    void Start()
    {
        _startPos = transform.localPosition;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -30)
        {
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            transform.localPosition = _startPos;
        }
    }
}
