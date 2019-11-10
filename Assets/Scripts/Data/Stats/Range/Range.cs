using UnityEngine;
[System.Serializable]
public class Range : IRange, IClone<Range>
{
    [SerializeField]
    protected float min;
    [SerializeField]
    protected float max;
    public float Min { get { return min; } }

    public float Max { get { return max; } }

    public void Init()
    {
        
    }

    public float GetInBetween()
    {
        return Random.Range(min, max);
    }

    public virtual bool InRange(float value)
    {
        return (value >= min && value <= max);
    }

    public Range Clone()
    {
        Range range = new Range();
        range.min = Min;
        range.max = Max;
        range.Init();
        return range;
    }
}
