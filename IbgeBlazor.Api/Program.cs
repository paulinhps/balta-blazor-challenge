using IbgeBlazor.Api.ViewModels.City;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/cities", (string? uf) =>
{
    var list = new List<CitiesViewModel>() {
                new CitiesViewModel() {
                    Id = "1",
                    City = "Curitiba",
                    Uf = "PR",
                    State = "Paraná",
                },
                new CitiesViewModel() {
                    Id = "2",
                    City = "São Paulo",
                    Uf = "SP",
                    State = "São Paulo",
                },
                new CitiesViewModel() {
                    Id = "3",
                    City = "Rio de Janeiro",
                    Uf = "RJ",
                    State = "Rio de Janeiro",
                },
                new CitiesViewModel() {
                    Id = "4",
                    City = "Cascavel",
                    Uf = "PR",
                    State = "Paraná",
                },
            };
    if(!string.IsNullOrEmpty(uf))
        return list.Where(x=> x.Uf.ToUpper() == uf.ToUpper()).ToList();
    return list;
});

app.Run();


