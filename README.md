# ChatCLI

A simple chat application built using C# for **real-time communication** over a network. This application allows multiple clients to connect to a single server and exchange messages.

## Features
- **Real-time messaging**: Users can send and receive messages instantly.
- **Multi-client support**: Multiple clients can connect to the same server at once.
- **Cross-platform**: Works on macOS, Windows, and Linux using .NET Core.

## Requirements
- .NET 6.0 or later
- Visual Studio Code or Visual Studio
- Access to the same network (for local testing)

## Setup Instructions

### 1. Clone the repository

git clone https://github.com/amaaxn/ChatCLI.git  
cd ChatCLI

### 2. Install .NET (if not already installed)  
Follow the official guide to install .NET on your system:  
[Download .NET](https://dotnet.microsoft.com/download/dotnet)

### 3. Build the Project

You can build and run the server and client using the .NET CLI.

#### For the Server:
1. Navigate to the `ChatServer` folder:  
cd ChatServer  
2. Run the server:  
dotnet run  
The server will now be listening for incoming client connections.

#### For the Client:
1. Navigate to the `ChatClient` folder:  
cd ChatClient  
2. Run the client:  
dotnet run

### 4. Configuration

To allow connections from other devices on the same network:
- Update the server's IP address in `ChatServer.cs` to `IPAddress.Any` for local network connectivity.
- Update the client's IP in `ChatClient.cs` to the IP address of the machine running the server.

### 5. Firewall Configuration  
Ensure that the firewall is configured to allow traffic on port `5000`.

### 6. Testing  
To test, run the server on one machine, and then run multiple clients (on different devices) to send and receive messages in real-time.

## How It Works

- The server listens for incoming connections from clients.
- Each client can send messages to the server, which then broadcasts the message to all connected clients.
- The server can handle multiple clients simultaneously.

## Project Structure
/ChatServer  
    - Server code for handling client connections and broadcasting messages.  

/ChatClient  
    - Client application code to connect to the server and send/receive messages.

## Technologies Used
- **C#**
- **.NET Core**
- **TCP Sockets**

## Contributing

Feel free to fork the repository, make changes, and create a pull request. If you have any suggestions or issues, feel free to open an issue on the GitHub repository.

## License

This project is licensed under the MIT License.
