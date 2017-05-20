using UnityEngine;

public class JumpLocation : MonoBehaviour
{
    public LandingLocation landingLocation;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Agent"))
            return;
        Agent2D agent = other.GetComponent<Agent2D>();
        Jump jump = other.GetComponent<Jump>();
        if (agent == null || jump == null)
            return;

        Vector2 originsPos = transform.position;
        Vector2 targetPos = landingLocation.transform.position;
        jump.Isolate(true);
        jump.jumpPoint = new JumpPoint(originsPos, targetPos);
        jump.DoJump();
    }
}
