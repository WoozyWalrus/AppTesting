using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace UITesting;

[TestClass]
public class LoginTest : PageTest
{
    [TestMethod]
    public async Task SuccessfulTitle()
    {
        // Navigate to the login page
        await Page.GotoAsync("http://uitestingplayground.com/sampleapp");

        // Enter a username
        await Page.GetByPlaceholder("User Name").FillAsync("randomuser");
        
        // Enter a password
        await Page.GetByPlaceholder("********").FillAsync("pwd");

        // Click the login button
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log In" }).ClickAsync();

        // Verify successful login message
        var loginStatus = Page.Locator("#loginstatus");
        await Expect(loginStatus).ToContainTextAsync(new Regex("Welcome, randomuser!"));
    }
}
