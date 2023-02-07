using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

//add Localization
builder.Services.AddLocalization();

var localizationOptions = new RequestLocalizationOptions();

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("pt-BR")
};

localizationOptions.SupportedCultures = supportedCultures;
localizationOptions.SupportedUICultures = supportedCultures;
localizationOptions.SetDefaultCulture("pt-BR");
localizationOptions.ApplyCurrentCultureToResponseHeaders = true;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseRequestLocalization(localizationOptions);

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
