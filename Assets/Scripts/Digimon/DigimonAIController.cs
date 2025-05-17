using UnityEngine;

public class DigimonAIController : MonoBehaviour
{
    private DigimonStats _stats;
    private ActionExecutor _executor;

    private Urge _primaryUrge;
    private Urge _content = new Urge("Content", 0f);
    private float _timer;

    public float minDecisionWait = 1f;
    public float maxDecisionWait = 5f;

    private void Start()
    {
        _stats = GetComponent<DigimonStats>();
        _executor = GetComponent<ActionExecutor>();
        _stats.InitializeUrges(gameObject);
        InvokeRepeating(nameof(UpdatePrimaryUrge), 0, 0.5f);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > minDecisionWait && _timer < maxDecisionWait)
        {
            if (!_executor.TryExecuteNext())
            {
                TryActOnUrge();
            }

            _timer = 0;
        }

        if (_timer >= maxDecisionWait)
            _timer = 0;
    }

    private void TryActOnUrge()
    {
        var decision = _primaryUrge.GetActionWithContext();
        if (decision is { } d)
        {
            var (action, context) = d;
            _executor.Enqueue(action, context);
            Debug.Log("tryactonurge");
        }
    }

    private void UpdatePrimaryUrge()
    {
        _primaryUrge = _content;
        foreach (var urge in _stats.GetUrges())
        {
            urge.Tick();
            if (urge < 50 && (_primaryUrge == _content || _primaryUrge > urge))
            {
                _primaryUrge = urge;
            }
        }
    }
}