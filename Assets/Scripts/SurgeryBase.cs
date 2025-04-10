using UnityEngine;

public abstract class SurgeryBase : MonoBehaviour
{
    protected bool _isComplete;
    public abstract void OnComplete();
}
