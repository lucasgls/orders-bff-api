using System.Net;

namespace OrderProcessingAPI.Application.DTOs
{
    public record ErrorResponseDto
    (
       string Erro,
       int Status,
       DateTime Timestamp
    );
}