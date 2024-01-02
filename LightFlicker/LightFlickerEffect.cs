using UnityEngine;
using System.Collections.Generic;

public class LightFlickerEffect : MonoBehaviour
{
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new Light light;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;

    Queue<float> smoothQueue;
    float lastSum = 0;

    // Flag to control if the flicker is active or not
    bool isFlickering = true;

    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);

        if (light == null)
        {
            light = GetComponent<Light>();
        }

        // Start flickering immediately
        StartFlicker();
    }

    void Update()
    {
        if (!isFlickering || light == null)
            return;

        // pop off an item if too big
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        // Generate random new item, calculate new average
        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        // Calculate new smoothed average
        light.intensity = lastSum / (float)smoothQueue.Count;
    }

    
    public void StartFlicker()
    {
        isFlickering = true;
    }

    
    public void StopFlicker()
    {
        isFlickering = false;
    }

    
    public void ToggleFlicker()
    {
        isFlickering = !isFlickering;
    }

    
    public void ResetFlicker()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    public void SetIntensityRange(float min, float max)
    {
        minIntensity = min;
        maxIntensity = max;
    }

    
    public void SetSmoothing(int smoothingValue)
    {
        smoothing = smoothingValue;
        smoothQueue = new Queue<float>(smoothing);
        lastSum = 0;
    }
}
