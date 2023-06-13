var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//todo // COPIADO E COLADO DA DOCUMENTACAO
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //Aqui no TIME SPAN é o tempo que o login fica ativo sem ninguem esta mexendo nele, se ficar uma hora parado sem usabilidade ele irá deslogar
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//TODO // ATÉ AQUI

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//TODO // COPIADO E COLADO DA DOCUMENTAÇÃO
app.UseSession();
//TODO // ATÉ AQUI

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
