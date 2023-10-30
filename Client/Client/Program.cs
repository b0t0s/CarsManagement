using CarsManagement.Client.Application;
using CarsManagement.Client.Application.Builders;
using CarsManagement.Client.BuildersImplementation;
using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace CarsManagement.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddScoped<CustomAuthenticationStateProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider>(s =>
            s.GetRequiredService<CustomAuthenticationStateProvider>());

        builder.Services.AddScoped<IParkingManagerBuilder<ManagerDTO, ParkingLotDTO>, ParkingManagerBuilder>();
        builder.Services.AddScoped<IParkingLotBuilder<ParkingLotDTO, ParkingSpotDTO>, ParkingLotBuilder>();
        builder.Services.AddScoped<IParkingSpotBuilder<ParkingSpotDTO, CarDTO, TicketDTO>, ParkingSpotBuilder>();
        builder.Services.AddScoped<ICarBuilder<CarDTO, TicketDTO>, CarBuilder>();

        builder.Services.AddAuthorizationCore();

        await builder.Build().RunAsync();
    }
}