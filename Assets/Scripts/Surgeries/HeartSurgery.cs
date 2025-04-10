using UnityEngine;

public class HeartSurgery : SurgeryBase
{
    [SerializeField] Rigidbody _panel;
    [SerializeField] Rigidbody _heart;
    [SerializeField] Rigidbody _newHeart;
    int _screwCount = 0;

    public override void OnComplete()
    {
        _isComplete = true;
        _newHeart.isKinematic = true;
        SurgerySpawner.Instance.Spawn();
    }

    public void Unscrew()
    {
        _screwCount++;

        if (_screwCount == 4)
        {
            _panel.isKinematic = false;
            _panel.mass = 10;
            _panel.AddForce(Vector3.up * 1000, ForceMode.Impulse);
            _heart.isKinematic = false;
            _heart.mass = 50;

            _newHeart.isKinematic = false;
            _newHeart.mass = 100;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name.Contains("battery-new") && _screwCount >= 4 && !_isComplete)
            OnComplete();
    }
}
