/* This file is part of Home Chatter
 * A program that allows to chat using basic LAN connection.
 *
 * Copyright © Ala Ibrahim Hadid 2013
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeChatter
{
    public class RemotingObject : MarshalByRefObject
    {
        private List<User> users = new List<User>();
        private List<string> banList = new List<string>();
        private bool isPasswordProtected = false;
        private string password = "";
        private string serverName = "";
        private bool isServerRunning = false;
        private int maxUsersNumber = 4;

        /// <summary>
        /// Join this server object as a normal user
        /// </summary>
        /// <param name="userName">The user name</param>
        public void Join(string userName)
        { Join(userName, "", false); }
        /// <summary>
        /// Join this server object as a normal user
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The server password</param>
        public void Join(string userName, string password)
        { Join(userName, password, false); }
        /// <summary>
        /// Join this server object
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The server password</param>
        /// <param name="isAdmin">Is this user an admin ?</param>
        public void Join(string userName, string password, bool isAdmin)
        {
            if (userName == "")
                throw new Exception("User name is empty !");
            if (maxUsersNumber > 0)
            {
                if (users.Count == maxUsersNumber)
                    throw new Exception("The number of users reached the maximum number.");
            }

            if (!isPasswordProtected)
            {
                // just ignore password and add the user ...
                if (!IsUserExist(userName))
                {
                    if (!IsUserBanned(userName))
                    {
                        User newUser = new User();
                        newUser.Name = userName;
                        newUser.Admin = isAdmin;
                        users.Add(newUser);
                        OnUserJoined(userName);
                    }
                    else
                    {
                        throw new Exception("This user is banned !!");
                    }
                }
                else
                {
                    throw new Exception("This user already exist !!");
                }
            }
            else// we need to do password check first !!
            {
                if (!CheckPassword(password))
                {
                    throw new Exception("Username is not exist, password is not correct or both !");
                }
                else
                {
                    // password match !
                    if (!IsUserExist(userName))
                    {
                        if (!IsUserBanned(userName))
                        {
                            User newUser = new User();
                            newUser.Name = userName;
                            newUser.Admin = isAdmin;
                            users.Add(newUser);
                            OnUserJoined(userName);
                        }
                        else
                        {
                            throw new Exception("This user is banned !!");
                        }
                    }
                    else
                    {
                        throw new Exception("This user already exist !!");
                    }
                }
            }
        }
        /// <summary>
        /// Get a user index
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetPlayerIndex(string userName)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name.ToLower() == userName.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// Request a log out for a user
        /// </summary>
        /// <param name="userName">The user name</param>
        public void LogOut(string userName)
        {
            foreach (User usr in users)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    // log out via removing this user from the list
                    users.Remove(usr);
                    OnUserLeave(userName);
                    break;
                }
            }
        }
        /// <summary>
        /// Check to see if a user exist
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <returns>True if the user name already exist otherwise false</returns>
        public bool IsUserExist(string userName)
        {
            foreach (User usr in users)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Set a user as banned
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="banned">User is banned or not.</param>
        public void SetUserBanned(string userName, bool banned)
        {
            foreach (User usr in users)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    usr.Banned = banned;
                    if (banned)
                        banList.Add(userName);
                    else
                        banList.Remove(userName);
                    break;
                }
            }
        }
        /// <summary>
        /// Get if an user is banned or not
        /// </summary>
        /// <param name="userName">The user name. Must be exist</param>
        /// <returns>True if the user exist and banned otherwise false</returns>
        public bool IsUserBanned(string userName)
        {
            foreach (User usr in users)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    if (usr.Banned)
                        return true;
                }
            }
            foreach (string user in banList)
            {
                if (user.ToLower() == userName.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        //TODO: make a real secured password check
        private bool CheckPassword(string password)
        { return this.password == password; }

        /// <summary>
        /// Raise the UserJoined event
        /// </summary>
        /// <param name="userName">The user name</param>
        protected void OnUserJoined(string userName)
        {
            SendMessage(userName + " has joined the room.");
        }
        /// <summary>
        /// Raise the UserLeave event
        /// </summary>
        /// <param name="userName">The user name</param>
        protected void OnUserLeave(string userName)
        {
            SendMessage(userName + " has left the room.");
        }

        /// <summary>
        /// Get the users collection
        /// </summary>
        public List<User> Users
        { get { return users; } }
        /// <summary>
        /// Get or set if this server is password protected
        /// </summary>
        public bool IsPasswordProtected
        { get { return isPasswordProtected; } set { isPasswordProtected = value; } }
        /// <summary>
        /// Get or set the password
        /// </summary>
        public string Password
        { get { return password; } set { password = value; } }
        /// <summary>
        /// Get or set the server name
        /// </summary>
        public string ServerName
        { get { return serverName; } set { serverName = value; } }
        /// <summary>
        /// Get or set the maximum users number. 0 Means the server has no limit.
        /// </summary>
        public int MaxUsersNumber
        {
            get { return maxUsersNumber; }
            set
            {
                maxUsersNumber = value;
            }
        }
        /// <summary>
        /// Get or set if the server is alive
        /// </summary>
        public bool IsServerRunning
        { get { return isServerRunning; } set { isServerRunning = value; } }

        /*Messaging members (chat)*/
        public List<string> messages = new List<string>();
        public int messagesLimit = 10000;
        public int messageIndex = 0;

        public void SendMessage(string message)
        {
            message = "[" + DateTime.Now.ToUniversalTime() + "] " + message;
            messages.Add(message);
            // limit messages to messagesLimit
            if (messages.Count > messagesLimit)
            { messages.RemoveAt(0); }
            messageIndex++;
        }
    }
}
