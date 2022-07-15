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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace HomeChatter
{
    public class ChatServer
    {
        private static TcpChannel channel;
        private static string objectName = "";
        private static ServerStatus status = ServerStatus.Off;
        private static int portNumber;

        /// <summary>
        /// Register a channel (create server)
        /// </summary>
        /// <param name="name">The server object name</param>
        /// <param name="theObject">The server object to set in the host</param>
        /// <param name="port">The port number</param>
        public static void CreateServer(string name, RemotingObject theObject, int port)
        {
            try
            {
                objectName = name;
                portNumber = port;
                Console.WriteLine("Creating Tcp channel at port " + port);
                channel = new TcpChannel(port);

                Console.WriteLine("Registering the channel ...");
                ChannelServices.RegisterChannel(channel, false);
                Console.WriteLine("Channel registered !");

                Console.WriteLine("Registering the remoting object at the channel ...");
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingObject), name, WellKnownObjectMode.Singleton);
                Console.WriteLine("Remoting object registered !");

                status = ServerStatus.Running;
                Console.WriteLine("Server is running");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't create server !");
                Console.WriteLine(ex.Message);
                status = ServerStatus.Off;
            }
        }
        /// <summary>
        /// Kill registerd server
        /// </summary>
        public static void KillServer()
        {
            if (channel != null)
            {
                try
                {
                    Console.WriteLine("Killing server ....");
                    ChannelServices.UnregisterChannel(channel);
                    Console.WriteLine("Done.");
                }
                catch { }
                channel = null;
            }
            else
            {
                Console.WriteLine("There is no server to kill !");
            }
            status = ServerStatus.Off;
        }

        /// <summary>
        /// Get the remoting object at address (join server)
        /// </summary>
        /// <param name="address">The complete server address</param>
        /// <returns></returns>
        public static RemotingObject GetServerObject(string address)
        {
            if (channel == null)
            {
                Console.WriteLine("Registering tcp channel as client...");
                // Create the channel.
                channel = new TcpChannel();

                // Register the channel.
                ChannelServices.RegisterChannel(channel, false);
                Console.WriteLine("Channel registered.");
            }
            try
            {
                Console.WriteLine("Returning the remoting object at address " + address);
                return (RemotingObject)Activator.GetObject(typeof(RemotingObject), address);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when trying to get the remoting object at given address");
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Get current running server address
        /// </summary>
        /// <returns>The complete server address</returns>
        public static string GetServerAddress()
        {
            if (channel != null)
            {
                string[] urls = channel.GetUrlsForUri(objectName);
                if (urls.Length > 0)
                {
                    return urls[0];
                }
            }
            return "";
        }
        /// <summary>
        /// Get the server ip address. The server must be running first.
        /// </summary>
        /// <returns></returns>
        public static string GetServerIPAddress()
        {
            if (status == ServerStatus.Off)
            {
                throw new Exception("Server is off !");
            }
            // get the complete address first !
            string address = GetServerAddress().Replace("tcp://", "").Replace("/" + objectName, "");
            // remove port nubmer
            string[] code = address.Split(new char[] { ':' });

            return code[0];// this should be the ip.
        }

        /// <summary>
        /// Build address that client can use to join a server
        /// </summary>
        /// <param name="ip">The server ip address</param>
        /// <param name="port">The port number</param>
        /// <returns>The server address</returns>
        public static string BuildAddress(string ip, int port)
        {
            return "tcp://" + ip + ":" + port + "/" + objectName;
        }

        /// <summary>
        /// Get the server (or the registered channel). If the server is not created yet, this returns null.
        /// </summary>
        public static TcpChannel Channel
        { get { return channel; } }
        /// <summary>
        /// Get current status of running server
        /// </summary>
        public static ServerStatus Status
        { get { return status; } }
        /// <summary>
        /// Get or set the current remoting object name
        /// </summary>
        public static string ObjectName
        { get { return objectName; } set { objectName = value; } }
        /// <summary>
        /// Get the server port number if this server is running.
        /// </summary>
        public static int PortNumber
        { get { return portNumber; } }
    } 
    /// <summary>
    /// The server status
    /// </summary>
    public enum ServerStatus
    {
        /// <summary>
        /// The server is running
        /// </summary>
        Running,
        /// <summary>
        /// The server is off
        /// </summary>
        Off
    }
}
