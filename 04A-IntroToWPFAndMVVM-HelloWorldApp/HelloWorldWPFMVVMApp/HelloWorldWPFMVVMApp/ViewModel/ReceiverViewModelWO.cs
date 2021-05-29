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
    public class ReceiverViewModelWO : ViewModelBase
    {
        private string _contentText;

        public string ContentText
        {
            get { return _contentText; }
            set
            {
                _contentText = value;
                RaisePropertyChanged("ContentText");
            }
        }

        public ReceiverViewModelWO()
        {
            Messenger.Default.Register<ViewModelMessageWO>(this, OnReceiveMessageAction);
        }

        private void OnReceiveMessageAction(ViewModelMessageWO obj)
        {
            ContentText = obj.Text;
        }
    }
}
