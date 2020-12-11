using BloodDonationApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BloodDonationApp.Services
{
    public static class ApiService
    {
        #region  Register User
        public static async Task<bool> RegisterUser(string email, string firstName, string lastName, string role, string password, string ConfirmPassword)
        {
            DateTime DateOfReg = DateTime.Now;
            var register = new Register()
            {
                Email = email,
                FirstName = firstName,
                LastName= lastName,
                Role=role,
                DateOfRegistration= DateOfReg.ToShortDateString(),
                Password = password,
                ConfirmPassword= ConfirmPassword
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(Constants.ApiUrl + "api/Account/Register", content);
            var resultJson = response.Content.ReadAsStringAsync().Result; // Getting GuId
            dynamic resultObj = JsonConvert.DeserializeObject(resultJson);
            string userId = resultObj.UserId;
            //string id = userId.toString();
            Preferences.Set("userId", userId);
            if (!response.IsSuccessStatusCode)
            return false;
            else
                return true;
        }
        #endregion

        #region Login User
        public static async Task<bool> Login(string email, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var httpclient = new HttpClient();          
            var request = new HttpRequestMessage(
                HttpMethod.Post, Constants.ApiUrl + "Token");
            request.Content = new FormUrlEncodedContent(keyValues);
            var response = await httpclient.SendAsync(request);
            if (!response.IsSuccessStatusCode) return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.access_token);
            Preferences.Set("userName", result.userName);
            //Preferences.Set("user_Id", result.user_Id);
            return true;
        }
        #endregion

        #region Get ALL Donor
        public static async Task<List<Donor>> GetDonorAsync(string accessToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.ApiUrl + "Donor/GetAllDonors");

            var donor = JsonConvert.DeserializeObject<List<Donor>>(json);

            return donor;
        }
        #endregion

        #region Update Donor Details
        public static async Task PutDonorAsync(Donor donor, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(donor);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(
                Constants.ApiUrl + "Donor/UpdateDonorDetails/" + donor.DonorId, content);
        }
        #endregion

        #region Delete Donor
        public static async Task DeleteDonorAsync(int userId, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.DeleteAsync(
               Constants.ApiUrl + "Donor/DeleteDonorByID?id=" + userId);
        }
        #endregion

        #region GetDonor By ID
        public static async Task<Donor> GetDonorByIdAsync(string userId, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.ApiUrl + "Donor/GetDonorDetails/" + userId);

            dynamic resp = JsonConvert.DeserializeObject(json);
            Donor donor = resp.ToObject<Donor>();

            //List<Donor> donorList = new List<Donor>();
            //donorList.Add(donor);

            return donor;
        }
        #endregion


        #region Get ALL Disease
        public static async Task<List<Disease>> GetDiseaseAsync(string accessToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.ApiUrl + "Disease/GetAllDiseases");

            var disease = JsonConvert.DeserializeObject<List<Disease>>(json);

            return disease;
        }
        #endregion

        #region GetRecipient By ID
        public static async Task<Recipient> GetRecipientByIdAsync(string userId, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync(Constants.ApiUrl + "Recipient/GetRecipientDetails/"+userId);
            dynamic resp = JsonConvert.DeserializeObject(json);
            Recipient recipient = resp.ToObject<Recipient>();
            return recipient;
        }
        #endregion

        #region Update Recipient Details
        public static async Task PutRecipientAsync(Recipient recipient, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(recipient);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(
                Constants.ApiUrl + "Recipient/UpdateRecipientDetails/" + recipient.RecipientId, content);
        }
        #endregion


    }
}
