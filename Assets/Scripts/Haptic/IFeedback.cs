namespace Haptics
{
    public interface IFeedback
    {
        void Init();
        void Trigger(Feedback.Type type);
    }

}