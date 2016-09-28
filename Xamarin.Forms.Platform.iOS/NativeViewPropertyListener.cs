using System;
using System.ComponentModel;
using Foundation;

#if __MOBILE__
namespace Xamarin.Forms.Platform.iOS
#else
namespace Xamarin.Forms.Platform.MacOS
#endif
{
	class NativeViewPropertyListener : NSObject, INotifyPropertyChanged
	{
		string TargetProperty { get; set; }

		public NativeViewPropertyListener(string targetProperty)
		{
			TargetProperty = targetProperty;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
		{
			if (keyPath == TargetProperty)
				PropertyChanged?.Invoke(ofObject, new PropertyChangedEventArgs(TargetProperty));
		}
	}
}
