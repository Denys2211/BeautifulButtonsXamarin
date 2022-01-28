using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Sharpnado.CollectionView.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace BeautifulButtonsXamarin
{
    public partial class MainPage : ContentPage
    {
        private PancakeView _firstAnimationHolder = new PancakeView();
        private PancakeView _secondAnimationHolder = new PancakeView();
        private Color _colorOne = Color.FromHex("ffffff");
        private Color _colorTwo = Color.FromHex("d8d8db");

        public MainPage()
        {
            InitializeComponent();
            MessagingCenterSubscribe();
        }

        private async Task AnimationStatic()
        {
            await Task.WhenAll(
                   _firstAnimationHolder.ColorTo(_colorOne, _colorTwo, c => GradientOneDynamic.Color = c, 600),
                   _secondAnimationHolder.ColorTo(_colorTwo, _colorOne, c => GradientTwoDynamic.Color = c, 600),
                   _firstAnimationHolder.ColorTo(_colorTwo, _colorOne, c => GradientOneStatic.Color = c, 600),
                   _secondAnimationHolder.ColorTo(_colorOne, _colorTwo, c => GradientTwoStatic.Color = c, 600));
        }

        private async Task AnimationDynamic()
        {
            await Task.WhenAll(
                   _firstAnimationHolder.ColorTo(_colorOne, _colorTwo, c => GradientOneStatic.Color = c, 600),
                   _secondAnimationHolder.ColorTo(_colorTwo, _colorOne, c => GradientTwoStatic.Color = c, 600),
                   _firstAnimationHolder.ColorTo(_colorTwo, _colorOne, c => GradientOneDynamic.Color = c, 600),
                   _secondAnimationHolder.ColorTo(_colorOne, _colorTwo, c => GradientTwoDynamic.Color = c, 600));
        }

        private void MessagingCenterSubscribe()
        {
            MessagingCenter.Subscribe<MainPageViewModel>(this, "NetworkSettingsEntrysFieldMessages.NEUMORPHICSTATIC", async (s) => await AnimationStatic());
            MessagingCenter.Subscribe<MainPageViewModel>(this, "NetworkSettingsEntrysFieldMessages.NEUMORPHICDYNAMIC", async (s) => await AnimationDynamic());
        }
    }
}
