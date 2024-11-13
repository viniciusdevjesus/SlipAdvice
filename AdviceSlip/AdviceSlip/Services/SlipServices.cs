using AdviceSlip.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdviceSlip.Services
{
    public class SlipServices
    {
        private HttpClient httpClient;
        private ObservableCollection<SlipModel> slips;
        private JsonSerializerOptions jsonSerializerOptions;
        
        public SlipServices() 
        {
            slips = new ObservableCollection<SlipModel>();
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<SlipModel>> getSlip()
        {
            Uri uri = new Uri("https://api.adviceslip.com/advice");
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                    var slipsModel = JsonSerializer.Deserialize<SlipModel>(content, jsonSerializerOptions);
                    if (slipsModel != null)
                    {
                        slips.Clear();
                        slips.Add(slipsModel);
                    }
                }
            } catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return slips;
        }
    }
}
