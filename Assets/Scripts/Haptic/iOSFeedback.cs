using UnityEngine;
namespace Haptics
{
    public class iOSFeedback : Feedback
    {
        public override void Init()
        {
            //Initialize the plugin or call int iOS related extern functions
            //iOSHapticFeedback.Instance.Init();
        }

        public override void Trigger(Type type)
        {
            Debug.Log(string.Format("iOS Feedback Triggered {0}", type));

            // Cast or use the Plugin feedback types and set it based on Interface usage

            //iOSHapticFeedback.iOSFeedbackType feedbackType = iOSHapticFeedback.iOSFeedbackType.None;
            switch (type)
            {
                case Type.Failure:
                    //feedbackType = iOSHapticFeedback.iOSFeedbackType.Failure;
                    break;
                case Type.ImpactHeavy:
                    //feedbackType = iOSHapticFeedback.iOSFeedbackType.ImpactHeavy;
                    break;
                case Type.ImpactLight:
                    //feedbackType = iOSHapticFeedback.iOSFeedbackType.ImpactLight;
                    break;
                case Type.ImpactMedium:
                    //feedbackType = iOSHapticFeedback.iOSFeedbackType.ImpactMedium;
                    break;
                case Type.SelectionChange:
                    //feedbackType = iOSHapticFeedback.iOSFeedbackType.SelectionChange;
                    break;
                case Type.Success:
                    //feedbackType = iOSHapticFeedback.iOSFeedbackType.Success;
                    break;
                case Type.Warning:
                    //feedbackType = iOSHapticFeedback.iOSFeedbackType.Warning;
                    break;
            }

            //Trigger the plugin for feedback for call the extern function

            // iOSHapticFeedback.Instance.Trigger(feedbackType);
        }

    }
}
