using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Location;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Locations.Repositories
{
    public class LocationsRepository
    {
        public LocationsRepository() { }
        public static async Task<List<Location>> RefreshLocation(LocationType type, string text)
        {
            try
            {
                List<Location> locations = new List<Location>();
                ListLocationRequest request = new ListLocationRequest()
                {
                    Type = type,
                    Name = text
                };

                ListLocationResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Location.GetListLocationAsync(request).ResponseAsync);
                locations.AddRange(response.Locations);
                return locations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Join(Environment.NewLine,
                    "Ошибка при получении  данных"), "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new List<Location>();
        }

        public static async Task<Location> UpdateLocation(Location location)
        {
            try
            {
                UpdateLocationRequest request = new UpdateLocationRequest() { Location = location };
                LocationResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Location.UpdateLocationAsync(request).ResponseAsync);

                if (response == null || response.Result.Status != Status.Ok) return new Location();
                return response.Location;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Join(Environment.NewLine,
                    "Ошибка при получении  данных"), "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Location();
            }

        }
    }
}
