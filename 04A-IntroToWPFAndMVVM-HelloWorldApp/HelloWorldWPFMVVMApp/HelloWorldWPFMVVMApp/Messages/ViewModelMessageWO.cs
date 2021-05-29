using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace HelloWorldWPFMVVMApp.Messages
{
    class ViewModelMessageWO : MessageBase
    {
        public string Text { get; set; }
    }
}