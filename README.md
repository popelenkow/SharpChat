# SharpChat


### About:

This application is an analog of popular instant messengers.
Can create chats and communicate with authorized users.
The entire solution is based on the .NET Framework 4.7.

## ClinentChat

### Technology and design patterns:

Wpf, Caliburn.Micro, MVVM, ViewModel-First, ResponseHandler.

### About:

Caliburn.Micro - syntactic sugar for binding ViewModel - View within Wpf.
PolymorphismSharp is used to process responses from the server.

## ServerChat

### Technology and design patterns:

EntityFramework , RequestHandler.

### About:

PolymorphismSharp is used to process requests.

## NetworkLibrary

### Technology and design patterns:

Tcp, BinarySerialization.

### About:

This library is a wrapper over TcpClient and TcpListener.
Messages are sent as PacketRequest and PacketResponse.

## PolymorphismSharp

### Technology and design patterns:

Reflection, CLOS.

### About:

A self-written library that implements the dispatching of CLOS.
In this project it is used to replace switch case.