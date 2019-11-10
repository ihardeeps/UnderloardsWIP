namespace Haptics
{
    public interface IHandler
    {
        IFeedback CurrentFeedback { get; }
        void Init();
        void Trigger(Feedback.Type type);
    }
}
