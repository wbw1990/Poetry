using System.Text.Encodings.Web;
using System.Text.Unicode;
using Poetry;
using Poetry.Main.Application.Queriers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.Configure<MongoDatabaseSettings>(
    builder.Configuration.GetSection("MongoDatabase"));

builder.Services.AddSingleton<GuShiQueryHandler>();

builder.Services.AddMvc().AddJsonOptions(options =>
    {//解决返回实体属性英文小写问题
        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();