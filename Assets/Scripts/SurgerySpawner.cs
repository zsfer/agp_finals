using UnityEngine;
using DG.Tweening;

public class SurgerySpawner : MonoBehaviour
{
    public static SurgerySpawner Instance { get; private set; }

    [SerializeField] GameObject[] _surgeryPrefabs;

    GameObject _currentSpawned;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (_currentSpawned != null)
            _currentSpawned.transform.DOMoveX(30, 2).SetEase(Ease.Linear);

        var s = Instantiate(SelectRandomSpawn(), Vector3.left * 30, Quaternion.identity);
        s.transform.DOMoveX(0, 2).SetEase(Ease.Linear);
        _currentSpawned = s;
    }

    private GameObject SelectRandomSpawn()
    {
        return _surgeryPrefabs[Random.Range(0, _surgeryPrefabs.Length)];
    }
}
