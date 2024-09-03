using Grpc.Net.Client;
using GrpcServer; // Ensure this matches the namespace from your proto file

var channel = GrpcChannel.ForAddress("https://localhost:7298");
//var client = new Greeting.GreetingClient(channel);

//var reply = await client.SayHelloAsync(new HelloRequest { Name = "World" });
//Console.WriteLine("Greeting: " + reply.Message);
//Console.ReadLine();

var studentClient = new Students.StudentsClient(channel);

var studentResponse = await studentClient.GetStudentAsync(new StudentRequest { Id = 1 });
Console.WriteLine("Data received: " +  studentResponse.Name + " Address: " + studentResponse.Address);
Console.ReadLine();