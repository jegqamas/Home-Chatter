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
namespace HomeChatter
{
    [Serializable()]
    public class User
    {
        /// <summary>
        /// Class represnts user
        /// </summary>
        public User()
        {
        }
        /// <summary>
        /// Class represnts user
        /// </summary>
        /// <param name="name">The user name</param>
        /// <param name="isAdmin">Is this user an admin ?</param>
        public User(string name, bool isAdmin)
        {
            this.name = name;
            this.isAdmin = isAdmin;
        }

        private string name = "";
        private bool banned = false;
        private bool isAdmin = false;

        /// <summary>
        /// Get or set the user name
        /// </summary>
        public string Name
        { get { return name; } set { name = value; } }
        /// <summary>
        /// Get or set a value indecate whether this user is banned
        /// </summary>
        public bool Banned
        { get { return banned; } set { banned = value; } }
        /// <summary>
        /// Get or set a value indecate whether this user is an admin
        /// </summary>
        public bool Admin
        { get { return isAdmin; } set { isAdmin = value; } }
    }
}
