namespace BlazorWebAppDemo.Demo.StateService
{
    public class StateService
    {

        private List<string> _messages = new List<string>();
        //event to notify the UI that the state has changed when we add something to the _messages
        public event Action OnChange;
        public IEnumerable<string> GetMessages() => _messages;

        public void AddMessage(string message)
        {
            _messages.Add(message);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
