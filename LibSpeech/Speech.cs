using CodeIn60Seconds_List_Ext;
using System;
using System.ComponentModel.Composition;
using System.Speech.Synthesis;

namespace LibSpeech
{
    //6
    [Export(typeof(IPlugin))]
    public class Speech : DelegateHandler, ISpeech
    {
        private readonly SpeechSynthesizer _synthesizer;
        private void Say(string text)
        {
            if (text == null) return;
            lock (_synthesizer)
            {
                _synthesizer.SpeakAsync(text);
            }
        }

        public Speech()
        {
            _synthesizer = new SpeechSynthesizer();
            _synthesizer.Rate = -1;
            _synthesizer.Volume = 100;
            Delegate = new Action<string>(Say);
        }
    }
}