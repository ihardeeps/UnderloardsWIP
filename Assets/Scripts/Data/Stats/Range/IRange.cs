public interface IRange
{
    float Min { get; }
    float Max { get; }
    void Init();

    float GetInBetween();
    bool InRange(float value);
}
