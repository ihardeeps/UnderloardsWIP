public interface IHealth
{
    float Value { get; }
    bool IsDepleted { get; }
    float Percentage { get; }
    IRegen Regen { get; }
    void Init();
    void LoadDefault();
    void Reduce(IDamage damage);
    void Increase(IRegen regeneration);
    void Replenish();
}
