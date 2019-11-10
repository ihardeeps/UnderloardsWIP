namespace Haptics
{
    public class Feedback : IFeedback
    {
        public enum Type
        {
            SelectionChange,
            ImpactLight,
            ImpactMedium,
            ImpactHeavy,
            Success,
            Warning,
            Failure,
            None
        }
        public virtual void Trigger(Type type)
        {
        }

        public virtual void Init()
        {

        }
    }
}
