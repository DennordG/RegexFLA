using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RegexFLA.ViewModels
{
	public class AbstractViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion

		protected void ChangeAndNotify<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(backingField, value))
			{
				backingField = value;
				OnPropertyChanged(propertyName);
			}
		}
	}
}
