using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider HealthBar;
    private int _amount;
    private int Max = 100;

    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            HealthBar.normalizedValue = Mathf.Clamp01(_amount / (float) Max);
        }
    }

    void Start()
    {
        Amount = Max;
    }
}