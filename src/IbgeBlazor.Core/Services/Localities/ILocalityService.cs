public interface IHttpService<TRequest, TResponse> 
where TRequest : Request
where TResponse : Response {

}

public interface ILocalityService : IHttpService<CreateLocalityRequest, LocalityResponse>
{
    Task<LocalityResponse?> PostCreateLocality(CreateLocalityRequest? request);
}

public class CreateLocalityRequest : Request
{
}

public class LocalityResponse : Response
{
}

public abstract class Request
{
}

public abstract class Response
{
}