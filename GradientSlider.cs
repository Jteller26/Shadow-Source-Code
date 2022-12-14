using UnityEngine;
using UnityEngine.UI;
 
public class GradientSlider : MonoBehaviour
{
 
    public Gradient gradient = null;
    public Image image = null;
    public Slider slider = null;
 
    private void Update()
    {
        image.color = gradient.Evaluate(slider.value/slider.maxValue);
    }
}
 