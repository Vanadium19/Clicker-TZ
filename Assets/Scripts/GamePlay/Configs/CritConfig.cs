using UnityEngine;

[CreateAssetMenu(fileName = "New CritConfig", menuName = "Clicks/Create new CritConfig", order = 53)]
public class CritConfig : ScriptableObject
{
    [SerializeField] private int _divider = 1;
    [SerializeField] private float _delay = 0.1f;

    public int Divider => _divider;
    public float Delay => _delay;

    private void OnValidate()
    {
        if (_delay <= 0)
            _delay = 0.1f;

        if (_divider < 1)
            _divider = 1;
    }
}