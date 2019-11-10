using UnityEngine;

[System.Serializable]
public class Data<T>
{
    [SerializeField]
    protected T defaultValue;
    protected T currentValue;

    public T Value { get { return currentValue; } }

    public void SetDefault()
    {
        currentValue = defaultValue;
    }
}
