var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PP_Template_Api>("PP-Template-Api");

builder.Build().Run();
