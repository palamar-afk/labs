using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat
{
    public class ChatManager
    {
        private List<User> _activeUsers = new List<User>();
        public event Action<int> OnUserNumberChanged;
        public delegate void OnLogAction(string message);
        public event OnLogAction OnLog;

        public int GetCountUsers
        {
            get
            {
                return _activeUsers.Count;
            }
        }
        
        public void AddUser(User user)
        {
            if (_activeUsers.Contains(user))
            {
                return;
            }

            foreach (User usr in _activeUsers)
            {
                user.OnSent += usr.Receive;
                usr.OnSent += user.Receive;
            }
            
            _activeUsers.Add(user);
        }

        public void RemoveUser(User user)
        {
            if (!_activeUsers.Contains(user))
                return;

            foreach (User usr in _activeUsers)
            {
                user.OnSent -= usr.Receive;
                usr.OnSent -= user.Receive;
            }

            _activeUsers.Remove(user);
        }


        public void OnOnLog(string message)
        {
            OnLog?.Invoke(message);
        }


        public void OnOnUserNumberChanged(int count)
        {
            OnUserNumberChanged?.Invoke(count);
        }
    }
}
