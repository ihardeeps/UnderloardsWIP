using UnityEngine;
namespace Haptics
{
    public class AndroidFeedback : Feedback
    {
        public override void Init()
        {
            //Initialize the plugin or call AndroidJNI related functions
        }
        public override void Trigger(Type type)
        {
            Debug.Log(string.Format("Android Feedback Triggered {0}", type));
            // Cast or use the Plugin feedback types and set it based on Interface usage
            //And trigger the plugin for feedback for call the extern function

        }
    }
}
