using DemoDAl.Contexts;
using DemoDAL.Models;
using DemoPLL.Interfaces;
using DemoPLL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using DmoPL.Mapping_Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DmoPL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region Configure Service That Allow Dependency Ingection
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<MVCContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			}/*,ServiceLifetime.Singleton*/);
			builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
			builder.Services.AddAutoMapper(M => M.AddProfile(new EployeeProfile()));
			builder.Services.AddAutoMapper(M => M.AddProfile(new DepartmentProfile()));
			
			builder.Services.AddAutoMapper(M => M.AddProfile(new UserProfile()));


			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 6;
			}).AddEntityFrameworkStores<MVCContext>()
				.AddDefaultTokenProviders();
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(op => {
					op.LoginPath = "Account/Login";
					op.AccessDeniedPath = "Home/Error";
				});

			#endregion

			var app = builder.Build();

			#region Configure Http Request Pipline
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
			#endregion

			app.Run();
		}

		
	}
}
