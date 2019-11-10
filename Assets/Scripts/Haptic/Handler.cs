using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Haptics
{
    public class Handler : IHandler
    {
        private static IHandler instance;
        public static IHandler Instance { get { if (instance == null) instance = new Handler(); return instance; } }

        public IFeedback CurrentFeedback { get { return feedback; } }

        private IFeedback feedback;
        private Handler()
        {
#if UNITY_ANDROID
            feedback = new AndroidFeedback(); 
#endif
#if UNITY_IOS
            feedback = new iOSFeedback();
#endif
        }

        public void Trigger(Feedback.Type type)
        {
            feedback.Trigger(type);
        }

        public void Init()
        {
            feedback.Init();
        }
    }
}
