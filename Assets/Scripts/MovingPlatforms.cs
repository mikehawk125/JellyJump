using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public AnimationCurve timeCurve;
    public float speed = 2.0f;

    void Update()
    {
        float t = timeCurve.Evaluate(Mathf.PingPong(Time.time * speed, 1.0f));
        platform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
    }
}