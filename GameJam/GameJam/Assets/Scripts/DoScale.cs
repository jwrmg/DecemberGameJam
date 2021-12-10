/*
 *  Author: James Greensill
 */

using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Scales objects over a period of time and optionally has a callback.
/// </summary>
public class DoScale : DoAction
{
    [SerializeField] public Vector3 EndScale;
    [SerializeField] public float Speed;

    [SerializeField] public Vector3 OriginalScale;

    [SerializeField] public UnityEvent OnStartTweenComplete;

    public override void Restore() => Run(OriginalScale, Speed, null, OnTweenComplete);

    public override void Run() => Run(EndScale, Speed, null, OnStartTweenComplete);

    public void Hide() => Run(new Vector3(0, 0, 0), Speed, null, OnTweenComplete);

    public void Run(Vector3 newScale, float speed, UnityAction action = null, UnityEvent unityEvent = null)
    {
        transform.DOScale(newScale, speed).OnComplete(() =>
        {
            unityEvent?.Invoke();
            action?.Invoke();
        });
    }

    private void Awake()
    {
        OriginalScale = transform.localScale;
    }
}