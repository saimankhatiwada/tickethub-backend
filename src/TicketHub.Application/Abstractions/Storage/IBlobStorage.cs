using TicketHub.Domain.Abstractions;

namespace TicketHub.Application.Abstractions.Storage;

public interface IBlobStorage
{
    Task<Result> UploadAsync(Stream stream, string contentType, string fileName, CancellationToken cancellationToken = default);

    Task<Result<string>> GetPresignedUrlAsync(string fileName, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(string fileName, CancellationToken cancellationToken = default);
}
