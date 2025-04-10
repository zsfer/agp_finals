using UnityEngine;

public enum ToolType
{
    Magnet = 0,
    Screwdriver = 1,
    Saw = 2
}

public class Tools : MonoBehaviour
{
    [SerializeField] float _toolMoveSpeed = 1;
    [SerializeField] GameObject[] _tools;

    Rigidbody _currentTool;
    Vector3 _lastToolPos;

    void Start()
    {
        _lastToolPos = transform.position;
        SelectTool(ToolType.Magnet);
    }

    void Update()
    {
        InputSwapTool();
        MoveTool();
    }

    void InputSwapTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectTool(ToolType.Magnet);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectTool(ToolType.Screwdriver);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectTool(ToolType.Saw);
    }

    void MoveTool()
    {
        var fwd = Camera.main.transform.forward;
        fwd.y = 0;
        var right = Camera.main.transform.right;
        right.y = 0;

        var mov = (right * Input.GetAxisRaw("Horizontal") + fwd * Input.GetAxisRaw("Vertical")).normalized; // movementVector = { right, 0, fwd }
        mov.y = Input.GetKey(KeyCode.J) ? -1 : Input.GetKey(KeyCode.K) ? 1 : 0;

        _currentTool.linearVelocity = mov * _toolMoveSpeed * Time.deltaTime;
    }

    public void SelectTool(ToolType tool)
    {
        for (int i = 0; i < _tools.Length; i++)
        {
            if (i == (int)tool)
            {
                if (_currentTool != null) _lastToolPos = _currentTool.position;
                _currentTool = _tools[i].GetComponent<Rigidbody>();
                _currentTool.position = _lastToolPos;
                _tools[i].SetActive(true);

                if (_currentTool.GetComponentsInChildren<Rigidbody>() is Rigidbody[] childRbs)
                {
                    foreach (var childRb in childRbs)
                    {
                        if (childRb.isKinematic) continue;
                        childRb.angularVelocity = Vector3.zero;
                        childRb.linearVelocity = Vector3.zero;
                    }
                }
                continue;
            }
            _tools[i].SetActive(false);
        }
    }
}
