using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float distance = 10f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private LineRenderer line;
    [SerializeField] private float grappleSpeed = 3f;
    [SerializeField] private GameObject playerHand;

    private DistanceJoint2D joint;
    private Vector3 targetPos;
    private RaycastHit2D hit;

    private void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    private void Update()
    {
        PullPlayer();

        if (Input.GetMouseButtonDown(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(playerHand.transform.position, targetPos - playerHand.transform.position, distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.GetComponent<Rigidbody2D>();

                //Challenge 3:

                joint.distance = Vector2.Distance(playerHand.transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, playerHand.transform.position);
                line.SetPosition(1, hit.point);
            }
        }

        if (Input.GetMouseButton(0))
        {
            line.SetPosition(0, playerHand.transform.position);
        }

        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }

    private void PullPlayer()
    {
        joint.distance -= Time.deltaTime * grappleSpeed;
        joint.distance = Mathf.Max(0.5f, joint.distance);
    }
}