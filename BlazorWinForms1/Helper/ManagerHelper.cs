using BlazorWinForms1.Helper.Wrapper;
using BlazorWinForms1.SiteModels.Requests;
using BlazorWinForms1.SiteModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWinForms1.Helper
{
    public class ManagerHelper
    {
        private protected HttpClient _httpClient;
        public ManagerHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://lowcalories.ae:51");
            //_httpClient.BaseAddress = new Uri("https://localhost:5001");
        }
        public static string GetSubscriptions(int pageSize = 100, int pageNumber = 1) => $"api/Manager/GetAllSubscriptions?pageSize={pageSize}&pageNumber={pageNumber}";

        public async Task<PaginatedResult<SubscriptionsResponse>> GetSubscriptions(ManagerRequest request, int PageSize, int PageNumber)
        {

            var response = await _httpClient.PostAsJsonAsync(GetSubscriptions(PageSize, PageNumber), request);
            return await response.ToPaginatedResult<SubscriptionsResponse>();
        }
    }

}
