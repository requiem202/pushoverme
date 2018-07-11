using System.Collections.Generic;

namespace PushoverMe
{
    public class PushoverMessage
    {
        public string Text { get; private set; }
        public string Sound { get; private set; }

        internal PushoverMessage(string text, string sound = null)
        {
            Text = text;
            Sound = sound;
        }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            yield return new KeyValuePair<string, string>("message", Text);
            if (!string.IsNullOrEmpty(Sound))
            {
                yield return new KeyValuePair<string, string>("sound", Sound);
            }
        }
    }
}