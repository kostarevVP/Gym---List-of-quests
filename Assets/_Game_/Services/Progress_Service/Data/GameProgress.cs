using System;
using UnityEngine;

[Serializable]
public class GameProgress
{
    public int SceneIndex;
    public int CarPassCount;

    public event Action<int, Transform> OnCarPassCountEvent;
    internal void CarPass(int scoreForCar, Transform transform)
    {
        CarPassCount += scoreForCar;
        OnCarPassCountEvent?.Invoke(scoreForCar, transform);
    }
}
