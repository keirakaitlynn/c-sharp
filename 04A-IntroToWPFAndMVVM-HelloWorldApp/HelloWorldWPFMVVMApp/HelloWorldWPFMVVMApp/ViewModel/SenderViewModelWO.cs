using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight; //For mvvmlight 
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;//for class Messenger
using HelloWorldWPFMVVMApp.Messages;


namespace HelloWorldWPFMVVMApp.ViewModel
{
    public class SenderViewModelWO : ViewModelBase
    {
        private String _textBoxText;
        public RelayCommand OnClickCommand { get; set; }

        public string TextBoxText
        {
            get
            { return _textBoxText; }

            set
            {
                _textBoxText = value;
                RaisePropertyChanged("TextBoxText");
            }
        }

        public SenderViewModelWO()
        {
            OnClickCommand = new RelayCommand(OnClickCommandAction, null);
        }

        private void OnClickCommandAction()
        {
            var viewModelMessage = new ViewModelMessageWO()
            {
                Text = TextBoxText
            };
            Messenger.Default.Send(viewModelMessage);
        }

    }
}
