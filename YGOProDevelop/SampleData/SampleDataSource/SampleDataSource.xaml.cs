//   *********  请勿修改此文件   *********
//   此文件由设计工具再生成。更改
//   此文件可能会导致错误。
namespace Expression.Blend.SampleData.SampleDataSource
{
	using System; 
	using System.ComponentModel;

// 若要在生产应用程序中显著减小示例数据涉及面，则可以设置
// DISABLE_SAMPLE_DATA 条件编译常量并在运行时禁用示例数据。
#if DISABLE_SAMPLE_DATA
	internal class SampleDataSource { }
#else

	public class SampleDataSource : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public SampleDataSource()
		{
			try
			{
				Uri resourceUri = new Uri("/YGOProDevelop;component/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
				System.Windows.Application.LoadComponent(this, resourceUri);
			}
			catch
			{
			}
		}

		private ItemCollection _Collection = new ItemCollection();

		public ItemCollection Collection
		{
			get
			{
				return this._Collection;
			}
		}
	}

	public class Item : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private string _Name = string.Empty;

		public string Name
		{
			get
			{
				return this._Name;
			}

			set
			{
				if (this._Name != value)
				{
					this._Name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}

		private string _Attribute = string.Empty;

		public string Attribute
		{
			get
			{
				return this._Attribute;
			}

			set
			{
				if (this._Attribute != value)
				{
					this._Attribute = value;
					this.OnPropertyChanged("Attribute");
				}
			}
		}

		private double _Level = 0;

		public double Level
		{
			get
			{
				return this._Level;
			}

			set
			{
				if (this._Level != value)
				{
					this._Level = value;
					this.OnPropertyChanged("Level");
				}
			}
		}

		private double _Atk = 0;

		public double Atk
		{
			get
			{
				return this._Atk;
			}

			set
			{
				if (this._Atk != value)
				{
					this._Atk = value;
					this.OnPropertyChanged("Atk");
				}
			}
		}

		private double _Def = 0;

		public double Def
		{
			get
			{
				return this._Def;
			}

			set
			{
				if (this._Def != value)
				{
					this._Def = value;
					this.OnPropertyChanged("Def");
				}
			}
		}
	}

	public class ItemCollection : System.Collections.ObjectModel.ObservableCollection<Item>
	{ 
	}
#endif
}
