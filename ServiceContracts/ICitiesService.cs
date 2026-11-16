namespace ServiceContracts
{
    // Dependency Inversion Principle (DIP):
    // interface
    public interface ICitiesService
    {
        Guid serviceInstanceID{ get; }
        List<string> GetCities();


    }
}
