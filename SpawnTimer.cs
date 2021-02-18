using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpawnTimer : MonoBehaviour
{
    public float initialDelay;
    public float interval;
    public int maxRepetitions;
    public UnityEvent OnTick;
    void OnEnable()
    {
        StartCoroutine(TimerCoroutine());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(initialDelay);
      for (int i = 0; i < maxRepetitions; i++)
        {
            OnTick?.Invoke();
            yield return new WaitForSeconds(interval);
        }
    }
}
