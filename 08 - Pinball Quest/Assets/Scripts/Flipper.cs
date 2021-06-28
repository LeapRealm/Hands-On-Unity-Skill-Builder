using UnityEngine;

public enum Location
{
    None,
    Left,
    Right
}

public class Flipper : MonoBehaviour
{
    [SerializeField] private Location myLocation;
    private HingeJoint2D joint;

    private void Start()
    {
        if (myLocation == Location.None)
            Debug.LogError("Location Enum is None");
        
        joint = GetComponent<HingeJoint2D>();
    }
    
    private void Update()
    {
        switch (myLocation)
        {
            case Location.Left:
                if (Input.GetKey(KeyCode.Z))
                    joint.useMotor = true;
                else
                    joint.useMotor = false;
                break;
            case Location.Right:
                if (Input.GetKey(KeyCode.X))
                    joint.useMotor = true;
                else
                    joint.useMotor = false;
                break;
        }
    }
}