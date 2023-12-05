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
using Papu.Data;
using Papu.Entities;
using Papu.Middleware;
using Papu.Models;
using Papu.Models.Validators;
using Papu.Services;
using Papu.wwwroot;
using System;
using System.Linq;
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

        /// <summary>
        /// Ta metoda jest wywoływana przez środowisko wykonawcze. Użyj tej metody do dodawania usług do kontenera.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<StaticFilesConfiguration>
                (Configuration.GetSection("StaticFiles:Headers"));

            ConfigurateAuthentication(services);
            ConfigureAuthorization(services);
            ConfigureFluentValidation(services);

            services.AddCors();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            services.AddDatabaseDeveloperPageExceptionFilter();

            /// <summary>
            /// Rejestrujemy niezbędne serwisy do wygenerowania specyfikacji openapi na podstawie
            /// naszego api
            /// </summary>
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            /// <summary>
            /// Przez to że korzystamy z accessora musimy dodać tę rejestrację
            /// aby wstrzyknąć referencję do klasy IHttpContextAccessor
            /// </summary>
            services.AddHttpContextAccessor();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen();

            /// <summary>
            /// Rejestracja serwisu seedującego
            /// </summary>
            services.AddScoped<PapuSeeder>();

            /// <summary>
            /// AddAutoMapper - jako parametr przekazujemy źródło projektu, którym
            /// AutoMapper przeszuka wszystkie typy i znajdzie profile które są potrzebne do
            /// utworzenia konfiguracji
            /// </summary>
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IKindOfService, KindOfService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IDayMenuService, DayMenuService>();
            services.AddScoped<IAccountService, AccountService>();

            /// <summary>
            /// Papu middleware aby kontener dependenciInjection mógł go poprawnie zaizolować
            /// </summary>
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestTimeMiddleware>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IUserContextService, UserContextService>();

            /// <summary>
            /// Rejestracja kontekstu bazy danych
            /// </summary>
            services.AddDbContext<PapuDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PapuDbConnection")));

            /// <summary>
            /// W środowisku produkcyjnym pliki Angulara będą dostarczane z tego katalogu
            /// </summary>
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddRazorPages();
        }

        /// <summary>
        /// Ta metoda jest wywoływana przez środowisko wykonawcze. Użyj tej metody do skonfigurowania potoku żądania HTTP
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PapuSeeder seeder, 
            IOptions<StaticFilesConfiguration> options)
        {
            env.EnvironmentName = "Development";

            /// <summary>
            /// Każde zapytanie do naszego API przejdzie przez proces seedowania przez co encje zostaną dodane już
            /// przy pierwszym zapytaniu do naszego API
            /// </summary>
            seeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                /// <summary>
                /// Domyślna wartość HSTS wynosi 30 dni. Możesz chcieć to zmienić w scenariuszach produkcyjnych, zobacz https://aka.ms/aspnetcore-hsts
                /// </summary>
                app.UseHsts();
            }

            /// <summary>
            /// To jest potrzebne aby korzystać z middleware
            /// </summary>
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeMiddleware>();

            /// <summary>
            /// W ten sposób mówimy naszemu Api o tym, że każdy request wysłany przez klienta api
            /// będzie podlegał autentykacji 
            /// </summary>
            app.UseAuthentication();
            app.UseHttpsRedirection();

            /// <summary>
            /// Api wygeneruje plik swagger.json zgodny ze specyfikacją openapi i udostępnia
            /// na podstawie tego pliku, userinterface czyli stronę która będzie widoczna dla
            /// użytkowników bazującą na pliku swagger.json
            /// </summary>
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                /// <summary>
                /// Domyślna ścieżka do pliku wygenerowanego przez swaggera, a drugi parametr to nazwa
                /// dokumentacji naszego api
                /// </summary>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Papu API");
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    StaticFilesConfiguration headers = options.Value;

                    /// <summary>
                    /// Pobieranie konfiguracji pamięci podręcznej z pliku appsettings.json
                    /// </summary>
                    context.Context.Response.Headers["Cache-Control"] = headers.CacheControl;
                    context.Context.Response.Headers["Pragma"] = headers.Pragma;
                    context.Context.Response.Headers["Expires"] = headers.Expires;
                }
            });

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseIdentityServer();

            /// <summary>
            /// Nasze api będzie w stanie autoryzować użytkowników, ale samo to nie wystarczy
            /// pod każdą akcją należy dodać atrybut autoryzacji 
            /// </summary>
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
                /// <summary>
                /// Aby dowiedzieć się więcej na temat opcji obsługi aplikacji Angular SPA w środowisku ASP.NET Core,
                /// zobacz https://go.microsoft.com/fwlink/?linkid=864501
                /// </summary>
                spa.Options.SourcePath = "ClientApp";
                spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void ConfigurateAuthentication(IServiceCollection services)
        {
            var authenticationSettings = new AuthenticationSettings();

            /// <summary>
            /// Pobieranie informacji zapisanych w pliku appsettings.json
            /// bind czyli połączenie wartości z pliku ze zmienną authenticationSettings
            /// </summary>
            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            /// <summary>
            /// Abyśmy mogli wstrzyknąć konfigurację do api
            /// </summary>
            services.AddSingleton(authenticationSettings);

            /// <summary>
            /// Konfiguracja autentykacji, przekazujemy opcje autentykacji
            /// dla tych opcji domyślny schemat autentykacji będzie równy Bearer
            /// </summary>
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";

                /// <summary>
                /// Aby dodać konfigurację JWT, przekazujemy konfigurację
                /// </summary>
            }).AddJwtBearer(cfg =>
            {
                /// <summary>
                /// Nie wymuszamy od klienta protokołu https
                /// </summary>
                cfg.RequireHttpsMetadata = false;

                /// <summary>
                /// Dany token powinien zostać zapisany po stronie serwera do celów autentykacji 
                /// </summary>
                cfg.SaveToken = true;

                /// <summary>
                /// Parametry walidacji po to aby sprawdzić czy dany token wysłany przez klienta
                /// jest zgodny z tym co wie serwer
                /// </summary>
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    /// <summary>
                    /// Wydawca danego tokenu
                    /// </summary>
                    ValidIssuer = authenticationSettings.JwtIssuer,

                    /// <summary>
                    /// Jakie podmioty mogą używać tego tokenu
                    /// </summary>
                    ValidAudience = authenticationSettings.JwtIssuer,

                    /// <summary>
                    /// Klucz prywatny wygenerowany na podstawie wartości z pliku appsettings.json
                    /// </summary>
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });
        }

        private static void ConfigureAuthorization(IServiceCollection services)
        {
            var authorizationHandlers = typeof(Startup).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IAuthorizationHandler)))
                .Where(t => t.IsClass && !t.IsAbstract)
                .ToList();

            foreach (var handler in authorizationHandlers)
            {
                services.AddScoped(typeof(IAuthorizationHandler), handler);
            }
        }

        private static void ConfigureFluentValidation(IServiceCollection services)
        {
            /// <summary>
            /// W ten sposób dodajemy walidację do projektu
            /// </summary>
            services.AddControllers().AddFluentValidation();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
        }
    }
}
