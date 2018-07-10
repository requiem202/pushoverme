namespace PushoverMe
{
    public class PushoverMessage
    {
        public string Text { get; private set; }

        internal PushoverMessage(string text)
        {
            Text = text;
        }
    }
}