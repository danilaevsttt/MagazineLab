using Magazine.Core.Services;
using Magazine.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. ВАЖНО: Подключаем ваш сервис, чтобы контроллер мог им пользоваться
builder.Services.AddScoped<IProductService, ProductService>();

// 2. Базовые настройки WebAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 3. Настройка Swagger (без лишних настроек, чтобы не было ошибок)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Включаем Swagger только в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();