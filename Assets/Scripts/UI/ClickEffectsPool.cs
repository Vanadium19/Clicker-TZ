using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ClickEffectsPool : MonoBehaviour
    {
        [SerializeField] private ClickEffect _clickEffectPrefab;
        [SerializeField] private Transform _canvas;

        private Queue<ClickEffect> _spawnQueue = new Queue<ClickEffect>();

        public void Push(ClickEffect textAnimation)
        {
            textAnimation.gameObject.SetActive(false);
            _spawnQueue.Enqueue(textAnimation);
        }

        public ClickEffect Pull()
        {
            if (_spawnQueue.Count == 0)
                return Create();

            return _spawnQueue.Dequeue();
        }

        private ClickEffect Create()
        {
            var textAnimation = Instantiate(_clickEffectPrefab, _canvas);
            textAnimation.Initialize(this);
            return textAnimation;
        }
    }
}