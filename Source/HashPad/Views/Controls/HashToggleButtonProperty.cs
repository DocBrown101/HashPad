using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;

using HashPad.ViewModels;

namespace HashPad.Views.Controls;

public class HashToggleButtonProperty
{
	public static IEnumerable GetItems(DependencyObject obj)
	{
		return (IEnumerable)obj.GetValue(ItemsProperty);
	}
	public static void SetItems(DependencyObject obj, IEnumerable value)
	{
		obj.SetValue(ItemsProperty, value);
	}
	public static readonly DependencyProperty ItemsProperty =
		DependencyProperty.RegisterAttached(
			"Items",
			typeof(IEnumerable),
			typeof(HashToggleButtonProperty),
			new PropertyMetadata(null, OnItemsChanged));

	private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is not ToggleButton toggle)
			return;

		toggle.Loaded -= OnLoaded;
		toggle.Unchecked -= OnUnchecked;
		toggle.Loaded += OnLoaded;
		toggle.Unchecked += OnUnchecked;

		static void OnLoaded(object sender, RoutedEventArgs e)
		{
			var toggle = (ToggleButton)sender;
			toggle.IsChecked = GetItems(toggle).OfType<HashViewModel>().Any(x => x.IsTarget);
		}

		static void OnUnchecked(object sender, RoutedEventArgs e)
		{
			var toggle = (ToggleButton)sender;
			if (GetItems(toggle).OfType<HashViewModel>().Any(x => x.IsTarget))
				toggle.IsChecked = true;
		}
	}
}