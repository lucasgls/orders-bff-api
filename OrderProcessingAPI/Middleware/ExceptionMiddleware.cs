using System.Text.Json;
using Microsoft.AspNetCore.Http;
using OrderProcessingAPI.Application.DTOs;
using OrderProcessingAPI.Domain.Exceptions;

namespace OrderProcessingAPI.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException ex)
            {
                await WriteErrorAsync(context, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (BusinessRuleException ex)
            {
                await WriteErrorAsync(context, StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception)
            {
                await WriteErrorAsync(context, StatusCodes.Status500InternalServerError, "Erro interno no servidor");
            }
        }

        private static async Task WriteErrorAsync(HttpContext context, int statusCode, string message)
        {
            if (context.Response.HasStarted)
                return;

            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json; charset=utf-8";

            var errorResponse = new ErrorResponseDto
            (
                Erro: message,
                Status: statusCode,
                Timestamp: DateTime.UtcNow
            );

            var json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }
}