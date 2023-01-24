using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MVVMToolkitMAUISample
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string firstName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        private string lastName;

        public string FullName => $"{FirstName} {LastName}";

        [RelayCommand(CanExecute = nameof(CheckName))]
        public async Task Save(string saveName)
        {
            await Application.Current.MainPage.DisplayAlert("Info", "Pressed Save for " + saveName, "OK");
        }

        private bool CheckName(string saveName)
        {
            if (saveName != null)
            {
                return saveName == "Peter Jackson";
            }

            return false;
        }

        /// <summary>
        /// ctor
        /// </summary>
        public MainViewModel()
        {
            this.firstName = "Peter";
            this.lastName = "Jackson";
        }
    }
}

