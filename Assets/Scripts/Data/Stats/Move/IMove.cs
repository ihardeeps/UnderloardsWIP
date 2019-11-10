public interface IMove
{
    ISpeed Speed { get; }
    void Init();
    void LoadDefault();
}
