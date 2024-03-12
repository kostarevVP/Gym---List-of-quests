using System;

namespace WKosArch.Common.Utils.Observables
{
	public class ObservableEvent : IObserver<object>
	{
		public event Action Raised;

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(object value)
        {
            throw new NotImplementedException();
        }

        public void Raise()
		{
			Raised?.Invoke();
		}
	}

	public class ObservableEvent<T>
	{
		public event Action<T> Raised;

		public void Raise(T parameter)
		{
			Raised?.Invoke(parameter);
		}
	}
	
	public class ObservableEvent<T, TP>
	{
		public event Action<T, TP> Raised;

		public void Raise(T parameterA, TP parameterB)
		{
			Raised?.Invoke(parameterA, parameterB);
		}
	}
	
	public class ObservableEvent<T, TP, TF>
	{
		public event Action<T, TP, TF> Raised;

		public void Raise(T parameterA, TP parameterB, TF parameterC)
		{
			Raised?.Invoke(parameterA, parameterB, parameterC);
		}
	}
}