using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight; //For mvvmlight 
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;//for class Messenger
using HelloWorldWPFMVVMApp.Messages;


namespace HelloWorldWPFMVVMApp.ViewModel
{
    public class SenderViewModel : ViewModelBase
    {
        private String _textBoxText;
        public int firstEntry { get; set; }
        public int secondEntry { get; set; }

        public string operation { get; set; }
        //public RelayCommand OnClickCommand { get; set; }
        public ICommand Number { get; private set; }
        public ICommand Operation { get; private set; }

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

        public SenderViewModel()
        {
            //OnClickCommand = new RelayCommand(OnClickCommandAction, null);
            Number = new RelayCommand<string>((arg) => EnterNumber(arg));
            Operation = new RelayCommand<string>((arg) => DoOperation(arg));
            // Initialize variables; Set to 0 on start.
            firstEntry = 0;
            secondEntry = 0;
            operation = "";
            // Initialize TextBoxText; Set to 0 on start.
            TextBoxText = "0";
            update();
        }

        private void update()
        {
            var viewModelMessage = new ViewModelMessage()
            {
                Text = TextBoxText
            };
            Messenger.Default.Send(viewModelMessage);
        }
        private void EnterNumber(string @number)
        {
            switch (number)
            {
                case "0":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a zero to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 0;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a zero to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 0;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "1":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a one to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 1;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a one to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 1;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "2":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a two to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 2;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a two to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 2;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "3":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a three to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 3;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a three to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 3;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "4":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a four to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 4;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a four to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 4;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "5":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a five to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 5;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a five to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 5;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "6":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a six to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 6;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a six to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 6;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "7":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a seven to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 7;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a seven to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 7;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "8":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a eight to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 8;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a eight to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 8;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
                case "9":
                    if (operation == "") // AND no operation has been selected,
                    {
                        // 1. "concatenate" a eight to the end of the firstEntry,
                        firstEntry = (firstEntry * 10) + 9;
                        // 2. display firstEntry.
                        TextBoxText = firstEntry.ToString();
                        update();
                    }
                    else
                    {
                        // 1. "concatenate" a nine to the end of the secondEntry,
                        secondEntry = (secondEntry * 10) + 9;
                        // 2. display secondEntry.
                        TextBoxText = secondEntry.ToString();
                        update();
                    }
                    break;
            }
        }

        private void DoOperation(string @operator)
        {
            switch (@operator)
            {
                case "+":
                    // 1. set operation to "+"
                    operation = "+";
                    // 2. reset entrybox to display "0"
                    TextBoxText = "0";
                    update();
                    break;
                case "-":
                    // 1. set operation to "-"
                    operation = "-";
                    // 2. reset entrybox to display "0"
                    TextBoxText = "0";
                    update();
                    break;
                case "*":
                    // 1. set operation to "*"
                    operation = "*";
                    // 2. reset entrybox to display "0"
                    TextBoxText = "0";
                    update();
                    break;
                case "/":
                    // 1. set operation to "/"
                    operation = "/";
                    // 2. reset entrybox to display "0"
                    TextBoxText = "0";
                    update();
                    break;
                case "=":
                    long result = 0;

                    // 1. determine the result
                    if (operation == "*")
                    {
                        result = firstEntry * secondEntry;
                    }
                    else if (operation == "/")
                    {
                        result = firstEntry / secondEntry;
                    }
                    else if (operation == "-")
                    {
                        result = firstEntry - secondEntry;
                    }
                    else if (operation == "+")
                    {
                        result = firstEntry + secondEntry;
                    }

                    // 2. display result
                    TextBoxText = (result).ToString();
                    update();

                    // 3. reset firstEntry, secondEntry, and operation
                    firstEntry = (int)(result);
                    secondEntry = 0;
                    operation = "";
                    break;
                case "C":
                    // 1. reset firstEntry, secondEntry, and operation
                    firstEntry = 0;
                    secondEntry = 0;
                    operation = "";

                    // 2. "clear" the entrybox; display "0"
                    TextBoxText = "0";
                    update();
                    break;
            }
        }
    }
}
