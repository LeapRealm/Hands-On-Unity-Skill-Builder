using System;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private LineRenderer line;
    [SerializeField] private float grappleSpeed = 1.5f;
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

            hit = Physics2D.Raycast(playerHand.transform.position, 
                targetPos - playerHand.transform.position, distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                if (hit.collider.GetComponent<MovingPlatformController>())
                    grappleSpeed = 3f;
                else
                    grappleSpeed = 1.5f;

                joint.enabled = true;
                joint.connectedBody = hit.collider.GetComponent<Rigidbody2D>();
                
                // float colliderMinX = hit.collider.bounds.min.x;
                // float colliderMaxX = hit.collider.bounds.max.x;
                // float colliderMinY = hit.collider.bounds.min.y;
                // float colliderMaxY = hit.collider.bounds.max.y;
                //
                // SpriteRenderer hitSpriteRenderer = hit.collider.GetComponent<SpriteRenderer>();
                // float spriteMinX = hitSpriteRenderer.size.x / 2.0f * -1.0f;
                // float spriteMaxX = hitSpriteRenderer.size.x / 2.0f;
                // float spriteMinY = hitSpriteRenderer.size.y / 2.0f * -1.0f;
                // float spriteMaxY = hitSpriteRenderer.size.y / 2.0f;
                //
                // float anchorX = MapRangeClamped(hit.point.x, colliderMinX, colliderMaxX, spriteMinX, spriteMaxX);
                // float anchorY = MapRangeClamped(hit.point.y, colliderMinY, colliderMaxY, spriteMinY, spriteMaxY);
                // joint.connectedAnchor = new Vector2(anchorX, anchorY);
                
                joint.connectedAnchor = hit.transform.InverseTransformPoint(hit.point);

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
        joint.distance = Mathf.Max(0.3f, joint.distance);

        if (Math.Abs(joint.distance - 0.3f) < 0.01f)
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }
    
    public float MapRangeClamped (float value, float fromA, float toB, float fromC, float toD)
    {
        value = Mathf.Clamp(value, fromA, toB);
        return (value - fromA) / (toB - fromA) * (toD - fromC) + fromC;
    }
}