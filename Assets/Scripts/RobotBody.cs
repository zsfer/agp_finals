using UnityEngine;

public class RobotBody : MonoBehaviour
{
    [SerializeField] HingeJoint _headJoint;
    [SerializeField] HingeJoint _armLJoint, _armRJoint;
    [SerializeField] HingeJoint _legsJoint;

    public void AttachHead(GameObject head)
    {
        head.transform.position = _headJoint.anchor;
    }

    public void AttachArms(GameObject arm)
    {

    }

    public void AttachLegs(GameObject leg)
    {

    }
}
