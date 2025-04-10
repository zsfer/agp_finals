using UnityEngine;

public class Screwdriver : ToolBase
{
    [SerializeField] Transform _screwTop;
    Screw _screw;
    protected override void UseTool()
    {
        if (!_screw) return;

        _screwTop.Rotate(Vector3.up * 5 * Time.deltaTime);
        _screw.Screwing();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name.Contains("screw"))
        {
            _screw = col.gameObject.GetComponent<Screw>();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name.Contains("screw"))
            _screw = null;
    }

}
