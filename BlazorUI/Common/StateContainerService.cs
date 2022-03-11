using System;

namespace BlazorUI.Common
{
    public class StateContainerService
    {

        public int Value { get; set; } = 0;
        public event Action OnStateChange;

        public void SetValue(int value)
        {
            Value = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

    }
}