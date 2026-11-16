using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService , IDisposable
    {
        private List<string> _cities;
        private Guid _serviceInstanceID;

        public Guid serviceInstanceID
        {
            get { return _serviceInstanceID; }
        } 
        public CitiesService()
        {
            _serviceInstanceID = Guid.NewGuid();
            _cities = new List<string> 
            { 
                "New York",
                "Los Angeles",
                "Cairo",
                "Houston",
                "Phoenix"
            };
            // to do: add logic to connect to database and fetch cities
        }


        // Returns the list of available cities.
        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            // to do: add logic close database connections
        }
    }
}
