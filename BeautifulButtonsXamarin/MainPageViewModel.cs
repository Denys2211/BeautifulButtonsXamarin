using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautifulButtonsXamarin
{
    public class MainPageViewModel : BaseViewModel
    {
        private bool _isStatic;
        private Command _setChoiseStaticTypeCommand;
        private Command _setChoiseDynamicTypeCommand;

        public MainPageViewModel()
        {
        }
        public bool IsStatic
        {
            get => _isStatic;
            set => SetProperty(ref _isStatic, value);
        }

        public ICommand SetChoiseStaticTypeCommand => _setChoiseStaticTypeCommand ??= new Command(OnChoiseStaticType);
        public ICommand SetChoiseDynamicTypeCommand => _setChoiseDynamicTypeCommand ??= new Command(OnChoiseDynamicType);

        public void OnChoiseDynamicType()
        {
            IsStatic = false;
            MessagingCenter.Send(this, "NetworkSettingsEntrysFieldMessages.NEUMORPHICDYNAMIC");

        }

        public void OnChoiseStaticType()
        {
            IsStatic = true;
            MessagingCenter.Send(this, "NetworkSettingsEntrysFieldMessages.NEUMORPHICSTATIC");
        }
    }
}
