using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ClickEffect : MonoBehaviour
{
    private readonly Color[] _colors = new Color[] { Color.red, Color.green, Color.blue };
    private readonly float _positionXRange = 100f;
    private readonly float _startPositionY = 250f;
    private readonly float _flyUpDistance = 500f;
    private readonly float _duration = 2f;

    private TMP_Text _targetText;
    private RectTransform _rectTransform;
    private ClickEffectsPool _pool;

    private void Awake()
    {
        _targetText = GetComponent<TMP_Text>();
        _rectTransform = _targetText.rectTransform;
    }

    public void Initialize(ClickEffectsPool pool)
    {
        _pool = pool;
    }

    public void Play(int value)
    {
        PrepareEffect(value);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_targetText.rectTransform.DOAnchorPosY(_flyUpDistance, _duration))
            .Insert(0f, _targetText.DOFade(0, _duration))
            .OnComplete(() => Push());
    }

    private void PrepareEffect(int value)
    {
        gameObject.SetActive(true);
        _targetText.text = $"+{value}";
        _targetText.color = _colors[Random.Range(0, _colors.Length)];
        _rectTransform.anchoredPosition = new Vector2(Random.Range(-_positionXRange, _positionXRange), _startPositionY);
    }

    private void Push()
    {
        _targetText.color = Color.black;
        _pool.Push(this);
    }
}