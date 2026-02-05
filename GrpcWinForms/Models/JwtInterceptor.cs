using Grpc.Core;
using Grpc.Core.Interceptors;
using GrpcCommonNet.Library.Auth;

public class JwtInterceptor : Interceptor
{
    private readonly Func<string> _tokenAccessor;

    public JwtInterceptor(Func<string> tokenAccessor)
    {
        _tokenAccessor = tokenAccessor;
    }

    // ----------- ASYNC unary ----------
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        var token = _tokenAccessor();

        // Если токена нет или вызывается метод Auth → не добавляем заголовок
        if (!string.IsNullOrEmpty(token) && !context.Method.FullName.Contains("Auth"))
        {
            var headers = new Metadata
            {
                { "Authorization", $"Bearer {token}" }
            };

            var newOptions = context.Options.WithHeaders(headers);
            var newContext = new ClientInterceptorContext<TRequest, TResponse>(
                context.Method,
                context.Host,
                newOptions
            );

            return continuation(request, newContext);
        }

        return continuation(request, context);
    }

    // ----------- BLOCKING unary --------
    public override TResponse BlockingUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        BlockingUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        var token = _tokenAccessor();

        // Если токена нет или вызывается метод Auth → не добавляем заголовок
        if (!string.IsNullOrEmpty(token) && !context.Method.FullName.Contains("Auth"))
        {
            var headers = new Metadata
            {
                { "Authorization", $"Bearer {token}" }
            };
       
            var newOptions = context.Options.WithHeaders(headers);
            var newContext = new ClientInterceptorContext<TRequest, TResponse>(
                context.Method,
                context.Host,
                newOptions
            );

            return continuation(request, newContext);
        }

        return continuation(request, context);
    }
}
