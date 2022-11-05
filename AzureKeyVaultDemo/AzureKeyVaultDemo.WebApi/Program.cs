using Azure.Identity;


namespace AzureKeyVaultDemo.WebApi
{
    // Helpful articles:

    // How to Use Azure Key Vault With an Azure Web App in C#:
    // https://blog.loginradius.com/engineering/guest-post/using-azure-key-vault-with-an-azure-web-app-in-c-sharp/

    // Azure Key Vault configuration provider in ASP.NET Core
    // https://learn.microsoft.com/en-us/aspnet/core/security/key-vault-configuration?view=aspnetcore-6.0
    // Repository: https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/key-vault-configuration/samples/6.x/KeyVaultConfigurationSample/Program.cs

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            builder.Configuration.AddAzureKeyVault(
                new Uri(builder.Configuration["AzureKeyVaultUri"]),
                new DefaultAzureCredential());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}