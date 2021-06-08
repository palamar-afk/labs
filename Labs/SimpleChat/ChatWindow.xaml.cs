using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SimpleChat
{
    public partial class ChatWindow : Window
    {
        private readonly ChatManager _chatManager;
        private readonly User _user;
        
        public ChatWindow(ChatManager chatManager, User user)
        {
            InitializeComponent();
            _chatManager = chatManager;
            _user = user;
            _user.OnReceived += MessageReceived;
            
            _chatManager.OnUserNumberChanged += UserNumberChanged;
            Title = _user.Username;
        }

        // YOU DON'T NEED TO EDIT THE CODE BELOW, UNLESS YOU WANT TO CHANGE
        // THE VISUAL APPEARANCE OF YOUR APPLICATION - YOU ARE FREE TO DO THIS
        private void UserNumberChanged(int number)
        {
            textBlockUsersNum.Text = number + " active users";
        }

        private void VisualizeNewMessage(string message, string initiator)
        {
            // Other user's message
            if (initiator != null)
            {
                listBoxMessages.Items.Add(new ListBoxItem
                {
                    Content = new TextBlock
                    {
                        TextWrapping = TextWrapping.Wrap,
                        Text = initiator + " says:",
                        TextAlignment = TextAlignment.Right
                    },
                    Background = new SolidColorBrush(Colors.Bisque),
                    HorizontalContentAlignment = HorizontalAlignment.Stretch
                });
            }

            listBoxMessages.Items.Add(new ListBoxItem
            {
                Content = new TextBlock
                {
                    TextWrapping = TextWrapping.Wrap,
                    Text = message,
                    TextAlignment = initiator != null ? TextAlignment.Right : TextAlignment.Left
                },
                HorizontalContentAlignment = HorizontalAlignment.Stretch
            });

            listBoxMessages.SelectedIndex = listBoxMessages.Items.Count - 1;
            listBoxMessages.ScrollIntoView(listBoxMessages.SelectedItem);
        }

        private void MessageReceived(Message message)
        {
            VisualizeNewMessage(message.Data, message.Initiator.Username);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxMessage.Text))
            { 
                _user.Send(textBoxMessage.Text);
                
                VisualizeNewMessage(textBoxMessage.Text, null);
                textBoxMessage.Clear();
            }
            
        }

        private void buttonJoin_Click(object sender, RoutedEventArgs e)
        {
            _chatManager.OnOnLog($"{_user.Username} joined to chat");
            _chatManager.OnOnUserNumberChanged(_chatManager.GetCountUsers+1);
            _chatManager.AddUser(_user);
            buttonJoin.IsEnabled = false;
            buttonLeave.IsEnabled = true;
        }

        private void buttonLeave_Click(object sender, RoutedEventArgs e)
        {
            _chatManager.OnOnLog($"{_user.Username} left chat");
            _chatManager.OnOnUserNumberChanged(_chatManager.GetCountUsers-1);
            _chatManager.RemoveUser(_user);
            buttonJoin.IsEnabled = true;
            buttonLeave.IsEnabled = false;
        }
    }
}
