using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ClickConfig", menuName = "Clicks/Create new ClickConfig", order = 51)]
public class ClickConfig : ScriptableObject
{
    [SerializeField] private int _reward = 1;
    [SerializeField] private int _variableFactor = 1;
    [SerializeField] private List<ClicksValueVariable> _variables;

    private void OnValidate()
    {
        if (_reward <= 0)
            _reward = 1;
    }

    public int GetReward()
    {
        int variablesSum = _variableFactor;

        foreach (var variable in _variables)
            variablesSum += (int)variable;

        return _reward + variablesSum;
    }
}