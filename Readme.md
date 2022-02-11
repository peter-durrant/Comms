# gRPC C# Communications

The solution demonstrates some concepts for using the gRPC RPC framework and Google Protocol Buffers for data interchange.

The solution consists of the following projects:
1. [Comms](./Comms/) - a WPF client application
2. [ConsoleComms](./ConsoleComms/) - a console server application
3. [ServerComms](./ServerComms/) - the server gRPC library
4. [ClientComms](./ClientComms/) - the client gRPC library (references the server proto files)

The solution is built in Visual Studio 2019 targetting .NET 4.6.1 x86, which mirrors the real-world constraints of some systems I develop on.

## NuGet Packages

The two libraries [ServerComms](./ServerComms/) and [ClientComms](./ClientComms/) require the gRPC and Protobuf NuGet packages:
1. [gRPC](https://www.nuget.org/packages/Grpc/)
2. [gRPC.Tools](https://www.nuget.org/packages/Grpc.Tools/)
3. [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf)

The gRPC.Tools package enables Visual Studio to build the `.proto` files that define the messaging between client and server. Set the properties of the `.proto` files to
have a "Build Action" of "Protobuf".

The [ServerComms.csproj](./ServerComms/ServerComms.csproj) project file includes the protobuf service definition. This is set to compile the `"Server"` gRPC services.

```xml
<Protobuf Include="Protos\server.proto" GrpcServices="Server" />
```

Similarly, the [ClientComms.csproj](./ClientComms/ClientComms.csproj) project file includes a link to the protobuf service definition. This is set to compile the `"Client"`
gRPC services, which will avoid regenerating the service part of the definition in the client library.

```xml
<Protobuf Include="..\ServerComms\Protos\server.proto" GrpcServices="Client">
    <Link>Protos\server.proto</Link>
</Protobuf>
```

## Service

The service schema is defined using protobuf. The service is called **CommsService** defined in [server.proto](./ServerComms/Protos/server.proto).

```
service CommsService {
```

