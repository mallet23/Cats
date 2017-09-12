using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ApiWrapper.Responses;

namespace ApiWrappers.Clients
{
    public class CatClient
    {
        private const string BaseApiUri = "http://thecatapi.com/api/";

        public async Task<IEnumerable<ImageResponse.Image>> GetImagesAsync(int pageCount, string categoryName)
        {
            var getImagesUrl =
                    $"{BaseApiUri}images/get?format=xml&results_per_page={pageCount}&category={categoryName}";

            var getImagesTask = await GetAsync<ImageResponse.Response>(getImagesUrl);

            return getImagesTask.Data.Images;
        }

        public async Task<IEnumerable<CategoryResponse.Category>> GetCategoriesAsync()
        {
            var getCategoriesUrl = $"{BaseApiUri}categories/list";

            var getCategoriesTask = await GetAsync<CategoryResponse.Response>(getCategoriesUrl);

            return getCategoriesTask.Data.Categories;
        }

        private static async Task<TResult> ReadResultAsync<TResult>(HttpResponseMessage response) where TResult : new()
        {
            var readTask = await response.Content.ReadAsStringAsync();

            using (var reader = new StringReader(readTask))
            {
                return (TResult) new XmlSerializer(typeof(TResult)).Deserialize(reader);
            }
        }

        private static async Task<T> GetAsync<T>(string uri) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);

                return await ReadResultAsync<T>(response);
            }
        }
    }
}