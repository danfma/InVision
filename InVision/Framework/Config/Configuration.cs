using System;
using System.ComponentModel;

namespace InVision.Framework.Config
{
	public abstract class ConfigurationSection : IConfigurationSection, INotifyPropertyChanged
	{
		#region IConfigurationSection Members

		/// <summary>
		/// 	Gets a value indicating whether this instance has changes.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has changes; otherwise, <c>false</c>.
		/// </value>
		public bool HasChanges { get; private set; }

		/// <summary>
		/// 	Flushes this instance.
		/// </summary>
		public void Flush()
		{
			if (!HasChanges)
				return;


			HasChanges = false;
		}

		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		/// <summary>
		/// 	Invokes the property changed.
		/// </summary>
		/// <param name = "e">The <see cref = "System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
		protected void InvokePropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
				handler(this, e);

			HasChanges = true;
		}

		/// <summary>
		/// 	Invokes the property changed.
		/// </summary>
		/// <param name = "propertyName">Name of the property.</param>
		protected void InvokePropertyChanged(string propertyName)
		{
			InvokePropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
	}
}