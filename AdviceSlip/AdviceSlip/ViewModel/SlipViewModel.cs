using AdviceSlip.Model;
using AdviceSlip.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdviceSlip.ViewModel
{
    public partial class SlipViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<SlipModel> slip;

        public ICommand getSlip { get; }

        public SlipViewModel()
        {
           Slip = new ObservableCollection<SlipModel>();
            getSlip = new Command(getSlipAdvice);

        }
        public async void getSlipAdvice()
        {
            SlipServices slipService = new SlipServices();
            Slip = await slipService.getSlip();
            Debug.WriteLine(slip[0]);
        }

    }
}
