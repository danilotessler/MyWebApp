using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class IndexModel : PageModel
{

    public string Message { get; private set; } = "";

    private readonly IConfiguration Configuration;

    public IndexModel(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void OnGet()
    {
        Message = "";
    }

    public async Task<IActionResult> OnPostAsync()
    {
        int accountNumber = Convert.ToInt32(Request.Form["accountNuber"]);

        Balance balance = await GetProductAsync(accountNumber);

        Message = $"As of { DateTime.Now } the account { balance.Account } balance is: CAN$ {balance.Available:c2}.";

        return Page();
    }

    private async Task<Balance> GetProductAsync(int accountNumber)
    {
        Balance ret = new Balance();

        HttpClient client = new HttpClient();

        client.BaseAddress = new Uri(Configuration["APIUrl"]);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        
        string path = $"balance/{ accountNumber }";

        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            ret = await response.Content.ReadFromJsonAsync<Balance>();
        }
        
        return ret;
    }

}

public class Balance
{
    public int Account { get; set; }
    public double Available { get; set; }
}