using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.ExceptionHandlers;

public class CriticalExceptionHandler : IExceptionHandler
{
	public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
	{
		if (exception is CriticalException)
		{
			Console.WriteLine("Hata ile SMS Gönderildi.");
		}
		return ValueTask.FromResult(false);
	}
}
