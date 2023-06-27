using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteController : MonoBehaviour
{
    public Volume volume;
    public GameObject player;
    public float maxDistance = 40f; // Maximum distance to the enemy for the effect to start.
    public float minIntensity = 0f; // Vignette minimum intensity.
    public float maxIntensity = 0.4f; // Vignette maximum intensity.

    private Vignette vignette;

    void Start()
    {
        if (volume.profile.TryGet<Vignette>(out var v))
        {
            vignette = v;
        }
    }
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        float normalizedDistance = Mathf.Clamp01(distance / maxDistance);
        float intensity = Mathf.Lerp(maxIntensity, minIntensity, normalizedDistance);

        float intensityChangeRate = (maxIntensity - minIntensity) / maxDistance;
        float intensityDelta = intensityChangeRate * Time.deltaTime;

        intensity = Mathf.MoveTowards(intensity, maxIntensity, intensityDelta);

        Debug.Log($"Distance: {distance}, Normalized Distance: {normalizedDistance}, Intensity: {intensity}");

        vignette.intensity.Override(intensity);

        //Debug.Log($"Calculated Intensity: {intensity}");
    }
}