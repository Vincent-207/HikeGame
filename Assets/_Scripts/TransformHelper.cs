using UnityEngine;

public class TransformHelper : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 inputVector;
    public void setLocalPos(Vector3 input)
    {
        targetTransform.localPosition = input;
    }
    public void setLocalPos()
    {
        targetTransform.localPosition = inputVector;
    }
}
