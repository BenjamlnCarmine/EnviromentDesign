# LightFlickerEffect

## Description
The `LightFlickerEffect` script allows for flickering the intensity of a light source in Unity. It provides functionalities to control the flickering effect, adjust intensity range, and manage the smoothing of the flicker.

## Usage
### Setup:
1. Attach the `LightFlickerEffect` script to a GameObject in the Unity scene.
2. If needed, assign an external light to the `light` field. If the script is attached to a GameObject with a Light component, you can leave this field empty.
3. Customize the `minIntensity` and `maxIntensity` values to set the range of random intensity for the light.
4. Adjust the `smoothing` parameter to control the smoothness of the flickering effect. Lower values create sharper flickers, while higher values produce a more gradual change.

### Functions:
- `StartFlicker()`: Starts the flickering effect of the light.
- `StopFlicker()`: Stops the flickering effect of the light.
- `ToggleFlicker()`: Toggles the flickering effect on/off.
- `ResetFlicker()`: Resets the flickering effect by clearing the intensity queue and resetting the calculation.
- `SetIntensityRange(float min, float max)`: Sets the minimum and maximum intensity values for the light flickering effect.
- `SetSmoothing(int smoothingValue)`: Sets the smoothing value for the flickering effect, affecting its sharpness or smoothness.

### Behavior:
- The script starts flickering the light immediately upon the start of the GameObject it's attached to.
- The flickering continues as long as the `isFlickering` flag is set to `true`.
- The light's intensity fluctuates randomly between the set minimum and maximum values, with a smoothing effect based on the specified parameters.

### Example:

LightFlickerEffect flickerEffect;

void Start()
{
    flickerEffect = GetComponent<LightFlickerEffect>();
    flickerEffect.StartFlicker(); // Start the flickering effect
}

void Update()
{
    // Perform actions or control flicker based on game conditions
    if (conditionMet)
    {
        flickerEffect.StopFlicker(); // Stop the flickering effect
    }
}
```

## Notes:
- Ensure the GameObject with the attached script also has a Light component or a Light assigned to the `light` field.
- Adjust the parameters and call the provided functions based on your specific game requirements and conditions.

