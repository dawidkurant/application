using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Papu.Authorization;
using Papu.Authorization.DaysOfTheWeek;
using Papu.Authorization.TimesOfDay;
using Papu.Data;
using Papu.Entities;
using Papu.Middleware;
using Papu.Models;
using Papu.Models.Validators;
using Papu.Services;
using Papu.wwwroot;
using System.Text;

namespace Papu
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<StaticFilesConfiguration>
                (Configuration.GetSection("StaticFiles:Headers"));

            var authenticationSettings = new AuthenticationSettings();
            //Pobieranie informacji zapisanych w pliku appsettings.json
            //bind czyli połączenie wartości z pliku ze zmienną authenticationSettings
            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            //Abyśmy mogli wstrzyknąć konfigurację do api
            services.AddSingleton(authenticationSettings);

            //Konfiguracja autentykacji, przekazujemy opcje autentykacji
            //dla tych opcji domyślny schemat autentykacji będzie równy Bearer
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
                //Aby dodać konfigurację JWT, przekazujemy konfigurację
            }).AddJwtBearer(cfg =>
            {
                //Nie wymuszamy od klienta protokołu https
                cfg.RequireHttpsMetadata = false;
                //Dany token powinien zostać zapisany po stronie serwera do celów autentykacji 
                cfg.SaveToken = true;
                //Parametry walidacji po to aby sprawdzić czy dany token wysłany przez klienta
                //jest zgodny z tym co wie serwer
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    //Wydawca danego tokenu 
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    //Jakie podmioty mogą używać tego tokenu
                    ValidAudience = authenticationSettings.JwtIssuer,
                    //Klucz prywatny wygenerowany na podstawie wartości z pliku appsettings.json
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementProductHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementDishHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementMenuHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementBreakfastHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementSecondBreakfastHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementLunchHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementSnackHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementDinnerHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementMondayHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementTuesdayHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementWednesdayHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementThursdayHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementFridayHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementSaturdayHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementSundayHandler>();

            //W ten sposób dodajemy walidację do projektu
            services.AddControllers().AddFluentValidation();

            //Rejestracja serwisu seedującego
            services.AddScoped<PapuSeeder>();
            //AddAutoMapper - jako parametr przekazujemy źródło projektu, którym
            //AutoMapper przeszuka wszystkie typy i znajdzie profile które są potrzebne do
            //utworzenia konfiguracji         
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<ITimesOfDayService, TimesOfDayService>();
            services.AddScoped<IDaysOfTheWeekService, DaysOfTheWeekService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IAccountService, AccountService>();
            //Papu middleware aby kontener dependenciInjection mógł go poprawnie zaizolować
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestTimeMiddleware>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddScoped<IUserContextService, UserContextService>();
            //Przez to że korzystamy z accessora musimy dodać tę rejestrację
            //aby wstrzyknąć referencję do klasy IHttpContextAccessor
            services.AddHttpContextAccessor();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //Rejestrujemy niezbędne serwisy do wygenerowania specyfikacji openapi na podstawie
            //naszego api
            services.AddSwaggerGen();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //Rejestracja kontekstu bazy danych
            services.AddDbContext<PapuDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("PapuDbConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PapuSeeder seeder, 
            IOptions<StaticFilesConfiguration> options)
        {
            env.EnvironmentName = "Development";

            //Każde zapytanie do naszego API przejdzie przez proces seedowania przez co encje zostaną dodane już
            //przy pierwszym zapytaniu do naszego API
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Aby skorzystać z middleware to musi być
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeMiddleware>();

            //W ten sposób mówimy naszemu Api o tym, że każdy request wysłany przez klienta api
            //będzie podlegał autentykacji 
            app.UseAuthentication();
            app.UseHttpsRedirection();
            //Api wygeneruje plik swagger.json zgodny ze specyfikacją openapi i udostępnia
            //na podstawie tego pliku, userinterface czyli stronę która będzie widoczna dla
            //użytkowników bazującą na pliku swagger.json
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //Domyślna ścieżka do pliku wygenerowanego przez swaggera, a drugi parametr to nazwa
                //dokumentacji naszego api
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Papu API");
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    StaticFilesConfiguration headers = options.Value;

                    //Pobieranie konfiguracji pamięci podręcznej z pliku appsettings.json
                    context.Context.Response.Headers["Cache-Control"] =
                    headers.CacheControl;
                    context.Context.Response.Headers["Pragma"] =
                    headers.Pragma;
                    context.Context.Response.Headers["Expires"] =
                    headers.Expires;
                }
            });

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();


            app.UseIdentityServer();

            //Nasze api będzie w stanie autoryzować użytkowników, ale samo to nie wystarczy
            //pod każdą akcją należy dodać atrybut autoryzacji 
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
