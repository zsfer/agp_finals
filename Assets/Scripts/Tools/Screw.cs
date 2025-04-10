using UnityEngine;
using UnityEngine.Events;

public class Screw : MonoBehaviour
{
    [SerializeField] UnityEvent OnComplete;

    [field: SerializeField]
    public float ScrewProgress { get; private set; }

    Rigidbody _rb;
    float _startY;
    void Awake()
    {
        _startY = transform.localPosition.y;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (ScrewProgress >= 100 && _rb.isKinematic)
        {
            _rb.isKinematic = false;
            OnComplete.Invoke();
        }

        if (!_rb.isKinematic) return;
        var newY = Mathf.Lerp(_startY, _startY + 0.3f, ScrewProgress / 100);
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }

    public void Screwing()
    {
        if (ScrewProgress < 100 && _rb.isKinematic)
            ScrewProgress += 80 * Time.deltaTime;
    }
}
