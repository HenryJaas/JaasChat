using JaasChat.Core;
using JaasChat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaasChat.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<FriendModel> Friends { get; set; }

        /* Commands */

        public RelayCommand SendCommand { get; set; }

        private FriendModel _selectedFriend;

        public FriendModel SelectedFriend
        {
            get { return _selectedFriend; }
            set 
            { 
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { _message = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Friends = new ObservableCollection<FriendModel>();

            SendCommand = new RelayCommand(o=>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Henry",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/9RXoZjp.png",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Henry",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/9RXoZjp.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Matias",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/9RXoZjp.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Matias",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/9RXoZjp.png",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });

            for (int i = 0; i < 5; i++)
            {
                Friends.Add(new FriendModel
                {
                    Username = $"Henry {i}",
                    ImageSource = "https://i.imgur.com/9RXoZjp.png",
                    Messages = Messages
                });

            }
        }
    }
}
