using System;

namespace ExampleSinglePageApp.Messages
{
    public class ChangePageMessage
    {
        public Type ViewModelType { get; }

        public ChangePageMessage(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
