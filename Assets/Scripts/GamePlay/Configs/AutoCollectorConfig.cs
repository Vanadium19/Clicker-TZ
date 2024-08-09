using UnityEngine;

[CreateAssetMenu(fileName = "New AutoCollectorConfig", menuName = "Clicks/Create new AutoCollectorConfig", order = 52)]
public class AutoCollectorConfig : ScriptableObject
{
    [SerializeField] private float _delay;
    [SerializeField] private int _reward;

    public float Delay => _delay;
    public int Reward => _reward;
}