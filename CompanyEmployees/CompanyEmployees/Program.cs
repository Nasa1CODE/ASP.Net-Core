using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.AddControllers();

builder.Host.UseSerilog((hostContext, configuration) =>
{
    configuration.ReadFrom.Configuration(hostContext.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();//sẽ thêm phần mềm trung gian để sử dụng HSTS, phần mềm này sẽ thêm tiêu đề Strict-Transport-Security

app.UseHttpsRedirection();//được sử dụng để thêm phần mềm trung gian cho việc chuyển hướng từ HTTP sang HTTPS
app.UseStaticFiles();//cho phép sử dụng các tệp tĩnh cho yêu cầu
app.UseForwardedHeaders(new ForwardedHeadersOptions // sẽ chuyển tiếp các tiêu đề proxy đến yêu cầu hiện tại
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

