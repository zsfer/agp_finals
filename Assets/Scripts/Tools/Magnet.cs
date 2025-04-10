using UnityEngine;

public class Magnet : ToolBase
{
    [SerializeField] float _magnetForce = 200;
    [SerializeField] float _magnetRadius = 1;
    [SerializeField] float _magnetDist = 2;
    [SerializeField] LayerMask _magnetMask;

    protected override void UseTool()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position + Vector3.down, _magnetRadius, Vector3.down, _magnetDist, _magnetMask);

        foreach (var hit in hits)
        {
            var rb = hit.collider.attachedRigidbody;
            if (rb == null) return;

            // dir (me, whatever im magneting)
            var dir = (transform.position - rb.position).normalized;
            rb.AddForce(dir * _magnetForce);
        }
    }
}
