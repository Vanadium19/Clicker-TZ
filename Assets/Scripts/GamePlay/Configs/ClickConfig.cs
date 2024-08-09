using UnityEngine;

[CreateAssetMenu(fileName = "New ClickConfig", menuName = "Clicks/Create new ClickConfig", order = 51)]
public class ClickConfig : ScriptableObject
{
    [SerializeField] private int _reward;
    [SerializeField] private int _multiplyFactor = 1;

    public int Reward => _reward * _multiplyFactor;
}