using AdviceSlip.ViewModel;

namespace AdviceSlip.View;

public partial class SlipView : ContentPage
{
	SlipViewModel slipViewModel;
	public SlipView()
	{
		InitializeComponent();
		slipViewModel = new SlipViewModel();
		BindingContext = slipViewModel;
	}
}