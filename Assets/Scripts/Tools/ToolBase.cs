using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public abstract class ToolBase : MonoBehaviour
{
    [SerializeField] LayerMask _meMask;

    LineRenderer _line;
    void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    /// <summary>
    /// This runs every frame when you hold Space
    /// </summary>
    protected abstract void UseTool();

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            UseTool();

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 100, _meMask))
        {
            _line.enabled = true;

            _line.SetPositions(new Vector3[] {
                    transform.position,
                    hit.point
            });
        }
        else
        {
            _line.enabled = false;
        }
    }
}
