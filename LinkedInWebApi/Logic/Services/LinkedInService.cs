using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Logic.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Logic.Services
{
    public interface ILinkedInService
    {
        Task<LinkedInUserData> LinkedInLogin(string code);
    }

    public class LinkedInService : ILinkedInService
    {
        private AppSettings AppSettings { get; }
        public LinkedInService(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
        }

        public async Task<LinkedInUserData> LinkedInLogin(string code)
        {
            try
            {
                //Get Access Token  
                var accessTokenClient = new RestClient("https://www.linkedin.com/oauth/v2/accessToken");
                var accessTokenRequest = new RestRequest(Method.POST);
                accessTokenRequest.AddParameter("grant_type", "authorization_code");
                accessTokenRequest.AddParameter("code", code);
                accessTokenRequest.AddParameter("redirect_uri", AppSettings.RedirectUri);
                accessTokenRequest.AddParameter("client_id", AppSettings.ClientId);
                accessTokenRequest.AddParameter("client_secret", AppSettings.ClientSecret);
                var accessTokenResponse = await accessTokenClient.ExecuteAsync(accessTokenRequest);
                var token = JsonConvert.DeserializeObject<TokenResponse>(accessTokenResponse.Content);

                var profileInfoClient = new RestClient("https://api.linkedin.com/v2/me");
                var profileInfoRequest = new RestRequest(Method.GET);
                profileInfoRequest.AddParameter("oauth2_access_token", token.Access_token);
                profileInfoRequest.AddParameter("projection", "(id,localizedFirstName,localizedLastName,profilePicture(displayImage~:playableStreams))");
                var profileInfoResponse = await profileInfoClient.ExecuteAsync(profileInfoRequest);
                var linkedInUserData = JsonConvert.DeserializeObject<LinkedInUserData>(profileInfoResponse.Content);
                return linkedInUserData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
