using System.Diagnostics;

namespace Game_APP.Middlewares
{
    public class ProfilerMiddleware
    {
        private readonly ILogger<ProfilerMiddleware> _logger; 
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate requestDelegate ;

        public ProfilerMiddleware(ILogger<ProfilerMiddleware> logger, IConfiguration configuration, RequestDelegate requestDelegate)
        {
            _logger = logger;
            _configuration = configuration;
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await  requestDelegate.Invoke(context);
            stopwatch.Stop();
            _logger.LogInformation($"{stopwatch.ElapsedMilliseconds}{context.Request.Path}");


          //  return requestDelegate(context);

        }
    }
}
