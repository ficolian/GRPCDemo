using Grpc.Core;
using GrpcServerStudent;
using GrpcServer.Entity;
using Microsoft.EntityFrameworkCore;

public class StudentServiceImpl : Students.StudentsBase
{
    private readonly SqlDbContext dbContext;
    private readonly ILogger<StudentServiceImpl> _logger;
    public StudentServiceImpl(SqlDbContext dbContext, ILogger<StudentServiceImpl> logger)
    {
        this.dbContext = dbContext;
        _logger = logger;
    }

    public override async Task<StudentResponse> GetStudent(StudentRequest request, ServerCallContext context)
    {
        var response = new StudentResponse();
        var student = await dbContext.Student
                                     .Where(x => x.Id == request.Id)
                                     .FirstOrDefaultAsync();
        response.Name = student.Name;
        response.Address = student.Address;
        return response;
    }

    //public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    //{
    //    using (var connection = new SqlConnection(_connectionString))
    //    {
    //        await connection.OpenAsync();

    //        var command = new SqlCommand("INSERT INTO users (username, email) OUTPUT INSERTED.user_id VALUES (@Username, @Email)", connection);
    //        command.Parameters.AddWithValue("@Username", request.Username);
    //        command.Parameters.AddWithValue("@Email", request.Email);

    //        var userId = (int)await command.ExecuteScalarAsync();

    //        return new CreateUserResponse { UserId = userId };
    //    }
    //}
}
