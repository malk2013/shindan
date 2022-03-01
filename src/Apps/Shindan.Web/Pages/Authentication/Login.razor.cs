using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Shindan.Web.Core.Authentication;
using System.Security.Claims;

namespace Shindan.Web.Pages.Authentication
{
    public partial class Login
    {
        private TokenRequest _tokenModel = new();
        private FluentValidationValidator? _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        private bool _passwordVisibility;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;


        protected override async Task OnInitializedAsync()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();
            if (state != new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())))
            {
                _navigationManager.NavigateTo("/");
            }
        }
        private async Task SubmitAsync()
        {
            //var result = await _authenticationManager.Login(_tokenModel);
            //if (result.Succeeded)
            //{
            //    _snackBar.Add(string.Format(_localizer["Welcome {0}"], _tokenModel.Email), Severity.Success);
            //    _navigationManager.NavigateTo("/", true);
            //}
            //else
            //{
            //    foreach (var message in result.Messages)
            //    {
            //        _snackBar.Add(message, Severity.Error);
            //    }
            //}
        }
        void TogglePasswordVisibility()
        {
            if (_passwordVisibility)
            {
                _passwordVisibility = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _passwordInput = InputType.Password;
            }
            else
            {
                _passwordVisibility = true;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _passwordInput = InputType.Text;
            }
        }
    }
}
