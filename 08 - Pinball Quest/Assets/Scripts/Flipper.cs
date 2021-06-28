using UnityEngine;

public class Flipper : MonoBehaviour
{
    private HingeJoint2D joint;

    private void Start()
    {
        joint = GetComponent<HingeJoint2D>();
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            joint.useMotor = true;
        else
            joint.useMotor = false;
    }
}