using UnityEngine;

public class DigimonAIController : MonoBehaviour
{
    private DigimonStats _stats;
    private ActionExecutor _executor;

    private Urge _primaryUrge;
    private Urge _content = new Urge("Content", 0f);
    private float _timer;

    private float minDecisionWait = 1f;
    private float maxDecisionWait = 5f;

    private void Start()
    {
        _stats = GetComponent<DigimonStats>();
        _executor = GetComponent<ActionExecutor>();
        _stats.InitializeUrges(gameObject);
        //randomize decision times
        minDecisionWait = Random.Range(1f, 5f);
        maxDecisionWait = Random.Range(5f, 10f);
        
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
        {
            _timer = 0;
        }
    }

    private void TryActOnUrge()
    {
        var decision = _primaryUrge.GetActionWithContext();
        if (decision != null)
        {
            var (action, context) = decision.Value;
            if (_executor.PeekNext() != (action, context))
            {
                Debug.Log(
                    $"Enqueuing action: {action.GetType().Name} for urge: {_primaryUrge.Name}, action count in queue: {_executor.GetQueueCount()}");
                _executor.Enqueue(action, context);
            }
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