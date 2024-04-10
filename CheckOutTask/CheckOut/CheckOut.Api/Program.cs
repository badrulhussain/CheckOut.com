using CheckOut.Persistence;
using CheckOut.Persistence.IRepo;
using CheckOut.Service;
using CheckOut.Service.IService;
using DummyDataBase;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMerchantService, MerchantService>();
builder.Services.AddScoped<IPaymentProcessService, PaymentProcessService>();
builder.Services.AddScoped<IWalletService, WalletService>(); 
builder.Services.AddScoped<IWalletRepo, WalletRepo>();
builder.Services.AddScoped<IPaymentExecutor, PaymentExecutor>();
builder.Services.AddScoped<ILedgerRepo, LedgerRepo>(); 

// DummyDb
builder.Services.AddSingleton<IMockDb, MockDb>();

// HttpClient
builder.Services.AddHttpClient<IPaymentExecutor, PaymentExecutor>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
