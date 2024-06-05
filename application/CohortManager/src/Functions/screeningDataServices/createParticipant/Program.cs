using System.Data;
using System.Data.Common;
using Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data.Database;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
        var databaseCOnnectionString = Environment.GetEnvironmentVariable("DtOsDatabaseConnectionString");
        services.AddTransient<IDbConnection>(provider =>
        {
            var providerFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var conn = providerFactory.CreateConnection();
            conn.ConnectionString = databaseCOnnectionString;
            return conn;
        });
        services.AddSingleton<ICreateParticipantData, CreateParticipantData>();
        services.AddSingleton<ICreateResponse, CreateResponse>();
        services.AddSingleton<IDatabaseHelper, DatabaseHelper>();
        services.AddSingleton<ICheckDemographic, CheckDemographic>();
    })
    .Build();

host.Run();
